using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBusiness.AuthService;
using WebCommon.Constants;
using WebModels;
using WebModels.Entities;
using WebModels.RequestModels.AuthRequestModel;
using WebModels.ResponseModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AppUserController(IAuthService authService)
        {
            _authService = authService;
        }
      

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userinfo)
        {
            var res = await _authService.Register(userinfo);
            if(res.Succeeded)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
