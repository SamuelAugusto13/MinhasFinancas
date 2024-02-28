using ClosedXML.Excel;
using MinhasFinancas.Service.Core;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Dividendo;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Service.Transacao;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MinhasFinancas.Service.Configuracao
{
    public class ConfiguracaoService : BaseService, IConfiguracaoService
    {
        IPapelService _papelService;
        ITransacaoService _transacaoService;
        IDividendoService _dividendoService;

        public ConfiguracaoService(INotificador notificador,
                                      IPapelService papelServic,
                                      ITransacaoService transacaoService,
                                      IDividendoService dividendoService) : base(notificador)
        {
            _papelService = papelServic;
            _transacaoService = transacaoService;
            _dividendoService = dividendoService;
        }

        public Task ImportarExcelB3(HttpPostedFileBase fileB3)
        {
            // Abre o arquivo Excel
            using (var stream = fileB3.InputStream)
            {
                using (var workbook = new XLWorkbook(stream))
                {
                    var planilha = workbook.Worksheets.First();
                    var totalLinhas = planilha.Rows().Count();

                    for (int i = 2; i < totalLinhas; i++)
                    {
                        var nomeAcao = planilha.Cell($"D{i}").Value.ToString();
                    }

                }
            }

            return Task.CompletedTask;
        }
    }
}