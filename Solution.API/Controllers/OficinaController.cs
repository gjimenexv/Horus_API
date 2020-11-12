using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/Oficina")]
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    public class OficinaController : ApiController
    {

        //Instaciar una clase Oficina desde BS para poder acceder a los metodos del CRUD
        clsOficina clsO = new clsOficina();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllOficinas()
        {
            ICollection<ConsultarOficinaResult> Oficinas = clsO.ConsultarOficina().ToList();

            if (Oficinas.Count == 0)
            {
                return NotFound();
            }

            return Ok(Oficinas);
        }


        [HttpGet]
        [Route("{IdOficina:int}")]
        public IHttpActionResult GetOficina(int IdOficina)
        {
            ICollection<ConsultaOficinaResult> Oficinaes = clsO.ConsultaOficina(IdOficina);

            if (Oficinaes.Count == 0)
            {
                return NotFound();
            }

            return Ok(Oficinaes.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostOficina(Oficina Oficina)
        {
            if (!ModelState.IsValid)
                return BadRequest("Información inválida.");


            bool result = clsO.CrearOficina(Oficina.Descripcion, Oficina.Estado, Oficina.ModificadoPor);

            if (!result)
            {
                return BadRequest("No se puede crear uno nuevo.");
            }
            return Ok(Oficina);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutOficina(Models.Oficina Oficina)
        {

            if (!ModelState.IsValid)
                return BadRequest("No es un modelo válido.");

            bool result = clsO.ActualizarOficina(
                     Oficina.IdOficina,
                     Oficina.Descripcion,
                     Oficina.Estado,
                     Oficina.ModificadoPor);

            if (!result)
            {
                return BadRequest("No se puede hacer una nueva actualización.");
            }
            return Ok(Oficina);
        }


        [HttpDelete]
        [Route("{IdOficina:int}")]
        public IHttpActionResult DeleteOficina(int IdOficina)
        {
            if (IdOficina <= 0)
                return BadRequest("No es un  ID Oficina válido.");

            bool result = clsO.EliminarOficina(IdOficina);
            if (!result)
            {
                return BadRequest("No se puede eliminar.");
            }
            return Ok();
        }

    }
}
