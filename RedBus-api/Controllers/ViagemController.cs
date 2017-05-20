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
using RedBus_api.DTOs;

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

        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/viagem/finalizaviagem/{idViagem}")]
        public IHttpActionResult PutViagem(long idViagem, ViagemDTO viagemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           if (idViagem != viagemDTO.idViagem)
                return BadRequest();
            if (viagemDTO.idMotorista == 0)
                return BadRequest("idMotorista não pode ser null");
            if (viagemDTO.posicao_latitude == 0 || viagemDTO.posicao_longitude == 0)
                return BadRequest("Posição deve ser informada");

            Viagem viagem = db.Viagem.Find(idViagem);

            viagem.posicaoFim_latitude = viagemDTO.posicao_latitude;
            viagem.posicaoFim_longitude = viagemDTO.posicao_longitude;
            viagem.statusViagem = (int)StatusViagem.Concluida;
            viagem.dataFimViagem = DateTime.Now;
            db.Entry(viagem).State = EntityState.Modified;

            Motorista motorista = db.Motorista.Find(viagemDTO.idMotorista);
            motorista.emViagem = false;
            db.Entry(motorista).State = EntityState.Modified;

            foreach (long idFilho in viagemDTO.idFilhos)
            {
                ViagemFilho viagemFilho = db.ViagemFilho
                    .Include(e => e.Filho)
                    .SingleOrDefault(f => f.idViagem == viagemDTO.idViagem && f.idFilho == idFilho);

                viagemFilho.Filho.embarcado = false;
                viagemFilho.Filho.emViagem = false;

                viagemFilho.posicaoDesembarque_latitude = viagemDTO.posicao_latitude;
                viagemFilho.posicaoDesembarque_longitude = viagemDTO.posicao_longitude;
                viagemFilho.dataDesembarque = DateTime.Now;

                db.Entry(viagemFilho).State = EntityState.Modified;
                db.Entry(viagemFilho.Filho).State = EntityState.Modified;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(idViagem))
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
        [Route("api/viagem/iniciaviagem")]
        public IHttpActionResult PostViagem(ViagemDTO viagemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (viagemDTO.idMotorista == 0)
                return BadRequest("idMotorista não pode ser null");

            if (viagemDTO.idFilhos.Count <= 0)
                return BadRequest("No mínimo um filho deve ser informado");

            if (viagemDTO.posicao_latitude == 0 || viagemDTO.posicao_longitude == 0)
                return BadRequest("Posição deve ser informada");

            Viagem viagem = new Viagem()
            {
                idMotorista = viagemDTO.idMotorista,
                dataInicioViagem = DateTime.Now,
                posicaoInicio_latitude = viagemDTO.posicao_latitude,
                posicaoInicio_longitude = viagemDTO.posicao_longitude,
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
            viagem.Motorista.posicao_latitude = viagemDTO.posicao_latitude;
            viagem.Motorista.posicao_longitude = viagemDTO.posicao_longitude;
            
            db.Entry(viagem.Motorista).State = EntityState.Modified;
            
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