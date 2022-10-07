﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba_Magdalena.dal
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
    using MagdalenaBE;
	
	
	public partial class ContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public ContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}

        [Function(Name = "dbo.Sp_Actividad_Crear")]
        public ISingleResult<ActividadBE> Actividad_Crear(
            [Parameter(DbType = "varchar(255)")] string Descripcion,
            [Parameter(DbType = "date")] DateTime? FechaInicio
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Descripcion,
                FechaInicio
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Actividad_Listar")]
        public ISingleResult<ActividadBE> Actividad_Listar(
            [Parameter(DbType = "int")] int? Id
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Id
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Actividad_Listar_Creadas")]
        public ISingleResult<ActividadBE> Actividad_Creadas_Listar(
            [Parameter(DbType = "int")] int? Id
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Id
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Actividad_Listar_En_Proceso")]
        public ISingleResult<ActividadBE> Actividad_En_Proceso_Listar(
            [Parameter(DbType = "int")] int? Id
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Id
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Actividad_Listar_Finalizadas")]
        public ISingleResult<ActividadBE> Actividad_Finalizadas_Listar(
            [Parameter(DbType = "int")] int? Id
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Id
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Actividad_Marcar_Finalizada")]
        public ISingleResult<ActividadBE> Actividad_Marcar_Finalizada(
            [Parameter(DbType = "int")] int? Id,
            [Parameter(DbType = "varchar(999)")] string TareasRealizadas
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Id,
                TareasRealizadas
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Actividad_Marcar_En_Proceso")]
        public ISingleResult<ActividadBE> Actividad_Marcar_En_Proceso(
            [Parameter(DbType = "int")] int? Id
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                Id
                );
            return ((ISingleResult<ActividadBE>)result.ReturnValue);
        }

        [Function(Name = "dbo.Sp_Prioridad_Listar")]
        public ISingleResult<PrioridadBE> Prioridad_Listar()
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
            return ((ISingleResult<PrioridadBE>)result.ReturnValue);
        }
    }
}
#pragma warning restore 1591
