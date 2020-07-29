using System;
using ApiSample.Api.Models;
using ApiSample.Api.Requests;
using ApiSample.Api.Responses;

namespace ApiSample.Api.Extensions
{
    public static class CompanyMapperExtensions
    {
        public static CompanyGetResponse ToCompanyGetResponse(this CompanyModel companyModel)
        {
            return new CompanyGetResponse
            {
                Id = companyModel.Id,
                Name = companyModel.Name
            };
        }

        public static CompanyModel ToCompanyModel(this CompanyPostRequest companyModel)
        {
            return new CompanyModel
            {
                Name = companyModel.Name,
                Created = DateTime.Now
            };
        }

        public static CompanyModel ToCompanyModel(this CompanyPutRequest companyModel)
        {
            return new CompanyModel
            {
                Id = companyModel.Id,
                Name = companyModel.Name,
                Modified = DateTime.Now
            };
        }
    }
}
