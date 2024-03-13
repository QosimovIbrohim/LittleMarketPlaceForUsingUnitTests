using MarketPlace.Domain.DTOs;
using MarketPlace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Application.Abstractions
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<Product> Get(int id);
        public Task<string> Add(ProductDTO pr);
        public Task<string> Delete(int id);
        public Task<string> Update(ProductDTO product);
    }
}
