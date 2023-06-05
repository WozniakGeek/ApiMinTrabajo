using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinTrabajo.Dominio.Model.RequestUpdateParameters;

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
        
        public List<GetParameters> GetParameters()
        {
            try
            {
                var model = IAdminRepo.GetParametersAdmin();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public bool UpdateParameters(List<parameters> atributtes, string? username)
        {
            try
            {
                var model = IAdminRepo.UpdateParametersAdmin(atributtes, username);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
