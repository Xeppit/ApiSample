using ApiSample.Api.Models;
using MongoDB.Driver;

namespace ApiSample.Api.Repositories
{
    public class AddressRepository : RepositoryBase<AddressModel>
    {
        public AddressRepository(IMongoCollection<AddressModel> addressCollection)
            : base(addressCollection)
        {
            
        }
    }
}
