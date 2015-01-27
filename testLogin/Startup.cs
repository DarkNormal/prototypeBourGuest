using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testLogin.Startup))]
namespace testLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
