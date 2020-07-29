using ApiSample.Api.Models;
using MongoDB.Driver;

namespace ApiSample.Api.Repositories
{
    public class CompanyRepository : RepositoryBase<CompanyModel>
    {
        public CompanyRepository(IMongoCollection<CompanyModel> collection)
            : base(collection)
        {

        }
    }
}
