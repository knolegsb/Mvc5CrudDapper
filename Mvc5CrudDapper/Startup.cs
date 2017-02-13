using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5CrudDapper.Startup))]
namespace Mvc5CrudDapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
