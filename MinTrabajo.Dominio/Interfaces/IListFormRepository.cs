using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IListFormRepository<TEntityList, TMsg>
    {
        List<TEntityList> GetListPrestadores();
        List<TEntityList> GetListSedes();
        List<TEntityList> GetListStatus();

        //TMsg PostAdminCIF(TEntityReq entityReq);
    }
}
