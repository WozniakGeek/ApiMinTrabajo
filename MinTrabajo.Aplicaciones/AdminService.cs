using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Aplicaciones
{
    public class AdminService
    {

        private readonly IAdminRepository<CriterioModel, string> IAdminRepo;


        public AdminService(IAdminRepository<CriterioModel, string> _adminRepo)
        {
            IAdminRepo = _adminRepo;
        }

        public List<CriterioModel> GetCriterios()
        {
            try
            {
                List<CriterioModel> model = IAdminRepo.GetCriterios();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
