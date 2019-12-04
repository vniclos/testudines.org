using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testudines.Startup))]
namespace testudines
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            cls.ClsGlobal.FncDirBuidlGlobal();
            ConfigureAuth(app);
        }
    }
}
