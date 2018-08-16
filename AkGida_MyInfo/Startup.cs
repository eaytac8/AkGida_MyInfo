using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AkGida_MyInfo.Startup))]
namespace AkGida_MyInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
