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
    [RoutePrefix("api/Acceso")]
    public class AccesoController : ApiController
    {
        //Instaciar una clase CentrodeCosto desde BS para poder acceder a los metodos del CRUD
        clsAcceso clsF = new clsAcceso();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllAccesso()
        {
            ICollection<ConsultarAccesoResult> Acceso = clsF.ConsultarAcceso().ToList();

            if (Acceso.Count == 0)
            {
                return NotFound();
            }

            return Ok(Acceso);
        }


        [HttpGet]
        [Route("{IdAcceso:int}")]
        public IHttpActionResult GetAccesso(int IdAcceso)
        {
            ICollection<ConsultaAccesoResult> Acceso = clsF.ConsultaAcceso(IdAcceso);

            if (Acceso.Count == 0)
            {
                return NotFound();
            }

            return Ok(Acceso.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostAccesso(Acceso Acceso)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");


            bool result = clsF.CrearAcceso(
                    Acceso.Descripcion,
                    Acceso.Url);

            //TODO: Validar que el correo no existe previamente.
            //TODO: Validacion de que el usuario es unico.
            //TODo: Encriptado de la contraseña.

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(Acceso);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult PutPostAccesso(Acceso Acceso)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool result = clsF.ActualizarAcceso(
                  Acceso.IdAcceso,
                  Acceso.Descripcion,
                  Acceso.Url);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(Acceso);
        }


        [HttpDelete]
        [Route("{IdAcceso:int}")]
        public IHttpActionResult DeleteAccesso(int IdAcceso)
        {
            if (IdAcceso <= 0)
                return BadRequest("No es un ID valido para un Centro de Costos");

            bool result = clsF.EliminarAcceso(IdAcceso);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }
    }

}


