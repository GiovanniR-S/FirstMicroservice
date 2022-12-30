using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.IServices {
    public interface IProductService {
        Task<IEnumerable<ProductModel>> GetAll ();
        Task<ProductModel> GetById (long id);
        Task<ProductModel> Create (ProductModel model);
        Task<ProductModel> Update (ProductModel model);
        Task<ProductModel> Remove (long id);
    }
}
