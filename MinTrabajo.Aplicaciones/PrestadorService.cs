using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Aplicaciones
{
    public class PrestadorService
    {

        private readonly IPrestadorRepository IPrestadorRepo;


        public PrestadorService(IPrestadorRepository _prestadorRepo)
        {
            IPrestadorRepo = _prestadorRepo;
        }
        public List<ListModel> GetVacantByPrestadores(int PrestadorId)
        {
            try
            {
                List<ListModel> model = IPrestadorRepo.GetVacantByPrestador(PrestadorId);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListModel2 GetNamePrestador(Guid PrestadorId)
        {
            try
            {
                ListModel2 model = IPrestadorRepo.GetNamePrestadorByPrestadorId(PrestadorId);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListModel2> GetNamePointOfAttention(Guid PrestadorId)
        {
            try
            {
                List<ListModel2> model = IPrestadorRepo.GetNamePointOfAttentionPrestadorId(PrestadorId);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListModel> GetCompany(Guid PointOfAttention)
        {
            try
            {
                List<ListModel> model = IPrestadorRepo.GetCompanyPointOfAttentionId(PointOfAttention);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostUpdateCriteriosVacant(List<UpdateCriteriosMatchByVacantModel> UpdateCriteriosMatchByVacan)
        {
            try
            {
                bool model = IPrestadorRepo.PostCriteriosVacant(UpdateCriteriosMatchByVacan);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
