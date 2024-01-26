using MinhasFinancas.Web.Data;
using MinhasFinancas.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinhasFinancas.Web.Controllers
{
    public class SegmentoController : Controller
    {
        private MinhasFinancasWebContext db = new MinhasFinancasWebContext();

        // GET: Segmento
        public async Task<ActionResult> Index()
        {
            return View(await db.SegmentoViewModels.ToListAsync());
        }

        // GET: Segmento/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SegmentoViewModel segmentoViewModel = await db.SegmentoViewModels.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Descricao,Ativo")] SegmentoViewModel segmentoViewModel)
        {
            if (ModelState.IsValid)
            {
                segmentoViewModel.Id = Guid.NewGuid();
                db.SegmentoViewModels.Add(segmentoViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(segmentoViewModel);
        }

        // GET: Segmento/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SegmentoViewModel segmentoViewModel = await db.SegmentoViewModels.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Descricao,Ativo")] SegmentoViewModel segmentoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmentoViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(segmentoViewModel);
        }

        // GET: Segmento/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SegmentoViewModel segmentoViewModel = await db.SegmentoViewModels.FindAsync(id);
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
            SegmentoViewModel segmentoViewModel = await db.SegmentoViewModels.FindAsync(id);
            db.SegmentoViewModels.Remove(segmentoViewModel);
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
