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
    public class NoticiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Noticias
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var noticias = db.Noticias.Include(n => n.Categoria);
            return View(await noticias.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = await db.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        // GET: Noticias/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Descricao");
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Titulo,URL,CategoriaId")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Noticias.Add(noticia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Descricao", noticia.CategoriaId);
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = await db.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Descricao", noticia.CategoriaId);
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Titulo,URL,CategoriaId")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Descricao", noticia.CategoriaId);
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = await db.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Noticia noticia = await db.Noticias.FindAsync(id);
            db.Noticias.Remove(noticia);
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
