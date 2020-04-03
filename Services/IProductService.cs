using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreJWTAuth.Models;

namespace DotNetCoreJWTAuth.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIDAsync(Guid productID);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid productID);
        Task<bool> CreateProductAsync(Product product);
    }
}
