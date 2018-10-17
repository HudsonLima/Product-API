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
                return NotFound();
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

        // DELETE: api/Brand/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _brandService.Delete(id);
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
        [Produces("application/xml")]
        public IActionResult brandsCount(int id)
        {
            try
            {
                IQueryable<Object> obj;
                obj = _brandService.GetBrandsAndProductCount();
               // ObjectResult objResult = new ObjectResult(obj);
              //  objResult.ContentTypes.Add("application/json");

                return new ObjectResult(obj);

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

      /*  [HttpGet("count2")]
        [Produces("application/xml")]
        public ContentResult Get2()
        {
            IQueryable<Object> obj;
            obj = brandService.GetBrandsAndProductCount();

            return new ContentResult
            {
                ContentType = "application/xml",
                Content = obj.ToList(),
                StatusCode = 200
            };
        }

    */
    }
}