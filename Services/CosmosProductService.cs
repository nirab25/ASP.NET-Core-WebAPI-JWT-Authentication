using DotNetCoreJWTAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;

namespace DotNetCoreJWTAuth.Services
{
    public class CosmosProductService : IProductService
    {
        private readonly ICosmosStore<CosmosProduct> _cosmosStore;

        public CosmosProductService(ICosmosStore<CosmosProduct> cosmosStote)
        {
            _cosmosStore = cosmosStote;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _cosmosStore.Query().ToListAsync();
            return products.Select(x => new Product
            {
                ProductID = Guid.Parse(x.ProductID),
                ProductCode = x.ProductCode,
                ProductName = x.ProductName
            }).ToList();
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            var productCosmos = new CosmosProduct
            {
                ProductID = Guid.NewGuid().ToString(),
                ProductName = product.ProductName,
                ProductCode = product.ProductCode
            };

            var response = await _cosmosStore.AddAsync(productCosmos);
            product.ProductID = Guid.Parse(productCosmos.ProductID);

            return response.IsSuccess;
        }

        public async Task<bool> DeleteProductAsync(Guid productID)
        {
            var response = await _cosmosStore.RemoveByIdAsync(productID.ToString(), productID.ToString());
            return response.IsSuccess;
        }

        public async Task<Product> GetProductByIDAsync(Guid productID)
        {
            var product = await _cosmosStore.FindAsync(productID.ToString(), productID.ToString());

            return product == null ? null : new Product {
                ProductID = Guid.Parse(product.ProductID),
                ProductCode = product.ProductCode, 
                ProductName = product.ProductName
            };
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var productCosmos = new CosmosProduct
            {
                ProductID = product.ProductID.ToString(),
                ProductName = product.ProductName,
                ProductCode = product.ProductCode
            };

            var response = await _cosmosStore.UpdateAsync(productCosmos);
            return response.IsSuccess;
        }
    }
}
