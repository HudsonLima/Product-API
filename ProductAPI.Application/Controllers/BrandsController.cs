using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Entities;
using ProductAPI.Service.Services;
using ProductAPI.Service.Validators;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using ProductAPI.Domain.Interfaces;
using System.Xml.Serialization;

namespace ProductAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/Brands
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var brands = _brandService.Get();
                return Ok(brands);
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
            Brand brand = _brandService.Get(id);
            if (brand == null)
            {
                return NotFound("Brand does not exist");
            }
            return Ok(brand);
        }

        // PUT: api/Brands/1
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Brand brand)
        {
            try
            {
                _brandService.Put<BrandValidator>(brand);
                return Ok(brand);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Brand does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Brands
        [HttpPost]
        public IActionResult Post([FromBody] Brand brand)
        {
            try
            {
                _brandService.Post<BrandValidator>(brand);
                return Ok(brand.Id);
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

        // DELETE: api/Brands/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _brandService.Delete(id);
                return Ok();
            }
            catch (ArgumentException)
            {
                return NotFound("Brand does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Get: api/Brands/Count
        [Produces("application/xml")]
        [HttpGet("count")]
        public IActionResult GetBrandsAndTotalProducts()
        {
            try
            {
                List<BrandElement> brands = _brandService.GetBrandsAndTotalProducts();
                return Ok(brands);
            }
            catch (ArgumentException)
            {
                return NotFound("No brands in database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }      

    }
}