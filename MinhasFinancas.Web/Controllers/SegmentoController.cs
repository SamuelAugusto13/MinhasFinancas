using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Service.Segmento;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class SegmentoController : BaseController
    {
        ISegmentoService _segmentoService;
        IPapelService _papelService;
        IMapper _mapper;

        public SegmentoController(ISegmentoService segmentoService,
                                  IPapelService papelService,
                                  INotificador notificador,
                                  IMapper mapper) : base(notificador)
        {
            _segmentoService = segmentoService;
            _papelService = papelService;
            _mapper = mapper;
        }

        // GET: Segmento
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<List<SegmentoViewModel>>(await _segmentoService.Get()));
        }

        // GET: Segmento/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            SegmentoViewModel segmentoViewModel = _mapper.Map<SegmentoViewModel>(await _segmentoService.GetById(id));
            if (segmentoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(segmentoViewModel);
        }

        // GET: Segmento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Segmento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SegmentoViewModel segmentoViewModel)
        {
            if (!ModelState.IsValid) return View(segmentoViewModel);

            Segmento obj = _mapper.Map<Segmento>(segmentoViewModel);
            await _segmentoService.Add(obj);

            if (!OperacaoValida()) return View(segmentoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Segmento/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            SegmentoViewModel segmentoViewModel = _mapper.Map<SegmentoViewModel>(await _segmentoService.GetById(id));
            if (segmentoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(segmentoViewModel);
        }

        // POST: Segmento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, SegmentoViewModel segmentoViewModel)
        {
            if (id != segmentoViewModel.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(segmentoViewModel);

            Segmento segmento = _mapper.Map<Segmento>(segmentoViewModel);
            await _segmentoService.Update(segmento);

            if (!OperacaoValida()) return View(_mapper.Map<PapelViewModel>(await _papelService.GetById(id)));

            return View(segmentoViewModel);
        }

        // GET: Segmento/Delete/5

        public async Task<ActionResult> Delete(Guid id)
        {
            SegmentoViewModel segmentoViewModel = _mapper.Map<SegmentoViewModel>(await _segmentoService.GetById(id));
            if (segmentoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(segmentoViewModel);
        }

        // POST: Segmento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SegmentoViewModel segmentoViewModel = _mapper.Map<SegmentoViewModel>(await _segmentoService.GetById(id));

            if (segmentoViewModel == null) return HttpNotFound();

            await _segmentoService.DeleteById(id);

            if (!OperacaoValida()) return View(segmentoViewModel);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _segmentoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
