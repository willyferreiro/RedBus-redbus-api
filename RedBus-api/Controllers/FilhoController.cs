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
    public class FilhoController : ApiController
    {
        private redbusdb db = new redbusdb();

        // GET: api/Filho
        public IQueryable<Filho> GetFilho()
        {
            return db.Filho;
        }

        // GET: api/Filho/5
        [ResponseType(typeof(Filho))]
        public IHttpActionResult GetFilho(long id)
        {
            Filho filho = db.Filho.Find(id);
            if (filho == null)
            {
                return NotFound();
            }

            return Ok(filho);
        }

        // PUT: api/Filho/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilho(long id, Filho filho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filho.idFilho)
            {
                return BadRequest();
            }

            db.Entry(filho).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilhoExists(id))
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

        // POST: api/Filho
        [ResponseType(typeof(Filho))]
        public IHttpActionResult PostFilho(Filho filho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filho.Add(filho);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FilhoExists(filho.idFilho))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = filho.idFilho }, filho);
        }

        // DELETE: api/Filho/5
        [ResponseType(typeof(Filho))]
        public IHttpActionResult DeleteFilho(long id)
        {
            Filho filho = db.Filho.Find(id);
            if (filho == null)
            {
                return NotFound();
            }

            db.Filho.Remove(filho);
            db.SaveChanges();

            return Ok(filho);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilhoExists(long id)
        {
            return db.Filho.Count(e => e.idFilho == id) > 0;
        }
    }
}