using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaBackEnd_07_17.Models;
using ProvaBackEnd_07_17.Models.Noticias;

namespace ProvaBackEnd_07_17.Controllers.Noticias
{
    [Authorize]
    public class NoticiaItensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NoticiaItens
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var noticiaItems = db.NoticiaItens.Include(n => n.Noticia).Include(n => n.Tipo);
            return View(await noticiaItems.ToListAsync());
        }

        // GET: NoticiaItens/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticiaItem noticiaItem = await db.NoticiaItens.FindAsync(id);
            if (noticiaItem == null)
            {
                return HttpNotFound();
            }
            return View(noticiaItem);
        }

        // GET: NoticiaItens/Create
        public ActionResult Create()
        {
            ViewBag.NoticiaId = new SelectList(db.Noticias, "Id", "Titulo");
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Descricao");
            return View();
        }

        // POST: NoticiaItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TipoId,NoticiaId,Valor")] NoticiaItem noticiaItem)
        {
            if (ModelState.IsValid)
            {
                db.NoticiaItens.Add(noticiaItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.NoticiaId = new SelectList(db.Noticias, "Id", "Titulo", noticiaItem.NoticiaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Descricao", noticiaItem.TipoId);
            return View(noticiaItem);
        }

        // GET: NoticiaItens/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticiaItem noticiaItem = await db.NoticiaItens.FindAsync(id);
            if (noticiaItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoticiaId = new SelectList(db.Noticias, "Id", "Titulo", noticiaItem.NoticiaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Descricao", noticiaItem.TipoId);
            return View(noticiaItem);
        }

        // POST: NoticiaItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TipoId,NoticiaId,Valor")] NoticiaItem noticiaItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticiaItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NoticiaId = new SelectList(db.Noticias, "Id", "Titulo", noticiaItem.NoticiaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Descricao", noticiaItem.TipoId);
            return View(noticiaItem);
        }

        // GET: NoticiaItens/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticiaItem noticiaItem = await db.NoticiaItens.FindAsync(id);
            if (noticiaItem == null)
            {
                return HttpNotFound();
            }
            return View(noticiaItem);
        }

        // POST: NoticiaItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NoticiaItem noticiaItem = await db.NoticiaItens.FindAsync(id);
            db.NoticiaItens.Remove(noticiaItem);
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
