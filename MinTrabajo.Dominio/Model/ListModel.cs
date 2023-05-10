using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class ListModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class ListModel2
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
    }
}
