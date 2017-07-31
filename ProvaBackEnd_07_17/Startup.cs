using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProvaBackEnd_07_17.Startup))]
namespace ProvaBackEnd_07_17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
