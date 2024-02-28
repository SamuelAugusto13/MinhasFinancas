using MinhasFinancas.Service.Configuracao;
using MinhasFinancas.Service.Core.Notificacao;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class ConfiguracaoController : BaseController
    {
        IConfiguracaoService _configuracaoService;

        public ConfiguracaoController(IConfiguracaoService configuracaoService, INotificador notificador) : base(notificador)
        {
            _configuracaoService = configuracaoService;
        }

        // GET: Configuracao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Importar(HttpPostedFileBase fileB3)
        {
            // Verifica se o arquivo é nulo
            if (fileB3 == null || fileB3.ContentLength == 0)
            {
                throw new ArgumentException("O arquivo é nulo ou vazio.");
            }

            // Verifica se o arquivo é do tipo Excel
            if (!fileB3.ContentType.Equals("application/vnd.ms-excel") &&
                !fileB3.ContentType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                throw new ArgumentException("O arquivo não é do tipo Excel.");
            }

            _configuracaoService.ImportarExcelB3(fileB3);

            return RedirectToAction("Index");
        }
    }
}