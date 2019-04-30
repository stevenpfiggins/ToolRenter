using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToolRenter.MVC.Startup))]
namespace ToolRenter.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
