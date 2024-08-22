using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DbProject.Startup))]
namespace DbProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
