using MinhasFinancas.Infra.Data;
using MinhasFinancas.Service.Core;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Dividendo;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Service.Segmento;
using MinhasFinancas.Service.Transacao;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace MinhasFinancas.Web.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped
            // Uma única instância por request

            container.Register<AppDbContext>(Lifestyle.Scoped);
            container.Register<IPapelService, PapelService>(Lifestyle.Scoped);
            container.Register<IDividendoService, DividendoService>(Lifestyle.Scoped);
            container.Register<ITransacaoService, TransacaoService>(Lifestyle.Scoped);
            container.Register<ISegmentoService, SegmentoService>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            DependencyInjectionConfigService.InitializeContainer(container);

            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}