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
        
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/item/{idViagem}/{idFilho}")]
        public IHttpActionResult PutViagemFilho(long idViagem, long idFilho, ViagemFilho ViagemFilho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idViagem != ViagemFilho.idVIagem && idFilho != ViagemFilho.idFilho)
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
                if (!ViagemFilhoExists(idViagem, idFilho))
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

        private bool ViagemFilhoExists(long idViagem, long idFilho)
        {
            return db.ViagemFilho.Count(e => e.idVIagem == idViagem && e.idFilho == idFilho) > 0;
        }
    }
}