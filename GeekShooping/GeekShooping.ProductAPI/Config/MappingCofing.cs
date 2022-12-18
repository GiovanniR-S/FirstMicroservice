using AutoMapper;
using GeekShooping.ProductAPI.Data.ValuesObjects;
using GeekShooping.ProductAPI.Model;

namespace GeekShooping.ProductAPI.Config {
    public class MappingCofing {
        public static MapperConfiguration RegisterMaps () {
            var mappingCofing = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingCofing;
        }
    }
}
