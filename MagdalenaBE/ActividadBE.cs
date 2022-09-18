using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagdalenaBE
{
    public class ActividadBE
    {
        [DisplayName("#Actividad")]
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        [DisplayName("Fecha Inicio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? FechaInicio { get; set; }
        [DisplayName("Fecha Proceso")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? FechaEnProceso { get; set; }
        [DisplayName("Fecha Finalizacion")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? FechaFinalizacion { get; set; }
        public string TareasRealizadas { get; set; }
    }
}
