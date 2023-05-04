using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IAdminRepository<TEntityList, TMsg>
    {
        List<TEntityList> GetCriterios();
    }
}
