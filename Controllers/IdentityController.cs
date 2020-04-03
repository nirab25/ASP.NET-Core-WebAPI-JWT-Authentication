using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreJWTAuth.Services;
using DotNetCoreJWTAuth.Config.v1;
using DotNetCoreJWTAuth.Models.v1.Requests;
using DotNetCoreJWTAuth.Models.v1.Responses;

namespace DotNetCoreJWTAuth.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request);

            if(!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse 
            {
                Token = authResponse.Token
            });
        }
    }
}