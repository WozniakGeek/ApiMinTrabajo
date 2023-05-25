using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class ListVacantsModel
    {

        public class Vacants
        {
            
            public Guid VacanteId { get; set; }
            public string? Vacante { get; set; }
            public bool Match { get; set; }
            public List<Criterios>? CriteriosList { get; set; }
        }

        public class Criterios
        {
            public int VariableId { get; set; }
            public string? NombreVariable { get; set; }
            public decimal? Peso { get; set; }
            public string? FechaCreacion { get; set; }
        }

    }


}
