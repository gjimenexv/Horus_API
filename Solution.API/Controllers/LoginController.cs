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
using System.Threading.Tasks;
using System.IO;


namespace Solution.API.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        clsLogin clsL = new clsLogin();
        clsFuncionario clsF = new clsFuncionario();

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
        public async Task<IHttpActionResult> Authenticate([FromBody]LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            login.Contrasena = Seguridad.EncryptString(SecretKey, login.Contrasena);

            int acceso = clsL.AutenticarUsuario(login.Usuario, login.Contrasena);

            if (acceso == 0)
            {   
                clsBitacora.RegistrarBitacora(1, "Login", "Autenticar", "Usuario o Contraseña incorrecto",1, DateTime.Now);
                return Unauthorized();
            }
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return Ok(token);
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IHttpActionResult ForgotPassword(ForgotPasswordViewModel email)
        {
            if (email == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                if (clsF.ConsultaCorreo(email.Email) == 1)
                {
                    string SecretKey = ConfigurationManager.AppSettings["SecretKey"];
                    var token = Seguridad.EncryptString(SecretKey, email.Email);
                    string link = string.Format("https://localhost:44315/Login/ResetPassword?token={0}+&email={1}", token, email.Email);
                    clsF.CrearToken(token, email.Email, "Sistema");

                    //Read template file from the App_Data folder
                    var sr = new StreamReader("C:\\Users\\Guillermo\\Source\\Repos\\Horus_API\\Solution.API\\App_Data\\Templates\\ResetPassword.txt");
                    string MailText = sr.ReadToEnd();
                    sr.Close();
                    MailText = MailText.Replace("[hreflink]", link);
                    var MailHelper = new MailHelper
                    {
                        Subject = "Solicitud de cambio de contraseña sistema Horus",
                        Sender = "proyectohoruscr@gmail.com",
                        Recipient = email.Email,
                        RecipientCC = null,
                        Body = MailText
                    };
                    MailHelper.Send();
                    return Ok();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
                
            }
        }
    }
}