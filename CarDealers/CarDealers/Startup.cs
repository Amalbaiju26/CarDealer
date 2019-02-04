using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealers.Startup))]
namespace CarDealers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
