using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public  class UpdateCriteriosMatchByVacantModel
    {
        public Guid VacantId { get; set; }
        public int? atributte { get; set; }
        public int weight { get; set; }
        public string? User { get; set; }
    }
}
