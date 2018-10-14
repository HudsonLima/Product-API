using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Entities;
using ProductAPI.Service.Services;
using ProductAPI.Service.Validators;

namespace ProductAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService productService = new ProductService();

        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(productService.Get());
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
            try
            {
                return new ObjectResult(productService.Get(id));
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

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product item)
        {
            try
            {
                productService.Put<ProductValidator>(item);

                return new ObjectResult(item);
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
        public IActionResult Post([FromBody] Product item)
        {
            try
            {
                productService.Post<ProductValidator>(item);

                return new ObjectResult(item.Id);
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
                productService.Delete(id);

                return new NoContentResult();
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
                tw.WriteLine(productService.Count());
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
