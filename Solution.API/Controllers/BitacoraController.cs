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
    [RoutePrefix("api/Bitacora")]
    public class BitacoraController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllBitacoras()
        {
            ICollection<ConsultarBitacoraResult> bitacora = clsBitacora.ConsultarBitacora();

            if (bitacora.Count == 0)
            {
                return NotFound();
            }

            return Ok(bitacora);
        }
    }
}
