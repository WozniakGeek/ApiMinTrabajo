﻿using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Interfaces
{
    public interface IPrestadorRepository
    {
        List<ListModel> GetVacantByPrestador(int PrestadorId);
        ListModel2 GetNamePrestadorByPrestadorId(Guid PrestadorId);
        List<ListModel2> GetNamePointOfAttentionPrestadorId(Guid PrestadorId);
        List<ListModel> GetCompanyPointOfAttentionId(Guid PointOfAttention);
        bool PostCriteriosVacant(List<UpdateCriteriosMatchByVacantModel> UpdateAtributte);
    }
}
