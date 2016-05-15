using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokedexFinalProject.Startup))]
namespace PokedexFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
