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
    public class TiposController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tipos
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await db.Tipos.ToListAsync());
        }

        // GET: Tipos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = await db.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // GET: Tipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Tipos.Add(tipo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        // GET: Tipos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = await db.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo);
        }

        // GET: Tipos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = await db.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tipo tipo = await db.Tipos.FindAsync(id);
            db.Tipos.Remove(tipo);
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
