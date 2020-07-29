using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Api.Controllers
{
    public interface IController<in TPostRequest, in TPutRequest>
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetById(string id);
        Task<IActionResult> Post([FromBody] TPostRequest value);
        Task<IActionResult> Put(string id, [FromBody] TPutRequest value);
        Task<IActionResult> Delete(string id);
    }
}