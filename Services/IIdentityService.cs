using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreJWTAuth.Models;
using DotNetCoreJWTAuth.Models.v1.Requests;

namespace DotNetCoreJWTAuth.Services
{
    public interface IIdentityService
    {
        public Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request);
    }
}
