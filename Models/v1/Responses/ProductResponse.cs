﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreJWTAuth.Models.v1.Responses
{
    public class ProductResponse
    {
        public Guid ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
