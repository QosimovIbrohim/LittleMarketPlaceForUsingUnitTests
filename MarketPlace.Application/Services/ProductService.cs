using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.Application.Abstractions;
using MarketPlace.Domain.DTOs;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> Add(ProductDTO pr)
        {
            var product = MapDTOToEntity(pr);
            var res = await _productRepository.InsertAsync(product);
            return res;
        }

        public async Task<string> Delete(int id)
        {
            var result = await _productRepository.DeleteAsync(id);
            return result;
        }

        public async Task<Product> Get(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return products;
        }

        public async Task<string> Update(int id, ProductDTO product)
        {
            var res = await Get(id);
            if (res == null)
            {
                return "Not Found";
            }
            var entity = MapDTOToEntity(product);
            var s = await _productRepository.UpdateAsync(entity);
            return s;
        }

        private Product MapDTOToEntity(ProductDTO dto)
        {
            return new Product
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
