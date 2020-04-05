using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreJWTAuth.Models.v1.Requests
{
    public class UserLoginRequest
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
