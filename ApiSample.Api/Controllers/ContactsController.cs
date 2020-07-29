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
    public class ContactsController : ControllerBase, IController<ContactPostRequest, ContactPutRequest>
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _contactService.GetAllAsync();
            return Ok(result);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _contactService.GetByIdAsync(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactPostRequest value)
        {
            var result = await _contactService.PostAsync(value);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ContactPutRequest value)
        {
            var result = await _contactService.PutAsync(id, value);

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
            var result = await _contactService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
