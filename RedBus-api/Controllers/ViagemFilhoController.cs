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
    public class ViagemFilhoController : ApiController
    {
        private redbusdb db = new redbusdb();
        
        // GET: api/ViagemFilho/5
        [ResponseType(typeof(ViagemFilho))]
        public IHttpActionResult GetViagemFilho(long id)
        {
            ViagemFilho ViagemFilho = db.ViagemFilho.Find(id);
            if (ViagemFilho == null)
            {
                return NotFound();
            }

            return Ok(ViagemFilho);
        }

        // PUT: api/ViagemFilho/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViagemFilho(long id, ViagemFilho ViagemFilho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ViagemFilho.idVIagem)
            {
                return BadRequest();
            }

            db.Entry(ViagemFilho).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemFilhoExists(id))
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
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViagemFilhoExists(long id)
        {
            return db.ViagemFilho.Count(e => e.idVIagem == id) > 0;
        }
    }
}