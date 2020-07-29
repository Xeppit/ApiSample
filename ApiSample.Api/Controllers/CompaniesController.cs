using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Api.Requests;
using ApiSample.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase, IController<CompanyPostRequest, CompanyPutRequest>
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _companyService.GetAllAsync();
            return Ok(result);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _companyService.GetByIdAsync(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyPostRequest value)
        {
            var result = await _companyService.PostAsync(value);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CompanyPutRequest value)
        {
            var result = await _companyService.PutAsync(id, value);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _companyService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
