using GeekShooping.ProductAPI.Data.ValuesObjects;

namespace GeekShooping.ProductAPI.Repository {
    public class ProductRepository:IProductRepository {
        public Task<ProductVO> Create (ProductVO pvo) {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync (long id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductVO>> GetAllAsync () {
            throw new NotImplementedException();
        }

        public Task<ProductVO> GetByIdAsync (long id) {
            throw new NotImplementedException();
        }

        public Task<ProductVO> UpdateAsync (ProductVO pvo) {
            throw new NotImplementedException();
        }
    }
}
