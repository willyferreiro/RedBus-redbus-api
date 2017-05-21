using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RedBus_api.DTOs;
using System.Collections.Generic;
using RedBus_api.Models;

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
            List<UltimaViagemFilhoView> filhosViagem = db.UltimaViagemFilhoView
                .Where(e => e.idResponsavel == idResponsavel)
                .ToList<UltimaViagemFilhoView>();

            List<FilhoDTO> filhos = new List<FilhoDTO>();

            foreach (UltimaViagemFilhoView filhoViagem in filhosViagem)
            {
                FilhoDTO filho = new FilhoDTO();
                filho.viagemFilho = new ViagemFilhoDTO();

                filho.idFilho = filhoViagem.idFilho;
                filho.idResponsavel = filhoViagem.idResponsavel;
                filho.idMotorista = filhoViagem.idMotorista;
                filho.nome = filhoViagem.nome;
                filho.emViagem = filhoViagem.emViagem;
                filho.embarcado = filhoViagem.embarcado;
                filho.posicao_latitudeCasa = filhoViagem.posicao_latitudeCasa;
                filho.posicao_longitutdeCasa = filhoViagem.posicao_longitutdeCasa;
                filho.posicao_latitudeEscola = filhoViagem.posicao_latitudeEscola;
                filho.posicao_longitutdeEscola = filhoViagem.posicao_longitutdeEscola;
                filho.foto = filhoViagem.foto;
                filho.fotoCompleta = filhoViagem.fotoCompleta;

                if (filhoViagem.idViagem != null)
                {
                    filho.viagemFilho.idViagem = (long)filhoViagem.idViagem;
                    filho.viagemFilho.dataEmbarque = filhoViagem.dataEmbarque;
                    filho.viagemFilho.dataDesembarque = filhoViagem.dataDesembarque;
                    filho.viagemFilho.posicaoEmbarque_latitude = filhoViagem.posicaoEmbarque_latitude;
                    filho.viagemFilho.posicaoEmbarque_longitude = filhoViagem.posicaoEmbarque_longitude;
                    filho.viagemFilho.posicaoDesembarque_latitude = filhoViagem.posicaoDesembarque_latitude;
                    filho.viagemFilho.posicaoDesembarque_longitude = filhoViagem.posicaoDesembarque_longitude;
                }

                filhos.Add(filho);
            }

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