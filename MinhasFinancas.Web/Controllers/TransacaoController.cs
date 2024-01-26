using MinhasFinancas.Web.Data;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class TransacaoController : Controller
    {
        private MinhasFinancasWebContext db = new MinhasFinancasWebContext();

        // GET: Transacao
        public async Task<ActionResult> Index()
        {
            return View(await db.TransacaoViewModels.ToListAsync());
        }

        // GET: Transacao/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransacaoViewModel transacaoViewModel = await db.TransacaoViewModels.FindAsync(id);
            if (transacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(transacaoViewModel);
        }

        // GET: Transacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PapelId,ValorUnt,Quantidade,Data,TipoTransacao,Descricao,Ativo")] TransacaoViewModel transacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                transacaoViewModel.Id = Guid.NewGuid();
                db.TransacaoViewModels.Add(transacaoViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transacaoViewModel);
        }

        // GET: Transacao/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransacaoViewModel transacaoViewModel = await db.TransacaoViewModels.FindAsync(id);
            if (transacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(transacaoViewModel);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PapelId,ValorUnt,Quantidade,Data,TipoTransacao,Descricao,Ativo")] TransacaoViewModel transacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacaoViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transacaoViewModel);
        }

        // GET: Transacao/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransacaoViewModel transacaoViewModel = await db.TransacaoViewModels.FindAsync(id);
            if (transacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(transacaoViewModel);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TransacaoViewModel transacaoViewModel = await db.TransacaoViewModels.FindAsync(id);
            db.TransacaoViewModels.Remove(transacaoViewModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
