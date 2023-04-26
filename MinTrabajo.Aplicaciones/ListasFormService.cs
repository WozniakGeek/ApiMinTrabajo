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
        private readonly IListFormRepository<ListModel, string> ListFormRepo;


        public ListasFormService(IListFormRepository<ListModel, string> _listFormRepo)
        {
            ListFormRepo = _listFormRepo;
        }


        public List<ListModel> GetAllListPrestadores()
        {
            try
            {
                List<ListModel> model = ListFormRepo.GetListPrestadores();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListModel> GetAllListSedes()
        {
            try
            {
                List<ListModel> model = ListFormRepo.GetListSedes();
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

    }
}
