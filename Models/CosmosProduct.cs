using Cosmonaut.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreJWTAuth.Models
{
    [CosmosCollection("Products")]
    public class CosmosProduct
    {

        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string ProductID { get; set; }

        [JsonProperty("pcode")]
        public string ProductCode { get; set; }

        [JsonProperty("pname")]
        public string ProductName { get; set; }
    }
}
