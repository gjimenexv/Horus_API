using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;
using Solution.API.Models;
using Solution.BS;
using Solution.DAL;
using Solution.API.Tools;
using System.Configuration;

namespace Solution.API.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        clsLogin clsL = new clsLogin();

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            login.Contrasena = Seguridad.EncryptString(SecretKey, login.Contrasena);

            ICollection<AutenticarUsuarioResult> funcionario = clsL.AutenticarUsuario(login.Usuario, login.Contrasena);

            if (!funcionario.Equals(0))
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}