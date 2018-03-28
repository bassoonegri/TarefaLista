using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TarefaLista.Startup))]
namespace TarefaLista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
