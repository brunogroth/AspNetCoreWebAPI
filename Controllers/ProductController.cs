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

        // First Get Method to list all products
        [HttpGet]
        [Route("list")]
        public IActionResult List(){
            return Ok(this._productService.GetProducts());
        }

        // Post Method to create a product
        [HttpPost]
        public IActionResult Create(Product product){
            this._productService.AddProduct(product);
            return Ok();
        }

        [HttpPut]
        [Route("list/{OldName}/{Name}")]
        public IActionResult Edit([FromRoute] string OldName, string Name){
            //Execute method EditProduct with parameters OldName and New Name and save the result at variable 'edited' 
            bool edited = this._productService.EditProduct(OldName, Name);

            //if result from edited is true, return success. Else, return not found
            if(edited == true){
                return Ok(_productService);
            }else{
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("list/{Name}")]
        public IActionResult Delete([FromRoute] string Name){
            bool deleted = this._productService.DeleteProduct(Name);
        if(deleted == true){
                return Ok(_productService);
            }else{
                return NotFound();
            }
        }
    }
}