using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/EstadodeBien")]
    public class EstadodeBienController : ApiController
    {
        //Instaciar una clase funcianario desde BS para poder acceder a los metodos del CRUD
        clsEstadoBien clsF = new clsEstadoBien();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllEstadosdeBien()
        {
            ICollection<ConsultarEstadoBienResult> estadodebien = clsF.ConsultarEstadoBien().ToList();

            if (estadodebien.Count == 0)
            {
                return NotFound();
            }

            return Ok(estadodebien);
        }


        [HttpGet]
        [Route("{IdEstadoBien:int}")]
        public IHttpActionResult GetEstadobien(int IdEstadoBien)
        {
            ICollection<ConsultaEstadoBienResult> estadobien = clsF.ConsultaEstadoBien(IdEstadoBien);

            if (estadobien.Count == 0)
            {
                return NotFound();
            }

            return Ok(estadobien.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostEstadoBien(EstadoBien estadobien)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");


            bool result = clsF.CrearEstadoBien(
                    estadobien.Descripcion,
                    estadobien.Estado);
                    
       
            //TODO: Validar que el correo no existe previamente.
            //TODO: Validacion de que el usuario es unico.
            //TODo: Encriptado de la contraseña.

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(estadobien);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutFuncionario(EstadoBien estadobien)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool result = clsF.ActualizarEstadoBien(
                estadobien.IdEstadoBien,     
                estadobien.Descripcion,
                estadobien.Estado);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(estadobien);
        }


        [HttpDelete]
        [Route("{IdEstadoBien:int}")]
        public IHttpActionResult DeleteEstadoBien(int IdEstadoBien)
        {
            if (IdEstadoBien <= 0)
                return BadRequest("Not a valid student id");

            bool result = clsF.EliminarEstadoBien(IdEstadoBien);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }
    }

}
