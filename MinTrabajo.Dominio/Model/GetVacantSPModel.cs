using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public  class GetVacantSPModel
    {
        public Guid IdVacant { get; set; }
        public string? NameVacant { get; set; }
        public string? Campus { get; set; }
        public int CampusId { get; set; }
        public bool IsHidrocarburos { get; set; }
        public string? prestadorName { get; set; }
        public string? PointAttentionName { get; set; }
        public Guid? PointAttentionId { get; set; }
        public Guid? VacanteMatchId { get; set; }
        public string? WeightDefault { get; set; }
        public int VariableId { get; set; }
        public string? NameVariable { get; set; }
        public decimal ValueVariable { get; set; }
    }
}
