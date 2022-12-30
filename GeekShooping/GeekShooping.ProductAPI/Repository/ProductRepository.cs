﻿using AutoMapper;
using GeekShooping.ProductAPI.Data.ValuesObjects;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository {
    public class ProductRepository:IProductRepository {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ProductRepository (MySqlContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVO> Create (ProductVO pvo) {
            Product product = _mapper.Map<Product>(pvo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> DeleteAsync (long id) {
            try {
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
                if(product.Id <= 0) {
                    return false;
                } else {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
            } catch(Exception) {

                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> GetAllAsync () {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> GetByIdAsync (long id) {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> UpdateAsync (ProductVO pvo) {
            Product product = _mapper.Map<Product>(pvo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
