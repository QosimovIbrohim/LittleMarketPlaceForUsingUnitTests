using MarketPlace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Application.Abstractions
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<string> InsertAsync(Product pr);
        public Task<string> DeleteAsync(int id);
        public Task<string> UpdateAsync(Product product);
    }
}
