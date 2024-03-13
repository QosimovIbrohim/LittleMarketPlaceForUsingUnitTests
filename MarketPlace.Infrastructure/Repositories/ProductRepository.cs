using MarketPlace.Application.Abstractions;
using MarketPlace.Domain.DTOs;
using MarketPlace.Domain.Entities;
using MarketPlace.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MpDbContext _mpDbContext;

        public ProductRepository(MpDbContext mpDbContext)
        {
            _mpDbContext = mpDbContext;
        }

        public async Task<string> InsertAsync(Product pr)
        {
            await _mpDbContext.Products.AddAsync(pr);
            await _mpDbContext.SaveChangesAsync();
            return "Created";
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _mpDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var res = await _mpDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return res == null ? throw new NullReferenceException("Product is not found") : res;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var res = await _mpDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                _mpDbContext.Products.Remove(res);
                await _mpDbContext.SaveChangesAsync();
                return "Deleted";
            }
            return "Not found";
        }

        public async Task<string> UpdateAsync(Product product)
        {
            _mpDbContext.Products.Update(product);
            await _mpDbContext.SaveChangesAsync();
            return "Updated";
        }
    }
}
