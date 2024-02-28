using MinhasFinancas.Service.Core;
using System.Threading.Tasks;
using System.Web;

namespace MinhasFinancas.Service.Configuracao
{
    public interface IConfiguracaoService
    {
        Task ImportarExcelB3(HttpPostedFileBase fileB3);
    }
}
