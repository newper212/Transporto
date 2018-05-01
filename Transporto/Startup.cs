using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transporto.Startup))]
namespace Transporto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
