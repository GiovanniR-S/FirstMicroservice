using GeekShooping.ProductAPI.Data.ValuesObjects;

namespace GeekShooping.ProductAPI.Repository {
    public interface IProductRepository {
        Task<IEnumerable<ProductVO>> GetAllAsync();
        Task<ProductVO> GetByIdAsync (long id);
        Task<ProductVO> Create (ProductVO pvo);
        Task<ProductVO> UpdateAsync (ProductVO pvo);
        Task<bool> DeleteAsync (long id);
    }
}
