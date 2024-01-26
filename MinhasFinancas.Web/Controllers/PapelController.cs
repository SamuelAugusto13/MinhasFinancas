using MinhasFinancas.Web.Data;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class PapelController : Controller
    {
        private MinhasFinancasWebContext db = new MinhasFinancasWebContext();

        // GET: Papel
        public async Task<ActionResult> Index()
        {
            return View(await db.PapelViewModels.ToListAsync());
        }

        // GET: Papel/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PapelViewModel papelViewModel = await db.PapelViewModels.FindAsync(id);
            if (papelViewModel == null)
            {
                return HttpNotFound();
            }
            return View(papelViewModel);
        }

        // GET: Papel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Codigo,Nome,TipoPapel,CotacaoAtual,Descricao,Ativo")] PapelViewModel papelViewModel)
        {
            if (ModelState.IsValid)
            {
                papelViewModel.Id = Guid.NewGuid();
                db.PapelViewModels.Add(papelViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(papelViewModel);
        }

        // GET: Papel/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PapelViewModel papelViewModel = await db.PapelViewModels.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Codigo,Nome,TipoPapel,CotacaoAtual,Descricao,Ativo")] PapelViewModel papelViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(papelViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(papelViewModel);
        }

        // GET: Papel/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PapelViewModel papelViewModel = await db.PapelViewModels.FindAsync(id);
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
            PapelViewModel papelViewModel = await db.PapelViewModels.FindAsync(id);
            db.PapelViewModels.Remove(papelViewModel);
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
