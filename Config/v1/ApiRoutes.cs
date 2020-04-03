using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreJWTAuth.Config.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Products
        {
            public const string Retrieve = Base + "/products/{productID}";

            public const string GetAllProducts = Base + "/products";
            
            public const string Save = Base + "/products";

            public const string Update = Base + "/products/{productID}";

            public const string Delete = Base + "/products/{productID}";
        }
    }
}
