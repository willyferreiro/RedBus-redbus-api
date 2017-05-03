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
    public class ResponsavelController : ApiController
    {
        private redbusdb db = new redbusdb();

        // GET: api/Responsavel
        public IQueryable<Responsavel> GetResponsavel()
        {
            return db.Responsavel;
        }

        // GET: api/Responsavel/5
        [ResponseType(typeof(Responsavel))]
        public IHttpActionResult GetResponsavel(long id)
        {
            Responsavel responsavel = db.Responsavel.Find(id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return Ok(responsavel);
        }

        // PUT: api/Responsavel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResponsavel(long id, Responsavel responsavel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != responsavel.idResponsavel)
            {
                return BadRequest();
            }

            db.Entry(responsavel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsavelExists(id))
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

        // POST: api/Responsavel
        [ResponseType(typeof(Responsavel))]
        public IHttpActionResult PostResponsavel(Responsavel responsavel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Responsavel.Add(responsavel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ResponsavelExists(responsavel.idResponsavel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = responsavel.idResponsavel }, responsavel);
        }

        // DELETE: api/Responsavel/5
        [ResponseType(typeof(Responsavel))]
        public IHttpActionResult DeleteResponsavel(long id)
        {
            Responsavel responsavel = db.Responsavel.Find(id);
            if (responsavel == null)
            {
                return NotFound();
            }

            db.Responsavel.Remove(responsavel);
            db.SaveChanges();

            return Ok(responsavel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResponsavelExists(long id)
        {
            return db.Responsavel.Count(e => e.idResponsavel == id) > 0;
        }
    }
}