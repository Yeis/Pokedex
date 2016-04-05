using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pokedex.Startup))]
namespace Pokedex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
