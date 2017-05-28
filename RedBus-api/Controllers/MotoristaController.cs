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
using RedBus_api.Models;

namespace RedBus_api.Controllers
{
    public class MotoristaController : ApiController
    {
        private redbusdb db = new redbusdb();
        
        // GET: api/Motoristas/5
        [ResponseType(typeof(Motorista))]
        public IHttpActionResult GetMotorista(long id)
        {
            Motorista motorista = db.Motorista
              .Include(e => e.Usuario)
              .SingleOrDefault(x => x.idUsuario == id);

            //.Include("Usuario");
            if (motorista == null)
            {
                return NotFound();
            }

            return Ok(motorista);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotorista(long id, Motorista motorista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motorista.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(motorista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(id))
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

        //POST: api/Motoristas
        //[ResponseType(typeof(Motorista))]
        //public IHttpActionResult PostMotorista(Motorista motorista)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Motorista.Add(motorista);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MotoristaExists(motorista.idUsuario))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = motorista.idUsuario }, motorista);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotoristaExists(long id)
        {
            return db.Motorista.Count(e => e.idUsuario == id) > 0;
        }
    }
}