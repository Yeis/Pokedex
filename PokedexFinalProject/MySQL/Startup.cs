using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySQL.Startup))]
namespace MySQL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
