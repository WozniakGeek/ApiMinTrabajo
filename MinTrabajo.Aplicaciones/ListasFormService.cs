using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Aplicaciones
{
    public class ListasFormService
    {
        private readonly IListFormRepository ListFormRepo;


        public ListasFormService(IListFormRepository _listFormRepo)
        {
            ListFormRepo = _listFormRepo;
        }


        public List<ListModel2> GetAllListPrestadores()
        {
            try
            {
                List<ListModel2> model = ListFormRepo.GetListPrestadores();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListModel> GetAllListSedes(int PrestadorId)
        {
            try
            {
                List<ListModel> model = ListFormRepo.GetListSedes(PrestadorId);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListModel> GetAllListStatus()
        {
            try
            {
                List<ListModel> model = ListFormRepo.GetListStatus();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListModel> GetAllListCriterios()
        {
            try
            {
                List<ListModel> model = ListFormRepo.GetListCriterios();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public List<ListModel> SetErrors(ErrorModelSet errorModel)
        {
            try
            {
                List<ListModel> model = ListFormRepo.SetErrorsDB(errorModel);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ErrorModel> GetErrors()
        {
            try
            {
                List<ErrorModel> model = ListFormRepo.GetErrorsBD();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ErrorModel> GetErrorsFilter(DateTime DateStart, DateTime DateEnd)
        {
            try
            {
                List<ErrorModel> model = ListFormRepo.GetErrorsFilterBD(DateStart, DateEnd);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
