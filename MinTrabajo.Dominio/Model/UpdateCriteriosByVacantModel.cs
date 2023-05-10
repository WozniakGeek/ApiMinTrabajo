using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class UpdateCriteriosByVacantModel
    {

        public Guid VacantId { get; set; }
        public List<Atributtes> atributtes { get; set; }


        public class Atributtes
        {
            public int? atributte { get; set; }
            public int weight { get; set; }
            public int? status { get; set; }
            public string User { get; set; }

        }
    }
}
