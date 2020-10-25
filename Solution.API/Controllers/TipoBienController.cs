using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/TipoBien")]
    public class TipoBienController : ApiController
    {

        //Instaciar una clase TipoBien desde BS para poder acceder a los metodos del CRUD
        clsTipoBien clsTB = new clsTipoBien();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTipoBienes()
        {
            ICollection<ConsultarTipoBienResult> tipobienes = clsTB.ConsultarTipoBien().ToList();

            if (tipobienes.Count == 0)
            {
                return NotFound();
            }

            return Ok(tipobienes);
        }


        [HttpGet]
        [Route("{IdTipoBien:int}")]
        public IHttpActionResult GetTipoBien(int IdTipoBien)
        {
            ICollection<ConsultaTipoBienResult> tipobienes = clsTB.ConsultaTipoBien(IdTipoBien);

            if (tipobienes.Count == 0)
            {
                return NotFound();
            }

            return Ok(tipobienes.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostTipoBien(TipoBien tipobien)
        {
            if (!ModelState.IsValid)
                return BadRequest("Información inválida.");


            bool result = clsTB.CrearTipoBien(tipobien.Descripcion, (bool)tipobien.Estado, tipobien.ModificadoPor);

            if (!result)
            {
                return BadRequest("No se puede crear uno nuevo.");
            }
            return Ok(tipobien);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutTipoBien(TipoBien tipobien)
        {
            if (!ModelState.IsValid)
                return BadRequest("No es un modelo válido.");

            bool result = clsTB.ActualizarTipoBien(
                     tipobien.IdTipoBien,
                     tipobien.Descripcion,
                     (bool)tipobien.Estado,
                     tipobien.ModificadoPor);

            if (!result)
            {
                return BadRequest("No se puede hacer una nueva actualización.");
            }
            return Ok(tipobien);
        }


        [HttpDelete]
        [Route("{IdTipoBien:int}")]
        public IHttpActionResult DeleteTipoBien(int IdTipoBien)
        {
            if (IdTipoBien <= 0)
                return BadRequest("No es un  ID tipo de bien válido.");

            bool result = clsTB.EliminarTipoBien(IdTipoBien);
            if (!result)
            {
                return BadRequest("No se puede eliminar.");
            }
            return Ok();
        }
    }
}
