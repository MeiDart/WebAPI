using WebBusiness;
using WebBusiness.AuthService;

namespace WebAPI.Extensions
{
    public static class ServicesRegisterExtensions
    {
        public static void ServicesRegister(this IServiceCollection services)
        {
            services.AddTransient<IAuthService,AuthService>();
        }
    }
}
