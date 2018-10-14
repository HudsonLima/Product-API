using System;
using System.Collections.Generic;
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
    public class BrandsController : ControllerBase
    {
        private BrandService brandService = new BrandService();

        // GET: api/Brands
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(brandService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Brands/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(brandService.Get(id));
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

        // PUT: api/Brands/1
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Brand item)
        {
            try
            {
                brandService.Put<BrandValidator>(item);

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

        // POST: api/Brand
        // [HttpPost]
        public IActionResult Post([FromBody] Brand item)
        {
            try
            {
                brandService.Post<BrandValidator>(item);

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

        // DELETE: api/Brand/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                brandService.Delete(id);

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
    }
}