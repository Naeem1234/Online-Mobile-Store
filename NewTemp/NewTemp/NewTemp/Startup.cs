using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewTemp.Startup))]
namespace NewTemp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
