using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Api.Models
{
    public interface IDbModel
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
