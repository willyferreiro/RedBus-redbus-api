using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RedBus_api.DTOs;
using System.Collections.Generic;

namespace RedBus_api.Controllers
{
    public class FilhoController : ApiController
    {
        private redbusdb db = new redbusdb();

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


        [HttpGet]
        [Route("api/filhos/{idResponsavel}")]
        [ResponseType(typeof(FilhoDTO))]
        public IHttpActionResult GetFilhos(long idResponsavel)
        {
            List<Filho> filhos = db.Filho
                .Include(e => e.Viagem)
                .Where(e => e.idResponsavel == idResponsavel)
                .ToList<Filho>();

            foreach

            return Ok(filhos);
        }

        [HttpGet]
        [Route("api/passageiros/{idMotorista}")]
        public IHttpActionResult GetPassageiros(long idMotorista)
        {
            List<Filho> filhos = db.Filho.Where(e => e.idMotorista == idMotorista)
                .ToList<Filho>();

            return Ok(filhos);
        }

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