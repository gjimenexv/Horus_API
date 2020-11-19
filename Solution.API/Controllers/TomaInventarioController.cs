using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/TomaInventario")]
    public class TomaInventarioController : ApiController
    {
        //Instaciar una clase TomaInventario desde BS para poder acceder a los metodos del CRUD
        clsTomaInventario clsTI = new clsTomaInventario();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTomaInventario()
        {
            ICollection<ConsultarTomaInventarioResult> tomainventarios = clsTI.ConsultarTomaInventario().ToList();

            if (tomainventarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(tomainventarios);
        }


        [HttpGet]
        [Route("{IdTomaInventario}")]
        public IHttpActionResult GetTomaInventario(string IdTomaInventario)
        {
            ICollection<ConsultaTomaInventarioResult> tomainventarios = clsTI.ConsultaTomaInventario(IdTomaInventario);

            if (tomainventarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(tomainventarios.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostTomaInventario(TomaInventario TomaInventario)
        {
            if (!ModelState.IsValid)
                return BadRequest("Información inválida.");


            bool result = clsTI.CrearTomaInventario(
               TomaInventario.IdFuncionario,
               TomaInventario.IdCentroCosto.Value,
               TomaInventario.Titulo,
               TomaInventario.Descripcion,
               TomaInventario.FechaInicio.Value,
               TomaInventario.FechaFin.Value,
               TomaInventario.Estado.Value,
               TomaInventario.ModificadoPor);

            if (!result)
            {
                return BadRequest("No es posible crear uno nuevo");
            }
            return Ok(TomaInventario);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutTomaInventario(TomaInventario TomaInventario)
        {
            if (!ModelState.IsValid)
                return BadRequest("No es un modelo válido.");

            bool result = clsTI.ActualizarTomaInventario(
               TomaInventario.IdTomaInventario,
               TomaInventario.IdFuncionario, 
               TomaInventario.IdCentroCosto.Value,
               TomaInventario.Titulo,
               TomaInventario.Descripcion,
               TomaInventario.FechaInicio.Value,
               TomaInventario.FechaFin.Value,
               TomaInventario.Estado.Value,
               TomaInventario.ModificadoPor);

            if (!result)
            {
                return BadRequest("No es posible actualizar.");
            }
            return Ok(TomaInventario);
        }


        [HttpDelete]
        [Route("{IdTomaInventario}")]
        public IHttpActionResult DeleteTomaInventario(string IdTomaInventario)
        {
            if (IdTomaInventario.IsNullOrWhiteSpace())
                return BadRequest("No es un ID válido");

            bool result = clsTI.EliminarTomaInventario(IdTomaInventario);
            if (!result)
            {
                return BadRequest("No es posible eliminar.");
            }
            return Ok();
        }
    }

}
