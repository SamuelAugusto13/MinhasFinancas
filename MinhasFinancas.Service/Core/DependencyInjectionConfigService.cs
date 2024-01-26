using MinhasFinancas.Repository.Dividendo;
using MinhasFinancas.Repository.Papel;
using MinhasFinancas.Repository.Segmento;
using MinhasFinancas.Repository.Transacao;
using SimpleInjector;

namespace MinhasFinancas.Service.Core
{
    public class DependencyInjectionConfigService
    {
        public static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped
            // Uma única instância por request

            container.Register<IDividendoRepository, DividendoRepository>(Lifestyle.Scoped);
            container.Register<IPapelRepository, PapelRepository>(Lifestyle.Scoped);
            container.Register<ISegmentoRepository, SegmentoRepository>(Lifestyle.Scoped);
            container.Register<ITransacaoRepository, TransacaoRepository>(Lifestyle.Scoped);

        }
    }
}