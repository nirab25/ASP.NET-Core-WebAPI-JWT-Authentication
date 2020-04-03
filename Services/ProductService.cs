using DotNetCoreJWTAuth.Data;
using DotNetCoreJWTAuth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreJWTAuth.Services
{
    public class ProductService : IProductService
    {
        private readonly MSSQLDBContext _dbContext;

        public ProductService(MSSQLDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductByIDAsync(Guid productID)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(x => x.ProductID == productID);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            var updated = await _dbContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteProductAsync(Guid productID)
        {
            var product = await GetProductByIDAsync(productID);
            _dbContext.Products.Remove(product);
            var deleted = await _dbContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CreateProductAsync(Product product) 
        {
            await _dbContext.Products.AddAsync(product);
            var created = await _dbContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
