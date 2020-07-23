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
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressGetResponse>> GetAllAsync()
        {
            var getAllResult = await _addressRepository.GetAllAsync();

            return getAllResult.Select(addressModel => addressModel?.ToAddressGetResponse()).ToList();
        }

        public async Task<AddressGetResponse> GetByIdAsync(string id)
        {
            var getByIdResult = await _addressRepository.FindOneAsync(x => x.Id == id);

            var newResponse = getByIdResult?.ToAddressGetResponse();

            return newResponse;
        }

        public async Task<bool> PostAsync(AddressPostRequest addressPostRequest)
        {
            var addressModel = addressPostRequest.ToAddressModel();

            try
            {
                await _addressRepository.InsertAsync(addressModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> PutAsync(string id,AddressPutRequest addressPostRequest)
        {
            var addressModel = addressPostRequest.ToAddressModel();

            ReplaceOneResult result;

            try
            {
                result = await _addressRepository.UpdateAsync(id, addressModel);
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
                result = await _addressRepository.DeleteAsync(x => x.Id == id);
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
