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

        public async ValueTask<Product> Add(Product pr)
        {
            return await _productRepository.InsertAsync(pr);
        }
        public async ValueTask<Product> Delete(int id)
        {
            var stPr = await _productRepository.GetByIdAsync(id);
            if (stPr == null)
            {
                throw new ArgumentException();
            }
            return await _productRepository.DeleteAsync(stPr);
        }

        public async ValueTask<Product> Get(int id)
        {
            var stPr = await _productRepository.GetByIdAsync(id);
            if (stPr == null)
            {
                throw new Exception("");
            }
            return stPr;
        }

        public async ValueTask<List<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public async ValueTask<Product> Update(int id, Product product)
        {
            var stPr = await _productRepository.GetByIdAsync(id);

            if (stPr == null)
            {
                throw new Exception("");
            }
            stPr.Name = product.Name;
            stPr.Description = product.Description;
            return await _productRepository.UpdateAsync(stPr);
        }
    }
}
