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

        private readonly IPrestadorRepository<ListModel, string> IPrestadorRepo;


        public PrestadorService(IPrestadorRepository<ListModel, string> _prestadorRepo)
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


    }
}
