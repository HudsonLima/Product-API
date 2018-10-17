using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Service.Validators;

namespace ProductAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productService.Get();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                _productService.Put<ProductValidator>(product);
                return Ok(product);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Products
        // [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _productService.Post<ProductValidator>(product);
                return  Ok(product.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("count")]
        public IActionResult productCount()
        {
            try
            { 
                MemoryStream memoryStream = new MemoryStream();
                TextWriter tw = new StreamWriter(memoryStream);

                tw.WriteLine("Product Count");
                tw.WriteLine(_productService.Count());
                tw.Flush();
                tw.Close();

                return File(memoryStream.GetBuffer(), "text/plain", "productCount.txt");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }
    }

}
