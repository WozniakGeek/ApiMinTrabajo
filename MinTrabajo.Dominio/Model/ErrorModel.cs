using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class ErrorModel
    {
        public string? Proccess { get; set; }
        public string? NameError { get; set; }
        public string? Errors { get; set; }
        public DateTimeOffset DateError { get; set; }
    }
}
