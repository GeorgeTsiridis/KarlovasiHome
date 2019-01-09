using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KarlovasiHomeService.Startup))]

namespace KarlovasiHomeService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}