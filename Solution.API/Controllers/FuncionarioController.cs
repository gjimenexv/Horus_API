using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using Solution.API.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Configuration;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/Funcionario")]
    public class FuncionarioController : ApiController
    {
        //Instaciar una clase funcianario desde BS para poder acceder a los metodos del CRUD
        clsFuncionario clsF = new clsFuncionario();
        string SecretKey = ConfigurationManager.AppSettings["SecretKey"];


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllFuncionarios()
        {
            ICollection<ConsultarFuncionarioResult> funcionarios = clsF.ConsultarFuncionario().ToList();

            if (funcionarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }


        [HttpGet]
        [Route("{IdFuncionario:int}")]
        public IHttpActionResult GetFuncionario(string IdFuncionario)
        {
            ICollection<ConsultaFuncionarioResult> funcionarios = clsF.ConsultaFuncionario(IdFuncionario);

            if (funcionarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(funcionarios.FirstOrDefault());
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            
            funcionario.Contrasena = Seguridad.EncryptString(SecretKey, funcionario.Contrasena);

            bool result = clsF.CrearFuncionario(
                    funcionario.IdOficina,
                    funcionario.NombreCompleto,
                    funcionario.Usuario,
                    funcionario.Contrasena,
                    funcionario.CorreoElectronico,
                    funcionario.ModificadoPor);

            //TODO: Validar que el correo no existe previamente.
            //TODO: Validacion de que el usuario es unico.
            //TODo: Encriptado de la contraseña.

            if (!result)
            {
                return BadRequest("Unable to create new");
            }
            return Ok(funcionario);
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult PutFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            funcionario.Contrasena = Seguridad.EncryptString(SecretKey, funcionario.Contrasena);
            bool result = clsF.ActualizarFuncionario(
                     funcionario.IdFuncionario,
                     funcionario.IdOficina,
                     funcionario.NombreCompleto,
                     funcionario.Usuario,
                     funcionario.Contrasena,
                     funcionario.CorreoElectronico,
                     funcionario.ModificadoPor);

            if (!result)
            {
                return BadRequest("Unable to update new");
            }
            return Ok(funcionario);
        }


        [HttpDelete]
        [Route("{IdFuncionario:int}")]
        public IHttpActionResult DeleteFuncionario(string IdFuncionario)
        {
            if (IdFuncionario.IsNullOrWhiteSpace())
                return BadRequest("Not a valid student id");

            bool result = clsF.EliminarFuncionario(IdFuncionario);
            if (!result)
            {
                return BadRequest("Unable to delete");
            }
            return Ok();
        }
    }

}
