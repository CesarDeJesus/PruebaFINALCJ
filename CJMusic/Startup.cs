using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CJMusic.Startup))]
namespace CJMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
