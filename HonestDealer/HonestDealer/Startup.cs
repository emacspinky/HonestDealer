using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HonestDealer.Startup))]
namespace HonestDealer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
