using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLaptop3.Startup))]
namespace WebLaptop3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
