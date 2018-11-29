using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agentstvo.Startup))]
namespace Agentstvo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
