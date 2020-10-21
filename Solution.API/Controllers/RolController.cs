using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/Rol")]
    public class RolController : ApiController
    {

        //Instaciar una clase Rol desde BS para poder acceder a los metodos del CRUD
        clsRol clsR = new clsRol();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllRoles()
        {
            ICollection<ConsultarRolResult> Roles = clsR.ConsultarRol().ToList();

            if (Roles.Count == 0)
            {
                return NotFound();
            }

            return Ok(Roles);
        }


        [HttpGet]
        [Route("{IdRol:int}")]
        public IHttpActionResult GetRol(int IdRol)
        {
            ICollection<ConsultaRolResult> Roles = clsR.ConsultaRol(IdRol);

            if (Roles.Count == 0)
            {
                return NotFound();
            }

            return Ok(Roles.FirstOrDefault());
        }

        //TODO: Once implemented the method on the clsR, I ca
        //[HttpGet]
        //[Route("~/api/authors/{authorId:int}/books{IdRol:int}")]
        //public IHttpActionResult GetFuncionario(int IdFuncionario)
        //{
        //    ICollection<ConsultaFuncionarioResult> funcionarios = clsR.Consult(IdFuncionario);

        //    if (funcionarios.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(funcionarios.FirstOrDefault());
        //}


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostRol(Roles Rol)
        {
            if (!ModelState.IsValid)
                return BadRequest("Información inválida.");


            bool result = clsR.CrearRol(Rol.Descripcion);

            if (!result)
            {
                return BadRequest("No se puede crear uno nuevo.");
            }
            return Ok(Rol);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutRol(Roles Rol)
        {
            if (!ModelState.IsValid)
                return BadRequest("No es un modelo válido.");

            bool result = clsR.ActualizarRoles(
                     Rol.IdRol,
                     Rol.Descripcion.ToString());

            if (!result)
            {
                return BadRequest("No se puede hacer una nueva actualización.");
            }
            return Ok(Rol);
        }


        [HttpDelete]
        [Route("{IdRol:int}")]
        public IHttpActionResult DeleteRol(int IdRol)
        {
            if (IdRol <= 0)
                return BadRequest("No es un  ID Rol válido.");

            bool result = clsR.EliminarRol(IdRol);
            if (!result)
            {
                return BadRequest("No se puede eliminar.");
            }
            return Ok();
        }

    }
}
