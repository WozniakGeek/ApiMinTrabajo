using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IPrestadorRepository<TEntityList, TMsg>
    {
        List<TEntityList> GetVacantByPrestador(int PrestadorId);
    }
}
