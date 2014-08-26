using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdeboaasWeb.Startup))]
namespace IdeboaasWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
