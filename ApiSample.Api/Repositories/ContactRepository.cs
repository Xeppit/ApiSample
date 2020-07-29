using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Api.Models;
using MongoDB.Driver;

namespace ApiSample.Api.Repositories
{
    public class ContactRepository : RepositoryBase<ContactModel>
    {
        public ContactRepository(IMongoCollection<ContactModel> collection)
            : base(collection)
        {
        }
    }
}
