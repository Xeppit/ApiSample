using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Api.Models;
using ApiSample.Api.Repositories;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;
using Microsoft.AspNetCore.Mvc;

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
            var getAllResponse = new List<AddressGetResponse>();

            foreach (var addressModel in getAllResult)
            {
                var newResponse = new AddressGetResponse
                {
                    Id = addressModel.Id,
                    Line1 = addressModel.Line1,
                    Line2 = addressModel.Line2,
                    Line3 = addressModel.Line3,
                    Line4 = addressModel.Line4,
                    Postcode = addressModel.Postcode
                };

                getAllResponse.Add(newResponse);
            }

            return getAllResponse;
        }

        public async Task<AddressGetResponse> GetByIdAsync(string id)
        {
            var getAllResult = await _addressRepository.FindOneAsync(x => x.Id == id);

            if (getAllResult == null)
                return default;

            var newResponse = new AddressGetResponse
            {
                Id = getAllResult.Id,
                Line1 = getAllResult.Line1,
                Line2 = getAllResult.Line2,
                Line3 = getAllResult.Line3,
                Line4 = getAllResult.Line4,
                Postcode = getAllResult.Postcode
            };

            return newResponse;
        }

        public async Task<bool> PostAsync(AddressPostRequest addressPostRequest)
        {
            var addressModel = new AddressModel()
            {
                Line1 = addressPostRequest.Line1,
                Line2 = addressPostRequest.Line2,
                Line3 = addressPostRequest.Line3,
                Line4 = addressPostRequest.Line4,
                Postcode = addressPostRequest.Postcode,
                Created = DateTime.Now
            };

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
            var addressModel = new AddressModel()
            {
                Id = addressPostRequest.Id,
                Line1 = addressPostRequest.Line1,
                Line2 = addressPostRequest.Line2,
                Line3 = addressPostRequest.Line3,
                Line4 = addressPostRequest.Line4,
                Postcode = addressPostRequest.Postcode,
                Modified = DateTime.Now
            };

            try
            {
                await _addressRepository.UpdateAsync(id, addressModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                await _addressRepository.DeleteAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
