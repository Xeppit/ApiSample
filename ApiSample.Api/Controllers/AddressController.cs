using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;
using ApiSample.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IEnumerable<AddressGetResponse>> Get()
        {
            return await _addressService.GetAllAsync();
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _addressService.GetByIdAsync(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressPostRequest value)
        {
            var result = await _addressService.PostAsync(value);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] AddressPutRequest value)
        {
            var result = await _addressService.PutAsync(id, value);

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
            var result = await _addressService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
