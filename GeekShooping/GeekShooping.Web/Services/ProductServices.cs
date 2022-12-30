using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using GeekShooping.Web.Utils;

namespace GeekShooping.Web.Services {
    public class ProductServices:IProductService {
        private readonly HttpClient _client;
        public const string basePath = "api/v1/product";

        public ProductServices (HttpClient client) {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModel> Create (ProductModel model) {
            var response = await _client.PostAsJson(basePath, model);
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            else throw new Exception("Somenting went wrong when calling API");
        }

        public async Task<IEnumerable<ProductModel>> GetAll () {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetById (long id) {
            var response = await _client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> Remove (long id) {
            var response = await _client.DeleteAsync($"{basePath}/{id}");
            if(response.IsSuccessStatusCode)
                await response.ReadContentAs<bool>();
            else
                throw new Exception("Somenting went wrong when calling API");
        }

        public async Task<ProductModel> Update (ProductModel model) {
            var response = await _client.PutAsJson(basePath, model);
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            else throw new Exception("Somenting went wrong when calling API");
        }
    }
}
