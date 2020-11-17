using Microsoft.Ajax.Utilities;
using Solution.API.Models;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/CentroCosto")]
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    public class CentroCostoController : ApiController
    {
        //Instaciar una clase CentrodeCosto desde BS para poder acceder a los metodos del CRUD
        clsCentrodeCostos clsF = new clsCentrodeCostos();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllCentrodeCostos()
        {
            ICollection<ConsultarCentroCostoResult> CentroCosto = clsF.ConsultarCentroCosto().ToList();

            if (CentroCosto.Count == 0)
            {
                return NotFound();
            }

            return Ok(CentroCosto);
        }


        [HttpGet]
        [Route("{idCentrodeCosto:int}")]
        public IHttpActionResult GetCentrodeCostos(int idCentrodeCosto)
        {
            ICollection<ConsultaCentroCostoResult> CentroCosto = clsF.ConsultaCentroCosto(idCentrodeCosto);

            if (CentroCosto.Count == 0)
            {
                return NotFound();
            }

            return Ok(CentroCosto.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostCentrodeCostos(CentroCostoModelView CentroCosto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");


            bool result = clsF.CrearCentroCosto(
                    CentroCosto.Descripcion,
                    CentroCosto.Estado.ToString(),
                    CentroCosto.ModificadoPor);
               
            //TODO: Validar que el correo no existe previamente.
            //TODO: Validacion de que el usuario es unico.
            //TODo: Encriptado de la contraseña.

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(CentroCosto);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult PutPostCentrodeCostos(CentroCosto CentroCosto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool result = clsF.ActualizarCentroCosto(
                  CentroCosto.IdCentroCosto,
                  CentroCosto.Descripcion,
                  (bool)CentroCosto.Estado,
                  CentroCosto.ModificadoPor);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(CentroCosto);
        }


        [HttpDelete]
        [Route("{idCentrodeCosto:int}")]
        public IHttpActionResult DeleteCentrodeCostos(int idCentrodeCosto)
        {
            if (idCentrodeCosto <= 0)
                return BadRequest("No es un ID valido para un Centro de Costos");

            bool result = clsF.EliminarCentroCosto(idCentrodeCosto);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }
    }

}


