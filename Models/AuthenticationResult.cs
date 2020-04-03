using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreJWTAuth.Models
{
    public class AuthenticationResult
    {
        public string Token { set; get; }
        public bool Success { set; get; }
        public IEnumerable<string> Errors { set; get; }
    }
}
