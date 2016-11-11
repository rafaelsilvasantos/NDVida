using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NDVida_Site.Startup))]
namespace NDVida_Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
