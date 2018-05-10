using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SwaggerRestaurant.Startup))]

namespace SwaggerRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
