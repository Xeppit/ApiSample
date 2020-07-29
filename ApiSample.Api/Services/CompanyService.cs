using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Api.Extensions;
using ApiSample.Api.Repositories;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;
using MongoDB.Driver;

namespace ApiSample.Api.Services
{
    public class CompanyService : IService<CompanyGetResponse, CompanyPostRequest, CompanyPutRequest>
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyGetResponse>> GetAllAsync()
        {
            var getAllResult = await _companyRepository.GetAllAsync();

            return getAllResult.Select(companyModel => companyModel?.ToCompanyGetResponse()).ToList();
        }

        public async Task<CompanyGetResponse> GetByIdAsync(string id)
        {
            var getByIdResult = await _companyRepository.FindOneAsync(x => x.Id == id);

            var newResponse = getByIdResult?.ToCompanyGetResponse();

            return newResponse;
        }

        public async Task<bool> PostAsync(CompanyPostRequest postRequest)
        {
            var addressModel = postRequest.ToCompanyModel();

            try
            {
                await _companyRepository.InsertAsync(addressModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> PutAsync(string id, CompanyPutRequest putRequest)
        {
            var addressModel = putRequest.ToCompanyModel();

            ReplaceOneResult result;

            try
            {
                result = await _companyRepository.UpdateAsync(id, addressModel);
            }
            catch (Exception)
            {
                return false;
            }

            if (!result.IsAcknowledged) return false;

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(string id)
        {
            DeleteResult result;
            try
            {
                result = await _companyRepository.DeleteAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                return false;
            }

            if (!result.IsAcknowledged) return false;

            return result.DeletedCount == 1;
        }
    }
}
