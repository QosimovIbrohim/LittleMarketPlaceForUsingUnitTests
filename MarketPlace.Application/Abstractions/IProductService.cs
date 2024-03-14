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
        public ValueTask<List<Product>> GetAll();
        public ValueTask<Product> Get(int id);
        public ValueTask<Product> Add(Product pr);
        public ValueTask<Product> Delete(int id);
        public ValueTask<Product> Update(int id, Product product);
    }
}
