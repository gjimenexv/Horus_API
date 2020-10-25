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
    [RoutePrefix("api/HistorialEstado")]
    public class HistorialEstadoController : ApiController
    {
        //Instaciar una clase CentrodeCosto desde BS para poder acceder a los metodos del CRUD
        clsHistorialEstado clsF = new clsHistorialEstado();


        //[HttpGet]
        //[Route("")]
        //public IHttpActionResult GetAllHistorialEstado()
        //{
        //    ICollection<ConsultarAccesoResult> Acceso = clsF.ConsultarAcceso().ToList();

        //    if (Acceso.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Acceso);
        //}


        [HttpGet]
        [Route("{placa}")]
        public IHttpActionResult GetHistorialEstado(string placa)
        {
            ICollection<ConsultaHistorialEstadoXPlacaResult> historial = clsF.ConsultaHistorialEstado(placa);

            if (historial.Count == 0)
            {
                return NotFound();
            }

            return Ok(historial);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostHistorialEstado(HistorialEstado historial)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            bool result = clsF.CrearHistorialEstado(
                    historial.Placa,
                    historial.IdFuncionario,
                    historial.FechaHasta.Value,
                    historial.IdEstadoBien);

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(historial);
        }

        //[HttpPut]
        //[Route("")]
        //public IHttpActionResult PutPostHistorialEstado(Acceso Acceso)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");

        //    bool result = clsF.ActualizarAcceso(
        //          Acceso.IdAcceso,
        //          Acceso.Descripcion,
        //          Acceso.Url);

        //    if (!result)
        //    {
        //        return BadRequest("Unable to update new");
        //    }
        //    return Ok(Acceso);
        //}


        //[HttpDelete]
        //[Route("{IdAcceso:int}")]
        //public IHttpActionResult DeleteHistorialEstado(int IdAcceso)
        //{
        //    if (IdAcceso <= 0)
        //        return BadRequest("No es un ID valido para un Centro de Costos");

        //    bool result = clsF.EliminarAcceso(IdAcceso);
        //    if (!result)
        //    {
        //        return BadRequest("Unable to delete");
        //    }
        //    return Ok();
        //}
    }

}


