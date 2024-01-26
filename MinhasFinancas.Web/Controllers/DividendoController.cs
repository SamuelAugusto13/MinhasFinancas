using MinhasFinancas.Web.Data;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class DividendoController : Controller
    {
        private MinhasFinancasWebContext db = new MinhasFinancasWebContext();

        // GET: Dividendo
        public async Task<ActionResult> Index()
        {
            return View(await db.DividendoViewModels.ToListAsync());
        }

        // GET: Dividendo/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DividendoViewModel dividendoViewModel = await db.DividendoViewModels.FindAsync(id);
            if (dividendoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dividendoViewModel);
        }

        // GET: Dividendo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dividendo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PapelId,ValorRecebido,Quantidade,Data,Descricao,Ativo")] DividendoViewModel dividendoViewModel)
        {
            if (ModelState.IsValid)
            {
                dividendoViewModel.Id = Guid.NewGuid();
                db.DividendoViewModels.Add(dividendoViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dividendoViewModel);
        }

        // GET: Dividendo/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DividendoViewModel dividendoViewModel = await db.DividendoViewModels.FindAsync(id);
            if (dividendoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(dividendoViewModel);
        }

        // POST: Dividendo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PapelId,ValorRecebido,Quantidade,Data,Descricao,Ativo")] DividendoViewModel dividendoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dividendoViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dividendoViewModel);
        }

        // GET: Dividendo/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DividendoViewModel dividendoViewModel = await db.DividendoViewModels.FindAsync(id);
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
            DividendoViewModel dividendoViewModel = await db.DividendoViewModels.FindAsync(id);
            db.DividendoViewModels.Remove(dividendoViewModel);
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
