using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuotingSystem.Startup))]
namespace QuotingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
