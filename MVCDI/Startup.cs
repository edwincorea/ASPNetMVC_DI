using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDI.Startup))]
namespace MVCDI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
