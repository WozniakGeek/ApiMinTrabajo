using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IListFormRepository
    {
        List<ListModel2> GetListPrestadores();
        List<ListModel> GetListSedes(int Prestador);
        List<ListModel> GetListStatus();
        List<ListModel> GetListCriterios();
        List<ListModel> SetErrorsDB(ErrorModelSet errorModel);
        List<ErrorModel> GetErrorsBD();
        List<ErrorModel> GetErrorsFilterBD(DateTime DateStart,DateTime DateEnd);


        //TMsg PostAdminCIF(TEntityReq entityReq);
    }
}
