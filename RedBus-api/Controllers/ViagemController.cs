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

        [HttpPost]
        [ResponseType(typeof(Viagem))]
        //[Route("api/viagemdto")]
        public IHttpActionResult PostViagem(InicioViagemDTO viagemDTO)
        {
            if (viagemDTO.idMotorista == 0)
                return BadRequest("idMotorista não pode ser null");

            if (viagemDTO.idFilhos.Count <= 0)
                return BadRequest("No mínimo um filho deve ser informado");
            
            if (viagemDTO.posicaoInicio_latitude == 0 || viagemDTO.posicaoInicio_longitude == 0)
                return BadRequest("Posição deve ser informada");

            Viagem viagem = new Viagem()
            {
                idMotorista = viagemDTO.idMotorista,
                dataInicioViagem = DateTime.Now,
                posicaoInicio_latitude = viagemDTO.posicaoInicio_latitude,
                posicaoInicio_longitude = viagemDTO.posicaoInicio_longitude,
                statusViagem = (int) StatusViagem.Andamento
            };

            db.Entry(viagem).State = EntityState.Added;

            foreach (int idFilho in viagemDTO.idFilhos)
            {
                ViagemFilho vf = new ViagemFilho()
                {
                    idFilho = idFilho,
                    Filho = db.Filho.Find(idFilho)
                };
                vf.Filho.emViagem = true;
                
                viagem.ViagemFilho.Add(vf);
                db.Entry(vf).State = EntityState.Added;
                db.Entry(vf.Filho).State = EntityState.Modified;
            }

            viagem.Motorista = db.Motorista.Find(viagemDTO.idMotorista);
            viagem.Motorista.emViagem = true;
            viagem.Motorista.posicao_latitude = viagemDTO.posicaoInicio_latitude;
            viagem.Motorista.posicao_longitude = viagemDTO.posicaoInicio_longitude;
            
            db.Entry(viagem.Motorista).State = EntityState.Modified;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Viagem.Add(viagem);
            
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { controller = "viagem", id = viagem.idViagem }, viagem);
        }

        // POST: api/Viagem
        //[ResponseType(typeof(Viagem))]
        //public IHttpActionResult PostViagem(Viagem viagem)
        //{
        //    if (viagem.Motorista != null)
        //        db.Entry(viagem.Motorista).State = EntityState.Modified;
            
        //    foreach (ViagemFilho vf in viagem.ViagemFilho)
        //    {
        //        db.Entry(vf).State = EntityState.Added;
        //        if (vf.Filho != null)
        //            db.Entry(vf.Filho).State = EntityState.Modified;
        //    }


        //    /*ToDo */
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    db.Viagem.Add(viagem);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ViagemExists(viagem.idViagem))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = viagem.idViagem }, viagem);
        //}

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