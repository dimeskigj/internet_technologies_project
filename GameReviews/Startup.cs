using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameReviews.Startup))]
namespace GameReviews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
