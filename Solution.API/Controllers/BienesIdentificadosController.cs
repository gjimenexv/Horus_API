using Microsoft.Ajax.Utilities;
using Solution.API.Models;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/BienesIdentificados")]
   // [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    public class BienesIdentificadosController : ApiController
    {

        //Instaciar una clase CentrodeCosto desde BS para poder acceder a los metodos del CRUD
        clsBienesIdentificados clsBI = new clsBienesIdentificados();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllBienesIdentificados()
        {
            ICollection<ConsultarBienIdentificadoResult> BienIdentificado = clsBI.ConsultarBienIdentificados().ToList();

            if (BienIdentificado.Count == 0)
            {
                return NotFound();
            }

            return Ok(BienIdentificado);
        }


        [HttpGet]
        [Route("{IdBienIdentificado:int}")]
        public IHttpActionResult GetCentrodeCostos(int IdBienIdentificado)
        {
            ICollection<ConsultaBienIdentificadoResult> BienIdentificado = clsBI.ConsultaBienIdentificado(IdBienIdentificado);

            if (BienIdentificado.Count == 0)
            {
                return NotFound();
            }

            return Ok(BienIdentificado.FirstOrDefault());
        }

        [HttpGet]
        [Route("PorInventario/{IdTomaInventario:int}")]
        public IHttpActionResult GetBienesIdentificadosXTomaInventario(int IdTomaInventario)
        {
            ICollection<ConsultarBienIdentificadoXInventarioResult> BienesIdentificados = clsBI.ConsultarBienIdentificadosXInventario(IdTomaInventario);

            if (BienesIdentificados.Count == 0)
            {
                return NotFound();
            }

            return Ok(BienesIdentificados);
        }



        [HttpPost]
        [Route("")]
        public IHttpActionResult PostBienesIdentificados(BienesIdentificadosModelView BienIdentificado)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");


            bool result = clsBI.CrearBienIdentificado(
                    (int)BienIdentificado.IdTomaInventario,
                    (DateTime)BienIdentificado.Fecha,
                    BienIdentificado.Placa,
                    (bool)BienIdentificado.Estado,
                    BienIdentificado.ModificadoPor);

            //TODO: Validar que el correo no existe previamente.
            //TODO: Validacion de que el usuario es unico.
            //TODo: Encriptado de la contraseña.

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(BienIdentificado);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult PutPostBienesIdentificados(BienesIdentificados BienIdentificado)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool result = clsBI.ActualizarBienIdentificado(
                  BienIdentificado.IdBienIdentificado,
                  (int)BienIdentificado.IdTomaInventario,
                  (DateTime)BienIdentificado.Fecha,
                  BienIdentificado.Placa,
                  (bool)BienIdentificado.Estado,
                  BienIdentificado.ModificadoPor);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(BienIdentificado);
        }

        [HttpDelete]
        [Route("{IdBienesIdentificados}")]
        public IHttpActionResult DeleteBienesIdentificados(int IdBienesIdentificados)
        {
            if (IdBienesIdentificados <= 0)
                return BadRequest("No es un ID valido para un bien identificado");

            bool result = clsBI.EliminarBienIdentificados(IdBienesIdentificados);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }



    }
}
