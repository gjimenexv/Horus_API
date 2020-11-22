using Solution.BS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Solution.API.Models;
using Solution.DAL;


namespace Solution.API.Controllers
{
        [RoutePrefix("api/Auditoria")]
        public class AuditoriaController : ApiController
        {
            //Instaciar una clase Auditoria desde BS para poder acceder a los metodos del CRUD
            clsAuditoria clsA = new clsAuditoria();


            [HttpGet]
            [Route("")]
            public IHttpActionResult GetAllAuditorias()
            {
                ICollection<ConsultarAuditoriaResult> Auditoria = clsA.ConsultarAuditoria().ToList();

                if (Auditoria.Count == 0)
                {
                    return NotFound();
                }

                return Ok(Auditoria);
            }
        }
}
