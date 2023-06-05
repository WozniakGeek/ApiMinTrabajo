using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinTrabajo.Dominio.Model.RequestUpdateParameters;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IAdminRepository
    {
        List<CriterioModel> GetCriterios();

        bool UpdateCriterios(List<RequestUpdateAtributte> atributtes);
        bool UpdateParametersAdmin(List<parameters> parameter, string? username);
        List<GetParameters> GetParametersAdmin();
    }
}
