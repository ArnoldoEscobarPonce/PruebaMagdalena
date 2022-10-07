using MagdalenaBE;
using Prueba_Magdalena.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba_Magdalena.Controllers
{
    public class PrioridadController : ApiController
    {
        // Listar Todo
        // GET api/Prioridad
        public IHttpActionResult Get([FromBody]PrioridadBE pPrioridad)
        {
            PrioridadDAL dal = new PrioridadDAL();

            if (pPrioridad == null)
                pPrioridad = new PrioridadBE();

            return Ok(dal.Listar(pPrioridad));
        }

        // Listar Uno
        // GET api/Prioridad/5
        public IHttpActionResult Get(int id)
        {
            PrioridadDAL dal = new PrioridadDAL();

            PrioridadBE pPrioridad = new PrioridadBE() { Id = id };
            return Ok(dal.Listar(pPrioridad));
        }



    }
}
