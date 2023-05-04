﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class RequestAtributteModel
    {
        public string? User { get; set; }        
        public List<Atributte> atributtes { get; set; }


        public class Atributte
        {
            public int? atributte { get; set; }
            public int weight { get; set; }
            public int? status { get; set; }           
           
        }

    }
}
