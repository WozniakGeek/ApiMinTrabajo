using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class GetVacantModel
    {
        [Required]     
        public Guid PrestadorId { get; set; }
        public Guid? PointOfAttention { get; set; }
        public int? CompanyId { get; set; }
    }
}
