using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoogleOAuth2.Startup))]
namespace GoogleOAuth2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
