using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteBanLaptop.Startup))]
namespace WebSiteBanLaptop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
