using System;
using ApiSample.Api.Models;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;

namespace ApiSample.Api.Extensions
{
    public static class ContactMapperExtensions
    {
        public static ContactGetResponse ToContactGetResponse(this ContactModel contactModel, CompanyGetResponse companyGetResponse)
        {
            return new ContactGetResponse
            {
                Id = contactModel.Id,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber,
                Company = companyGetResponse
            };
        }

        public static ContactModel ToContactModel(this ContactPostRequest contactModel)
        {
            return new ContactModel
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber,
                CompanyId = contactModel.CompanyId,
                Created = DateTime.Now
            };
        }

        public static ContactModel ToContactModel(this ContactPutRequest contactModel)
        {
            return new ContactModel
            {
                Id = contactModel.Id,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber,
                CompanyId = contactModel.CompanyId,
                Modified = DateTime.Now
            };
        }
    }
}
