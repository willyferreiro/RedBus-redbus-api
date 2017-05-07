using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedBus_api.Models;

namespace RedBus_api.Controllers
{
    public class ViagemsController : Controller
    {
        private redbusdb db = new redbusdb();

        // GET: Viagems
        public ActionResult Index()
        {
            var viagem = db.Viagem.Include(v => v.Motorista);
            return View(viagem.ToList());
        }

        // GET: Viagems/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // GET: Viagems/Create
        public ActionResult Create()
        {
            ViewBag.idMotorista = new SelectList(db.Motorista, "idUsuario", "idUsuario");
            return View();
        }

        // POST: Viagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idViagem,idMotorista,dataInicioViagem,dataFimViagem,posicaoInicio_latitude,posicaoInicio_longitude,posicaoFim_latitude,posicaoFim_longitude,statusViagem")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Viagem.Add(viagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMotorista = new SelectList(db.Motorista, "idUsuario", "idUsuario", viagem.idMotorista);
            return View(viagem);
        }

        // GET: Viagems/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMotorista = new SelectList(db.Motorista, "idUsuario", "idUsuario", viagem.idMotorista);
            return View(viagem);
        }

        // POST: Viagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idViagem,idMotorista,dataInicioViagem,dataFimViagem,posicaoInicio_latitude,posicaoInicio_longitude,posicaoFim_latitude,posicaoFim_longitude,statusViagem")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMotorista = new SelectList(db.Motorista, "idUsuario", "idUsuario", viagem.idMotorista);
            return View(viagem);
        }

        // GET: Viagems/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // POST: Viagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Viagem viagem = db.Viagem.Find(id);
            db.Viagem.Remove(viagem);
            db.SaveChanges();
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
