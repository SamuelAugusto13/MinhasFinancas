using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class HomeController : BaseController
    {
        IPapelService _papelService;
        IMapper _mapper;

        public HomeController(IPapelService papelService, 
                              INotificador notificador,
                              IMapper mapper) : base(notificador)
        {
            _papelService = papelService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
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