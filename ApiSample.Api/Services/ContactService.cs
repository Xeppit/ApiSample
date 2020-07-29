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
    public class ContactService : IService<ContactGetResponse, ContactPostRequest, ContactPutRequest>
    {
        private readonly ContactRepository _contactRepository;

        public ContactService(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactGetResponse>> GetAllAsync()
        {
            var getAllResult = await _contactRepository.GetAllAsync();

            return getAllResult.Select(contactModel => contactModel?.ToContactGetResponse()).ToList();
        }

        public async Task<ContactGetResponse> GetByIdAsync(string id)
        {
            var getByIdResult = await _contactRepository.FindOneAsync(x => x.Id == id);

            var newResponse = getByIdResult?.ToContactGetResponse();

            return newResponse;
        }

        public async Task<bool> PostAsync(ContactPostRequest postRequest)
        {
            var contactModel = postRequest.ToContactModel();

            try
            {
                await _contactRepository.InsertAsync(contactModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> PutAsync(string id, ContactPutRequest putRequest)
        {
            var addressModel = putRequest.ToContactModel();

            ReplaceOneResult result;

            try
            {
                result = await _contactRepository.UpdateAsync(id, addressModel);
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
                result = await _contactRepository.DeleteAsync(x => x.Id == id);
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
