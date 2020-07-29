using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Api.Models;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ApiSample.Api
{
    public static class MongoCollectionSetup
    {
        public static void AddMongoCollections(
            this IServiceCollection services,
            string connectionString)
        {
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("TestApi");

            var addressCollection = database.GetCollection<AddressModel>("Addresses");
            var companyCollection = database.GetCollection<CompanyModel>("Companies");
            var contactCollection = database.GetCollection<ContactModel>("Contacts");

            services.AddScoped(provider => addressCollection);
            services.AddScoped(provider => companyCollection);
            services.AddScoped(provider => contactCollection);
        }
    }
}
