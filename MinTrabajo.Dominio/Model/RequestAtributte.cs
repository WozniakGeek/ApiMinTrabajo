using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class RequestAtributte
    {
        public string? User { get; set; }
        public bool hydrocarbon { get; set; }
        public Atributte[]? atributtes { get; set; }


        public class Atributte
        {
            public string? atributte { get; set; }
            public int weight { get; set; }
            public string? status { get; set; }           
            public string? modificationDate { get; set; }
        }

    }
}
