using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class PapelController : Controller
    {
        IPapelService _papelService;
        IMapper _mapper;

        public PapelController(IPapelService papelService,
                               IMapper mapper)
        {
            _papelService = papelService;
            _mapper = mapper;
        }

        // GET: Papel
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<List<PapelViewModel>>(await _papelService.Get()));
        }

        // GET: Papel/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            PapelViewModel papelViewModel = _mapper.Map<PapelViewModel>(await _papelService.GetById(id));
            if (papelViewModel == null)
            {
                return HttpNotFound();
            }
            return View(papelViewModel);
        }

        // GET: Papel/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Papel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PapelViewModel papelViewModel)
        {
            if (!ModelState.IsValid) return View(papelViewModel);

            Papel obj = _mapper.Map<Papel>(papelViewModel);
            await _papelService.Add(obj);

            //if (!OperacaoValida()) return View(DividendoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Papel/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            PapelViewModel papelViewModel = _mapper.Map<PapelViewModel>(await _papelService.GetById(id));
            if (papelViewModel == null)
            {
                return HttpNotFound();
            }

            return View(papelViewModel);
        }

        // POST: Papel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, PapelViewModel papelViewModel)
        {
            if (id != papelViewModel.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(papelViewModel);

            Papel papel = _mapper.Map<Papel>(papelViewModel);
            await _papelService.Update(papel);

            //if (!OperacaoValida()) return View(await ObterFornecedorProdutosEndereco(id));

            return RedirectToAction("Index");
        }

        // GET: Papel/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            PapelViewModel papelViewModel = _mapper.Map<PapelViewModel>(await _papelService.GetById(id));
            if (papelViewModel == null)
            {
                return HttpNotFound();
            }

            return View(papelViewModel);
        }

        // POST: Papel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PapelViewModel papelViewModel = _mapper.Map<PapelViewModel>(await _papelService.GetById(id));

            if (papelViewModel == null) return HttpNotFound();

            await _papelService.DeleteById(id);

            //if (!OperacaoValida()) return View(fornecedor);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _papelService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
