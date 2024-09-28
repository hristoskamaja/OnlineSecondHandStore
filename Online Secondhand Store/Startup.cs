using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Secondhand_Store.Startup))]
namespace Online_Secondhand_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
