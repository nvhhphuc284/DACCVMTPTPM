using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VSG.Startup))]
namespace VSG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
