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

        [HttpGet]
        [Route("api/passageiro/{idViagem}/{idFilho}")]
        [ResponseType(typeof(ViagemFilho))]
        public IHttpActionResult GetViagem(long idViagem, long idFilho)
        {
            ViagemFilho viagemFilho = db.ViagemFilho
              .Include(e => e.Filho)
              .SingleOrDefault(f => f.idViagem == idViagem && f.idFilho == idFilho);

            if (viagemFilho == null)
            {
                return NotFound();
            }

            return Ok(viagemFilho);
        }

        //[HttpPut]
        //[ResponseType(typeof(void))]
        //[Route("api/viagemfilho/{idViagem}/{idFilho}")]
        //public IHttpActionResult PutViagemFilho(long idViagem, long idFilho, ViagemFilho viagemFilho)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (idViagem != viagemFilho.idViagem && idFilho != viagemFilho.idFilho)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(viagemFilho).State = EntityState.Modified;
        //    db.Entry(viagemFilho.Filho).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ViagemFilhoExists(idViagem, idFilho))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/passageiro/{idViagem}/{idFilho}")]
        public IHttpActionResult PutDesembarcaViagemFilho(long idViagem, long idFilho, AtualizaPassageiroDTO passageiroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (idViagem != passageiroDTO.idViagem && idFilho != passageiroDTO.idFilho)
            {
                return BadRequest();
            }

            ViagemFilho viagemFilho = db.ViagemFilho
                .Include(e => e.Filho)
                .SingleOrDefault(f => f.idViagem == passageiroDTO.idViagem && f.idFilho == passageiroDTO.idFilho);

            if (passageiroDTO.embarcado)
            {
                viagemFilho.dataEmbarque = DateTime.Now;
                viagemFilho.posicaoEmbarque_latitude = passageiroDTO.posicao_latitude;
                viagemFilho.posicaoEmbarque_longitude = passageiroDTO.posicao_longitutde;
                viagemFilho.Filho.embarcado = true;
            }
            else //desembarque
            {
                viagemFilho.dataDesembarque = DateTime.Now;
                viagemFilho.posicaoDesembarque_latitude = passageiroDTO.posicao_latitude;
                viagemFilho.posicaoDesembarque_longitude = passageiroDTO.posicao_longitutde;
                viagemFilho.Filho.emViagem = false;
                viagemFilho.Filho.embarcado = false;
            }
            
            db.Entry(viagemFilho.Filho).State = EntityState.Modified;
            db.Entry(viagemFilho).State = EntityState.Modified;

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
            return db.ViagemFilho.Count(e => e.idViagem == idViagem && e.idFilho == idFilho) > 0;
        }
    }
}