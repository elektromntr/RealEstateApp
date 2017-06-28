using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dyplomowaApka00.Startup))]
namespace dyplomowaApka00
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
