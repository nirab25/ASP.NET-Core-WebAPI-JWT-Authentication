using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreJWTAuth.Models.v1.Requests
{
    public class UpdateProductRequest
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
