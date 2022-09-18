using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using MagdalenaBE;

namespace Prueba_Magdalena.dal
{
    public class ActividadDAL
    {
        private string ObtenerCadenaConexion()
        {
            SqlConnectionStringBuilder conB = new SqlConnectionStringBuilder();
            conB.DataSource = @"SERVER\SQLEXPRESS2017";
            conB.InitialCatalog = "MagdalenaDB";
            conB.Password = "IOSTREAM_123";
            conB.UserID = "SA";

            return conB.ConnectionString;
        }

        public bool Crear(ActividadBE e)
        {
            using(ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
	        {
                if (string.IsNullOrWhiteSpace(e.Descripcion))
                    throw new Exception("La Descripcion es Requerida");

                if (e.FechaInicio == null )
                    throw new Exception("La Fecha de Inicio es Requerida");

                dc.Actividad_Crear(e.Descripcion, e.FechaInicio);
		        return true;
	        }
        }

        public bool Marcar_Finalizada(ActividadBE e)
        {
            using (ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
            {
                if (string.IsNullOrWhiteSpace(e.TareasRealizadas))
                    throw new Exception("Es necesario ingresar las Tareas Realizadas");

                dc.Actividad_Marcar_Finalizada(e.Id, e.TareasRealizadas);
                return true;
            }
        }

        public bool Marcar_En_Proceso(ActividadBE e)
        {
            using (ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
            {
                dc.Actividad_Marcar_En_Proceso(e.Id);
                return true;
            }
        }

        public List<ActividadBE> Listar(ActividadBE e)
        {
            using (ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
            {
                return dc.Actividad_Listar(e.Id).ToList();
            }
        }

        public List<ActividadBE> Creadas_Listar(ActividadBE e)
        {
            using(ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
	        {
		        return dc.Actividad_Creadas_Listar(e.Id).ToList();
	        }
        }

        public List<ActividadBE> Proceso_Listar(ActividadBE e)
        {
            using (ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
            {
                return dc.Actividad_En_Proceso_Listar(e.Id).ToList();
            }
        }

        public List<ActividadBE> Finalizadas_Listar(ActividadBE e)
        {
            using (ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
            {
                return dc.Actividad_Finalizadas_Listar(e.Id).ToList();
            }
        }
    }
}