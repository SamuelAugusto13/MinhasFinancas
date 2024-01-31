using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Dividendo;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class DividendoController : BaseController
    {
        IDividendoService _dividendoService;
        IPapelService _papelService;
        IMapper _mapper;

        public DividendoController(IDividendoService dividendoService, 
                                   IPapelService papelService,
                                   INotificador notificador,
                                   IMapper mapper) : base(notificador)
        {
            _dividendoService = dividendoService;
            _papelService = papelService;
            _mapper = mapper;
        }


        // GET: Dividendo
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<List<DividendoViewModel>>(await _dividendoService.Get()));
        }

        // GET: Dividendo/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            DividendoViewModel dividendoViewModel = _mapper.Map<DividendoViewModel> (await _dividendoService.GetById(id));

            if (dividendoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dividendoViewModel);
        }

        // GET: Dividendo/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var dividendoViewModel = await PopularPapeis(new DividendoViewModel());

            return View(dividendoViewModel);
        }

        // POST: Dividendo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DividendoViewModel dividendoViewModel)
        {
            if (!ModelState.IsValid) return View(dividendoViewModel);

            Dividendo obj = _mapper.Map<Dividendo>(dividendoViewModel);
            await _dividendoService.Add(obj);

            if (!OperacaoValida()) return View(dividendoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Dividendo/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            DividendoViewModel dividendoViewModel = _mapper.Map<DividendoViewModel>(await _dividendoService.GetById(id));

            if (dividendoViewModel == null)
            {
                return HttpNotFound();
            }
            dividendoViewModel = await PopularPapeis(new DividendoViewModel());

            return View(dividendoViewModel);
        }

        // POST: Dividendo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, DividendoViewModel dividendoViewModel)
        {
            if (id != dividendoViewModel.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(dividendoViewModel);

            Dividendo dividendo = _mapper.Map<Dividendo>(dividendoViewModel);

            await _dividendoService.Update(dividendo);

            if (!OperacaoValida()) return View(_mapper.Map<DividendoViewModel>(await _dividendoService.GetById(id)));

            return RedirectToAction("Index");
        }

        // GET: Dividendo/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            DividendoViewModel dividendoViewModel = _mapper.Map<DividendoViewModel>(await _dividendoService.GetById(id));

            if (dividendoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dividendoViewModel);
        }

        // POST: Dividendo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            DividendoViewModel dividendoViewModel = _mapper.Map<DividendoViewModel>(await _dividendoService.GetById(id));

            if (dividendoViewModel == null)
            {
                return HttpNotFound();
            }

            await _dividendoService.DeleteById(id);

            if (!OperacaoValida()) return View(dividendoViewModel);

            return RedirectToAction("Index");
        }

        private async Task<DividendoViewModel> PopularPapeis(DividendoViewModel dividendo)
        {
            dividendo.Papeis = _mapper.Map<List<PapelViewModel>>(await _papelService.Get());
            return dividendo;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dividendoService.Dispose();
                _papelService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
