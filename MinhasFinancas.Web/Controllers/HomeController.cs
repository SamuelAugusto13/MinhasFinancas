using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class HomeController : Controller
    {
        IPapelService _papelService;
        IMapper _mapper;

        public HomeController(IPapelService papelService, IMapper mapper)
        {
            _papelService = papelService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            //List<PapelViewModel> papelList = _mapper.Map<List<PapelViewModel>>(await _papelService.Get());

            Papel obj = new Papel()
            {
                Id = Guid.NewGuid(),
                Codigo = "BBAS3",
                Nome = "BB",
                CotacaoAtual = 0,
                Ativo = true
            };

            PapelViewModel obj2 = new PapelViewModel()
            {
                Id = Guid.NewGuid(),
                Codigo = "BBAS3",
                Nome = "BB",
                CotacaoAtual = 0,
                Ativo = true
            };

            PapelViewModel papel = _mapper.Map<PapelViewModel>(obj);
            Papel papel2 = _mapper.Map<Papel>(obj2);

            //IPapelService papelService = new PapelService();
            //papelService.Add(obj);



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}