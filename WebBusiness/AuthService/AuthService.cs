using Microsoft.AspNetCore.Identity;
using WebCommon.Constants;
using WebModels;
using WebModels.Entities;
using WebModels.RequestModels.AuthRequestModel;

namespace WebBusiness.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        public AuthService(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = appDbContext;
        }
        public async Task Login(UserModel userInfo)
        {
            var currentUser = await _userManager.FindByNameAsync(userInfo.UserName);
            if (currentUser == null)
            {
                throw new Exception(Constants.Commons.USER_NOT_EXIST);
            }
            if(await _userManager.CheckPasswordAsync(currentUser, userInfo.Password))
            {
                var rolesUser = _userManager.GetRolesAsync(currentUser);
                
                //var gerenrateToken()
            }
        }

        public async Task<IdentityResult> Register(UserModel userInfo)
        {
            if(_userManager.FindByNameAsync(userInfo.UserName) != null)
            {
                throw new Exception(Constants.Commons.USER_ALREADY_EXIST);
            }
            var newUser = new UserAccount
            {
                UserName = userInfo.UserName,
                Email = userInfo.Email,
                HoTen = userInfo.HoTen, 
            };
            var res = await _userManager.CreateAsync(newUser, userInfo.Password);
            return res;
        }

    }
}
