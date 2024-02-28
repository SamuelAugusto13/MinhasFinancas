using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Papel;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class PapelController : BaseController
    {
        IPapelService _papelService;
        IMapper _mapper;

        public PapelController(IPapelService papelService,
                               INotificador notificador,  
                               IMapper mapper) : base(notificador)
        {
            _papelService = papelService;
            _mapper = mapper;
        }

        // GET: Papel
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<List<PapelViewModel>>(await _papelService.Get()));

            //List<PapelViewModel> lst = _mapper.Map<List<PapelViewModel>>(await _papelService.Get(includeProperties: "Transacao,Dividendo"));

            //double totalSaldo = 0;
            //double totalSaldoAtual = 0;
            //lst.ForEach(f =>
            //{
            //    //Calculo de preços
            //    f.QuantidadeTotal = f.Transacao.Sum(x => x.TipoTransacao == Infra.Data.Models.Enums.TipoTransacao.Compra ? x.Quantidade : x.Quantidade * -1);

            //    f.PrecoMedio = f.QuantidadeTotal == 0 ? 0 : f.Transacao.Sum(x => x.Quantidade * x.ValorUnt) / f.QuantidadeTotal;

            //    f.TotalSaldo = f.QuantidadeTotal * f.PrecoMedio;
            //    totalSaldo += f.TotalSaldo;

            //    f.TotalSaldoAtual = f.CotacaoAtual * f.QuantidadeTotal;
            //    totalSaldoAtual += f.TotalSaldoAtual;

            //    f.Valorizacao = Math.Round(((f.TotalSaldoAtual / f.TotalSaldo) * 100) - 100, 2);
            //    f.GanhoUnt = Math.Round(f.CotacaoAtual - f.PrecoMedio, 2);
            //    f.GanhoTotal = (f.CotacaoAtual - f.PrecoMedio) * f.QuantidadeTotal;

            //    // Dividendos
            //    f.DividendosTotal = f.Dividendo.Sum(x => x.ValorRecebido);
            //    f.PercentDividendos = Math.Round((f.DividendosTotal / f.TotalSaldo) * 100, 2);

            //    // 2 casas decimais
            //    f.PrecoMedio = Math.Round(f.PrecoMedio, 2);
            //    f.TotalSaldo = Math.Round(f.TotalSaldo, 2);
            //    f.TotalSaldoAtual = Math.Round(f.TotalSaldoAtual, 2);
            //    f.DividendosTotal = Math.Round(f.DividendosTotal, 2);
            //});

            //ViewBag.totalSaldo = Math.Round(totalSaldo, 2);
            //ViewBag.totalSaldoAtual = Math.Round(totalSaldoAtual, 2);
            //ViewBag.deltaPercentTotal = Math.Round(((totalSaldoAtual / totalSaldo) * 100) - 100, 2);



            //return View(lst);
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

            if (!OperacaoValida()) return View(papelViewModel);

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

            if (!OperacaoValida()) return View(_mapper.Map<PapelViewModel>(await _papelService.GetById(id)));

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

            if (!OperacaoValida()) return View(papelViewModel);

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
