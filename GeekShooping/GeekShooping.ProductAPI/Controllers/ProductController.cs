using GeekShooping.ProductAPI.Data.ValuesObjects;
using GeekShooping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase {
        private IProductRepository productRepository;
        public ProductController (IProductRepository productRepository) {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> Get(long id) {
            var product = await productRepository.GetByIdAsync(id);
            if(product.Id <= 0) {
                return NotFound();
            } else {
                return Ok(product);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll () {
            var products = await productRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO vo) {

            if(vo == null) return BadRequest();
            var product = await productRepository.Create(vo);
            return Ok(product);
        }
        
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO vo) {

            if(vo == null) return BadRequest();
            var product = await productRepository.UpdateAsync(vo);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVO>> Delete (long id) {
            var status = await productRepository.DeleteAsync(id);
            if(!status) return BadRequest();
            return Ok(status);
        }

    }
}
