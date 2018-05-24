using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaptopWeb.Startup))]
namespace LaptopWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
