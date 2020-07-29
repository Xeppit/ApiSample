using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Api.Repositories;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;

namespace ApiSample.Api.Services
{
    public class ContactService : IService<ContactGetResponse, ContactPostRequest, ContactPutRequest>
    {
        private readonly ContactRepository _contactRepository;
        private readonly CompanyRepository _companyRepository;

        public ContactService(ContactRepository contactRepository, CompanyRepository companyRepository)
        {
            _contactRepository = contactRepository;
            _companyRepository = companyRepository;
        }
        public async Task<List<ContactGetResponse>> GetAllAsync()
        {
            var getAllContactsResult = await _contactRepository.GetAllAsync();

            foreach (var contactModel in getAllContactsResult)
            {
                
            }
            var getCompanyResult = await _companyRepository.FindOneAsync(x => x.Id == );

            return getAllResult.Select(companyModel => companyModel?.ToCompanyGetResponse()).ToList();
        }

        public Task<ContactGetResponse> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostAsync(ContactPostRequest postRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutAsync(string id, ContactPutRequest putRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
