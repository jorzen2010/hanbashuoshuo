using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hanbashuoshuo.Startup))]
namespace hanbashuoshuo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
