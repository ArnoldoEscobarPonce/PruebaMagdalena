using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using MagdalenaBE;

namespace Prueba_Magdalena.dal
{
    public class PrioridadDAL
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

        public bool Crear(PrioridadBE e)
        {
            throw new NotImplementedException();

            /*
            using(ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
	        {
                if (string.IsNullOrWhiteSpace(e.Descripcion))
                    throw new Exception("La Descripcion es Requerida");

                if (e.FechaInicio == null )
                    throw new Exception("La Fecha de Inicio es Requerida");

                dc.Prioridad_Crear(e.Descripcion, e.FechaInicio);
		        return true;
	        }
            */
        }

        public List<PrioridadBE> Listar(PrioridadBE e)
        {
            using (ContextDataContext dc = new ContextDataContext(this.ObtenerCadenaConexion()))
            {
                return dc.Prioridad_Listar().ToList();
            }
        }

    }
}