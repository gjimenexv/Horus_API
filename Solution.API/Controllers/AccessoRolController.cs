using Microsoft.Ajax.Utilities;
using Solution.API.Models;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/AccessoRol")]
    public class AccessoXRolController : ApiController
    {
        //Instaciar una clase CentrodeCosto desde BS para poder acceder a los metodos del CRUD
        clsAccesosXRol clsF = new clsAccesosXRol();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllAccessoXRol()
        {
            ICollection<ConsultarAccesosXRolResult> AccessoXRol = clsF.ConsultarAccessoXRol().ToList();

            if (AccessoXRol.Count == 0)
            {
                return NotFound();
            }

            return Ok(AccessoXRol);
        }


        [HttpGet]
        [Route("{IdAccessoXRol:int}")]
        public IHttpActionResult GetAccessoXRol(int IdAccessoXRol)
        {
            ICollection<ConsultaAccesosXRolResult> AccessoXRol = clsF.ConsultaAccessoXRol(IdAccessoXRol);

            if (AccessoXRol.Count == 0)
            {
                return NotFound();
            }

            return Ok(AccessoXRol.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostAccessoXRol(AccesosXrol AccessoXRol)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            bool result = clsF.CrearAccessoXRol(
                AccessoXRol.IdAcceso,
                AccessoXRol.IdRol);

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(AccessoXRol);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult PutPostAccessoXRol(AccesosXrol AccessoXRol)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool result = clsF.ActualizarAccessoXRol(
                  AccessoXRol.IdAccesoXrol,
                  AccessoXRol.IdAcceso,
                  AccessoXRol.IdRol);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(AccessoXRol);
        }


        [HttpDelete]
        [Route("{IdAccessoXRol:int}")]
        public IHttpActionResult DeleteAccessoXRol(int IdAccessoXRol)
        {
            if (IdAccessoXRol <= 0)
                return BadRequest("No es un ID valido para un Centro de Costos");

            bool result = clsF.EliminarAccessoXRol(IdAccessoXRol);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }
    }

}


