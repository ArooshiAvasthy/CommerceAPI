using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewCommerceClient.Startup))]
namespace NewCommerceClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
