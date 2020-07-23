using System;
using ApiSample.Api.Models;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;

namespace ApiSample.Api.Extensions
{
    public static class AddressMapperExtensions
    {
        public static AddressGetResponse ToAddressGetResponse(this AddressModel addressModel)
        {
            return new AddressGetResponse
            {
                Id = addressModel.Id,
                Line1 = addressModel.Line1,
                Line2 = addressModel.Line2,
                Line3 = addressModel.Line3,
                Line4 = addressModel.Line4,
                Postcode = addressModel.Postcode
            };
        }

        public static AddressModel ToAddressModel(this AddressPostRequest addressModel)
        {
            return new AddressModel
            {
                Line1 = addressModel.Line1,
                Line2 = addressModel.Line2,
                Line3 = addressModel.Line3,
                Line4 = addressModel.Line4,
                Postcode = addressModel.Postcode,
                Created = DateTime.Now
            };
        }

        public static AddressModel ToAddressModel(this AddressPutRequest addressModel)
        {
            return new AddressModel
            {
                Id = addressModel.Id,
                Line1 = addressModel.Line1,
                Line2 = addressModel.Line2,
                Line3 = addressModel.Line3,
                Line4 = addressModel.Line4,
                Postcode = addressModel.Postcode,
                Modified = DateTime.Now
            };
        }
    }
}
