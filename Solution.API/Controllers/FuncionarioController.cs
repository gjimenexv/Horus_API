using Microsoft.Ajax.Utilities;
using Solution.BS;
using Solution.DAL;
using Solution.API.Models;
using Solution.API.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Configuration;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Net;

namespace Solution.API.Controllers
{
    [RoutePrefix("api/Funcionario")]
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
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

        [HttpGet]
        [Route("Correo")]
        public IHttpActionResult GetCorreo(string correo)
        {
            int existe = clsF.ConsultaCorreo(correo);

            if (existe == 1)
            {
                return BadRequest("El correo ya esta en uso");
            }
            else
            {
              return Ok();
            }
        }

        [HttpPost]
        [Route("CambioContrasena")]
        public IHttpActionResult PostToken(ResetPasswordEmail email)
        {
            int existe = clsF.ConsultaToken(email.Token, email.Email);

            if (existe == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest("No es posible cambiar la contraseña");
            }
        }

        [HttpPut]
        [Route("ActualizarContrasena")]
        public IHttpActionResult PutContrasena(ResetPassword NewPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest("Por favor dar todos los datos");

            NewPassword.Password = Seguridad.EncryptString(SecretKey, NewPassword.Password);
            bool result = clsF.ActualizarContrasena(
                     NewPassword.Token,
                     NewPassword.Password,
                     NewPassword.Email);

            if (!result)
            {
                return BadRequest("Incapaz de actualizar la contraseña");
            }
            return Ok(NewPassword);
        }

        [HttpGet]
        [Route("{Usuario}")]
        public string GetRol(string usuario)
        {
            string rol = clsF.ConsultaRol(usuario);

            if (rol.IsNullOrWhiteSpace())
            {
                return null;
            }
            return rol;
        }
    }

}
