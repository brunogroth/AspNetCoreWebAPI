using System;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebAPI.Services;
using AspNetCoreWebAPI.Models;

namespace AspNetCoreWebAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase{
        
        ProductService _productService;
        //Constructor
        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        // First Get Method
        [HttpGet]
        public IActionResult List(){
            return Ok(this._productService.GetProducts());
        }

        // Post Method to create a product
        [HttpPost]
        public IActionResult Create(Product product){
            this._productService.AddProduct(product);
            return Ok();
        }
    }
}