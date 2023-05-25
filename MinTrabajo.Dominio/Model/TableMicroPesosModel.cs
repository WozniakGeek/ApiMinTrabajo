using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class TableMicroPesosModel
    {
        public Guid PesoVariableId { get; set; }
        public Guid VacanteId { get; set; }
        public int VariableId { get; set; }
        public string? NombreVariable { get; set; }
        public decimal Peso { get; set; }
        public string? UsuarioCreacion { get; set; }
        public string? FechaCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public string? FechaModificacion { get; set; }
    }
}
