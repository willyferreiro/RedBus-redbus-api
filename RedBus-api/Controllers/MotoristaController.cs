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
    public class MotoristaController : ApiController
    {
        private redbusdb db = new redbusdb();

        // GET: api/Motorista
        public IQueryable<Motorista> GetMotorista()
        {
            return db.Motorista;
        }

        // GET: api/Motorista/5
        [ResponseType(typeof(Motorista))]
        public IHttpActionResult GetMotorista(long id)
        {
            Motorista motorista = db.Motorista.Find(id);
            if (motorista == null)
            {
                return NotFound();
            }

            return Ok(motorista);
        }

        // PUT: api/Motorista/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotorista(long id, Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motorista.idMotorista)
            {
                return BadRequest();
            }

            db.Entry(motorista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(id))
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

        // POST: api/Motorista
        [ResponseType(typeof(Motorista))]
        public IHttpActionResult PostMotorista(Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motorista.Add(motorista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MotoristaExists(motorista.idMotorista))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motorista.idMotorista }, motorista);
        }

        // DELETE: api/Motorista/5
        [ResponseType(typeof(Motorista))]
        public IHttpActionResult DeleteMotorista(long id)
        {
            Motorista motorista = db.Motorista.Find(id);
            if (motorista == null)
            {
                return NotFound();
            }

            db.Motorista.Remove(motorista);
            db.SaveChanges();

            return Ok(motorista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotoristaExists(long id)
        {
            return db.Motorista.Count(e => e.idMotorista == id) > 0;
        }
    }
}