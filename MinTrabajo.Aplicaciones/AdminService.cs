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

        private readonly IAdminRepository IAdminRepo;


        public AdminService(IAdminRepository _adminRepo)
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

        public bool UpdateCriterios( List<RequestUpdateAtributte> atributteS)
        {
            try
            {
                bool model = IAdminRepo.UpdateCriterios(atributteS);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
