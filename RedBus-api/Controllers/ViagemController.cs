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

        // GET: api/Viagems
        public IQueryable<Viagem> GetViagem()
        {
            return db.Viagem;
        }

        // GET: api/Viagems/5
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

        // PUT: api/Viagems/5
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

        // POST: api/Viagems
        [ResponseType(typeof(Viagem))]
        public IHttpActionResult PostViagem(Viagem viagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

        // DELETE: api/Viagems/5
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