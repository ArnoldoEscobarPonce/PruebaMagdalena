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
    public class ActividadController : ApiController
    {
        // Listar Todo
        // GET api/actividad
        public IHttpActionResult Get([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();

            if (pActividad == null)
                pActividad = new ActividadBE();

            return Ok(dal.Listar(pActividad));
        }

        // Listar Uno
        // GET api/actividad/5
        public IHttpActionResult Get(int id)
        {
            ActividadDAL dal = new ActividadDAL();

            ActividadBE pActividad = new ActividadBE() { Id = id };
            return Ok(dal.Listar(pActividad));
        }

        [HttpGet]
        [Route("api/Actividad/Get_Activas")]
        public IHttpActionResult Get_Activas([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();
            if (pActividad == null)
                pActividad = new ActividadBE();

            return Ok(dal.Creadas_Listar(pActividad));
        }

        [HttpGet]
        [Route("api/Actividad/Get_En_Proceso")]
        public IHttpActionResult Get_En_Proceso([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();
            if (pActividad == null)
                pActividad = new ActividadBE();

            return Ok(dal.Proceso_Listar(pActividad));
        }

        [HttpGet]
        [Route("api/Actividad/Get_Finalizadas")]
        public IHttpActionResult Get_Finalizadas([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();
            if (pActividad == null)
                pActividad = new ActividadBE();

            return Ok(dal.Finalizadas_Listar(pActividad));
        }

        // Crear
        // POST api/actividad
        public IHttpActionResult Post([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();
            dal.Crear(pActividad);
            return Ok();
        }

        [HttpPut]
        [Route("api/Actividad/Marcar_Finalizada")]
        public IHttpActionResult Marcar_Finalizada([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();
            dal.Marcar_Finalizada(pActividad);
            return Ok();
        }

        [HttpPut]
        [Route("api/Actividad/Marcar_En_Proceso")]
        public IHttpActionResult Marcar_En_Proceso([FromBody]ActividadBE pActividad)
        {
            ActividadDAL dal = new ActividadDAL();
            dal.Marcar_En_Proceso(pActividad);
            return Ok();
        }

        // Actualizar
        // PUT api/actividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // Borrar
        // DELETE api/actividad/5
        public void Delete(int id)
        {
        }
    }
}
