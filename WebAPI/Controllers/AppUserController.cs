using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebModels;
using WebModels.Entities;
using WebModels.ResponseModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private AppDbContext _dbContext { get; set; }
        public AppUserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<UserResponseModelForLogIn> GetUser()
        {
            return _dbContext.ApplicationUser.Select(x=>new UserResponseModelForLogIn
            {
                HoTen = x.HoTen,
                UserName =x.UserName,
                Id = x.Id
            }).ToList();        
        }
    }
}
