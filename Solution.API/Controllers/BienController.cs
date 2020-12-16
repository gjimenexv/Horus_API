using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/Bien")]
    public class BienController : ApiController
    {
        //Instaciar una clase bien desde BS para poder acceder a los metodos del CRUD
        clsBien clsF = new clsBien();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllBien()
        {
            ICollection<ConsultarBienResult> funcionarios = clsF.ConsultarBien().ToList();

            if (funcionarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }


        [HttpGet]
        [Route("{Placa}")]
        public IHttpActionResult GetBien(string Placa)
        {
            ICollection<ConsultaBienResult> funcionarios = clsF.ConsultaBien(Placa);

            if (funcionarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(funcionarios.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostBien(Bien bien)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");


            bool result = clsF.CrearBien(
               bien.Placa,
               bien.Descripcion,
               bien.FechaIngreso.Value,
               bien.ValorInicial.Value,
               bien.Garantia.Value,
               bien.Observaciones,
               bien.EntregadoBienes.Value,
               bien.VidaUtil.Value,
               bien.IdCentroCosto.Value,
               bien.IdEstadoBien.Value,
               bien.IdFuncionario,
               bien.IdTipoBien.Value,
               bien.ModificadoPor);

            //TODO: Validar que el correo no existe previamente.
            //TODO: Validacion de que el usuario es unico.
            //TODo: Encriptado de la contraseña.

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(bien);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutBien(Bien bien)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool result = clsF.ActualizarBien(
               bien.Placa,
               bien.Descripcion,
               bien.FechaIngreso.Value,
               bien.ValorInicial.Value,
               bien.Garantia.Value,
               bien.Observaciones,
               bien.EntregadoBienes.Value,
               bien.VidaUtil.Value,
               bien.IdCentroCosto.Value,
               bien.IdEstadoBien.Value,
               bien.IdFuncionario,
               bien.IdTipoBien.Value,
               bien.ModificadoPor);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(bien);
        }

        //[HttpPut]
        //[Route("Placa")]
        //public IHttpActionResult Put(BienFuncionario bien)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");

        //    bool result = clsF.ActualizarBien(
        //       bien.Placa,
        //       bien.IdFuncionario,
        //       bien.ModificadoPor);

        //    if (!result)
        //    {
        //        return BadRequest("Unable to update new");
        //    }
        //    return Ok(bien);
        //}


        [HttpDelete]
        [Route("{Placa}")]
        public IHttpActionResult DeleteBien(string Placa)
        {
            if (Placa.IsNullOrWhiteSpace())
                return BadRequest("Not a valid student id");

            bool result = clsF.EliminarBien(Placa);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }
    }

}
