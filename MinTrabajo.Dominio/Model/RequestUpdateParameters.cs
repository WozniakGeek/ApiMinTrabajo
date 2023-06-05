using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinTrabajo.Dominio.Model.RequestAtributteModel;

namespace MinTrabajo.Dominio.Model
{
    public class RequestUpdateParameters
    {
        [Required]
        public string User { get; set; }
        [Required]
        public List<parameters> parameter { get; set; }


        public class parameters
        {
            public int ParameterId { get; set; }
            public string? table { get; set; }
            public string? Value { get; set; }
            public decimal? StartingRange { get; set; }
            public decimal? EndRange { get; set; }            
        }

    }
}
