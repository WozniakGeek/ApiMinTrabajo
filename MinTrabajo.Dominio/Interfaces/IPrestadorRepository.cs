using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinTrabajo.Dominio.Model.ListVacantsModel;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IPrestadorRepository
    {
        Task<List<Vacants>> GetVacantByPrestador(GetVacantModel getVacant);
        ListModel2 GetNamePrestadorByPrestadorId(Guid PrestadorId);
        List<ListModel2> GetNamePointOfAttentionPrestadorId(Guid? PrestadorId);
        List<ListModel> GetCompanyPointOfAttentionId(Guid? PointOfAttention);
        bool PostCriteriosVacant(List<UpdateCriteriosMatchByVacantModel> UpdateAtributte);
    }
}
