using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IAdminRepository
    {
        List<CriterioModel> GetCriterios();

        bool UpdateCriterios(List<RequestUpdateAtributte> atributtes);
    }
}
