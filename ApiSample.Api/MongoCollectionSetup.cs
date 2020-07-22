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

            var locationCollection = database.GetCollection<AddressModel>("Addresses");

            services.AddScoped(provider => locationCollection);
        }
    }
}
