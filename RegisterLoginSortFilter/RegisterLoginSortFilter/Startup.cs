using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegisterLoginSortFilter.Startup))]
namespace RegisterLoginSortFilter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
