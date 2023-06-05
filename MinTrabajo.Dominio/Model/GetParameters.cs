using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class GetParameters
    {
        public int ParameterId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Typevalue { get; set; }
        public string? Table { get; set; }
        public string? Value { get; set; }
        public decimal? StartingRange { get; set; }
        public decimal? EndRange { get; set; }
        public string? Proccess { get; set; }
        public string? ModifyDate { get; set; }
        public int? Status { get; set; }
    }
}
