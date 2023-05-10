using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IPrestadorRepository
    {
        List<ListModel> GetVacantByPrestador(int PrestadorId);
        ListModel2 GetNamePrestadorByPrestadorId(Guid PrestadorId);
        bool PostCriteriosVacant(List<UpdateCriteriosMatchByVacantModel> UpdateAtributte);
    }
}
