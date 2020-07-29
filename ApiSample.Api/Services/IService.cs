using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Api.Services
{
    public interface IService<TGetResponse, in TPostRequest, in TPutRequest>
    {
        Task<List<TGetResponse>> GetAllAsync();
        Task<TGetResponse> GetByIdAsync(string id);
        Task<bool> PostAsync(TPostRequest postRequest);
        Task<bool> PutAsync(string id, TPutRequest putRequest);
        Task<bool> Delete(string id);
    }
}
