using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedBus_api.DTOs;
using RedBus_api.Models;

namespace RedBus_api.Views
{
    public class ViagemsController : Controller
    {
        private redbusdb db = new redbusdb();

        // GET: Viagems
        public ActionResult Index()
        {

            Viagem viagem = new Viagem();
            viagem.idMotorista = 1;
            viagem.dataInicioViagem = DateTime.Now;
            viagem.statusViagem = (int)StatusViagem.Andamento;
            viagem.posicaoInicio_latitude = 2;
            viagem.posicaoInicio_longitude = 3;

            Filho filho1 = new Filho();
            filho1.idFilho = 1;
            filho1.nome = "filho 1";
            filho1.idResponsavel = 2;
            filho1.idMotorista = 1;
            filho1.emViagem = true;

            Filho filho2 = new Filho();
            filho2.idFilho = 2;
            filho2.nome = "filho 2";
            filho2.idResponsavel = 2;
            filho2.idMotorista = 1;
            filho2.emViagem = true;

            ViagemFilho viagemFilho1 = new ViagemFilho();
            viagemFilho1.idFilho = filho1.idFilho;
            viagemFilho1.Filho = filho1;

            ViagemFilho viagemFilho2 = new ViagemFilho();
            viagemFilho2.idFilho = filho2.idFilho;
            viagemFilho2.Filho = filho2;

            viagem.ViagemFilho.Add(viagemFilho1);
            viagem.ViagemFilho.Add(viagemFilho2);

            redbusdb db = new redbusdb();

            db.Entry(viagemFilho1).State = EntityState.Added;
            db.Entry(viagemFilho2).State = EntityState.Added;

            db.Entry(filho1).State = EntityState.Modified;
            db.Entry(filho2).State = EntityState.Modified;

            if (!ModelState.IsValid)
            {
                throw new Exception(ModelState.ToString());
            }

            db.Viagem.Add(viagem);
            //db.SaveChanges();

            //viagem.ViagemFilho.Add(viagemFilho1);
            //viagem.ViagemFilho.Add(viagemFilho2);

            db.SaveChanges();

            var viagem2 = db.Viagem.Include(v => v.Motorista);
            return View(viagem2.ToList());
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
