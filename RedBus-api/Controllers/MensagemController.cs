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
    public class MensagemController : ApiController
    {
        private redbusdb db = new redbusdb();

        // GET: api/Mensagem
        public List<Mensagem> GetMensagens()
        {
            return db.Mensagem.ToList<Mensagem>();
        }

        // GET: api/Mensagem/5
        [ResponseType(typeof(Mensagem))]
        public IHttpActionResult GetMensagem(long id)
        {
            Mensagem mensagem = db.Mensagem.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return Ok(mensagem);
        }

        // PUT: api/Mensagem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMensagem(long id, Mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensagem.idMensagem)
            {
                return BadRequest();
            }

            db.Entry(mensagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(id))
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

        // POST: api/Mensagem
        [ResponseType(typeof(Mensagem))]
        public IHttpActionResult PostMensagem(Mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mensagem.Add(mensagem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MensagemExists(mensagem.idMensagem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mensagem.idMensagem }, mensagem);
        }

        // DELETE: api/Mensagem/5
        [ResponseType(typeof(Mensagem))]
        public IHttpActionResult DeleteMensagem(long id)
        {
            Mensagem mensagem = db.Mensagem.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            db.Mensagem.Remove(mensagem);
            db.SaveChanges();

            return Ok(mensagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensagemExists(long id)
        {
            return db.Mensagem.Count(e => e.idMensagem == id) > 0;
        }
    }
}