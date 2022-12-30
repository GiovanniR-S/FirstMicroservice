using AutoMapper;
using GeekShooping.ProductAPI.Config;
using GeekShooping.ProductAPI.Model.Context;
using GeekShooping.ProductAPI.Repository;
using GeekShooping.Web.Services;
using GeekShooping.Web.Services.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection), options => options.EnableRetryOnFailure(
        maxRetryCount: 5,
        maxRetryDelay: System.TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null
    )));

IMapper mapper = MappingCofing.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddHttpClient<IProductService, ProductServices>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceURLs:ProductAPI"])
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShooping.ProductAPI", Version = "v1" })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
