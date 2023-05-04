using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class CriterioModel
    {
        public int VariableId { get; set; }

     
        public decimal PesoDefault { get; set; }

        public string? FechaCreacion { get; set; }

        public string? FechaModificacion { get; set; }
        public int NombreEstado { get; set; }
    }
}
