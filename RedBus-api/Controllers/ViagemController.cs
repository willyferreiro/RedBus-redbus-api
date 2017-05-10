using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RedBus_api.Models;

namespace RedBus_api.Controllers
{
    public class ViagemController : ApiController
    {
        private redbusdb db = new redbusdb();
       
        // GET: api/Viagem/5
        [ResponseType(typeof(Viagem))]
        public IHttpActionResult GetViagem(long id)
        {
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return NotFound();
            }

            return Ok(viagem);
        }

        // PUT: api/Viagem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViagem(long id, Viagem viagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viagem.idViagem)
            {
                return BadRequest();
            }

            db.Entry(viagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Viagem
        [ResponseType(typeof(Viagem))]
        public IHttpActionResult PostViagem(Viagem viagem)
        {
            if (viagem.Motorista != null)
                db.Entry(viagem.Motorista).State = EntityState.Modified;
            
            foreach (Viagem_Filho vf in viagem.Viagem_Filho)
            {
                db.Entry(vf).State = EntityState.Added;
                if (vf.Filho != null)
                    db.Entry(vf.Filho).State = EntityState.Modified;
            }

            
            /*ToDo */
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Viagem.Add(viagem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ViagemExists(viagem.idViagem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = viagem.idViagem }, viagem);
        }

        // DELETE: api/Viagem/5
        [ResponseType(typeof(Viagem))]
        public IHttpActionResult DeleteViagem(long id)
        {
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return NotFound();
            }

            db.Viagem.Remove(viagem);
            db.SaveChanges();

            return Ok(viagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViagemExists(long id)
        {
            return db.Viagem.Count(e => e.idViagem == id) > 0;
        }
    }
}