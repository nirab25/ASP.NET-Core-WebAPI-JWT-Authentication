using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreJWTAuth.Config.v1;
using DotNetCoreJWTAuth.Models;
using DotNetCoreJWTAuth.Models.v1.Requests;
using DotNetCoreJWTAuth.Models.v1.Responses;
using DotNetCoreJWTAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreJWTAuth.Controllers
{
    public class ProductController : Controller
    {
        private readonly  IProductService _productService;
        public ProductController(IProductService pService)
        {
            _productService = pService;
        }

        [HttpGet(ApiRoutes.Products.GetAllProducts)]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        [HttpGet(ApiRoutes.Products.Retrieve)]
        public async Task<IActionResult> GetProduct([FromRoute] Guid productID)
        {
            var product = await _productService.GetProductByIDAsync(productID);


            if (product == null)
                return NotFound("Requested product not found!");

            return Ok(product);
        }

        [HttpDelete(ApiRoutes.Products.Delete)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productID)
        {
            var isDeleted = await _productService.DeleteProductAsync(productID);

            if (!isDeleted)
                return NotFound("Requested product not found!");

            return Ok(productID.ToString() + " is deleted.");
        }

        [HttpPut(ApiRoutes.Products.Update)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid productID, [FromBody] UpdateProductRequest request)
        {
            var product = new Product
            {
                ProductID = productID,
                ProductCode = request.ProductCode,
                ProductName = request.ProductName
            };

            var updated = await _productService.UpdateProductAsync(product);

            if (!updated)
                return NotFound("Requested product not found!");

            return Ok(product);
        }

        [HttpPost(ApiRoutes.Products.Save)]
        public async Task<IActionResult> SaveProduct([FromBody] ProductRequest productRequest)
        {
            Product product = new Product
            {
                ProductID = Guid.NewGuid(),
                ProductCode = productRequest.ProductCode,
                ProductName = productRequest.ProductName
            };

           await _productService.CreateProductAsync(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Products.Save.Replace("{ProductID}", product.ProductID.ToString());

            var response = new ProductResponse
            {
                ProductID = product.ProductID,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName
            };

            return Created(locationUrl, response);
        }
    }
}