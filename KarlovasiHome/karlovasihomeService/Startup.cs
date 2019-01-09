using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(karlovasihomeService.Startup))]

namespace karlovasihomeService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}