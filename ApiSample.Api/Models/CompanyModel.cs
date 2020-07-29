using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiSample.Api.Models
{
    public class CompanyModel : IDbModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
    }
}
