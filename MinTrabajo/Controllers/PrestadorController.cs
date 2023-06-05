using Microsoft.AspNetCore.Mvc;
using MinTrabajo.Aplicaciones;
using MinTrabajo.Datos.Context;
using MinTrabajo.Datos.Repositories;
using MinTrabajo.Dominio.Model;
using System.Net;
using System.Runtime.InteropServices;

namespace MinTrabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : Controller
    {

        /// <summary>
        /// Creates a new instance of PrestadorService.
        /// </summary>
        /// <returns>A new instance of PrestadorService.</returns>
        private PrestadorService CreateService()
        {
            MinTra_Context db = new();
            PrestadorRepository repo = new(db);
            PrestadorService service = new(repo);
            return service;
        }
        /// <summary>
        /// Gets a list of vacant positions based on the provided PrestadorId, PointAttention and Company.
        /// </summary>
        /// <param name="prestadorId">The PrestadorId to search for.</param>
        /// <param name="PointAttention">The PointAttention to search for.</param>
        /// <param name="Company">The Company to search for.</param>
        /// <returns>A list of vacant positions.</returns>

        [HttpGet]
        [Route("GetVacants")]
        public async Task<ActionResult> GetVacants(Guid prestadorId, Guid PointAttention, int Company)
        {

            ResponseModel response = new();
            GetVacantModel getVacant = new();
            var VacantsModel = new List<ListVacantsModel.Vacants>();
            try
            {
                if (prestadorId != Guid.Empty)
                {
                    getVacant.PrestadorId = prestadorId;
                    if (PointAttention != Guid.Empty)
                    {
                        getVacant.PointOfAttention = PointAttention;
                        if (Company > 0)
                        {
                            getVacant.CompanyId = Company;
                        }
                        else { getVacant.CompanyId = null; }
                    }
                    else { getVacant.PointOfAttention = null; }
                    var service = CreateService();
                    VacantsModel = await service.GetVacantByPrestadores(getVacant);

                }
                else
                {
                    response.Mensaje = "El PrestadorId no puede ser vacio";
                    response.IsValid = false;
                    return BadRequest(response);
                }


            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
            }
            //response.ObjetoRespuesta = VacantsModel;

            return Ok(VacantsModel);
        }




        /// <summary>
        /// PostVacantMatch updates the criteria for a given vacancy
        /// </summary>
        /// <param name="requestAtributte">List of UpdateCriteriosByVacantModel</param>
        /// <returns>ResponseModel with the result of the operation</returns>
        [HttpPost]
        [Route("PostVacantMatch")]
        public ActionResult<ResponseModel> PostVacantMatch([FromBody] List<UpdateCriteriosByVacantModel> requestAtributte)
        {
            var response = new ResponseModel();
            var ListmatchByVacantModel = new List<UpdateCriteriosMatchByVacantModel>();

            try
            {
                foreach (var i in requestAtributte)
                {
                    if (i.atributtes.Count == 6)
                    {
                        foreach (var j in i.atributtes)
                        {
                            ListmatchByVacantModel.Add(new UpdateCriteriosMatchByVacantModel
                            {
                                VacantId = i.VacantId,
                                atributte = j.atributte,
                                weight = j.weight,
                                User = j.User

                            });
                        }

                    }
                    else
                    {
                        response.Mensaje = "Debe asegurarse de llevar los 6 criterios para cada vacante";
                        response.IsValid = false;
                        break;
                    }
                }


                var service = CreateService();
                var result = service.PostUpdateCriteriosVacant(ListmatchByVacantModel);
                if (!result)
                {
                    response.Mensaje = "No se insertaron los datos correctamente";
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
            }


            return Ok(response);
        }
        




        /// <summary>
        /// Gets the name of the prestador.
        /// </summary>
        /// <param name="prestadorId">The prestador identifier.</param>
        /// <returns>
        /// The name of the prestador.
        /// </returns>
        [HttpGet]
        [Route("GetNamePrestador")]
        public ActionResult GetPrestador(Guid prestadorId)
        {
            ResponseModel response = new();
            ListModel2 result = new();
            try
            {
                var service = CreateService();
                result = service.GetNamePrestador(prestadorId);
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
            }
            response.ObjetoRespuesta = result;
            return Ok(response);
        }

        /// <summary>
        /// Gets the point of attention for the given prestadorId.
        /// </summary>
        /// <param name="prestadorId">The prestador identifier.</param>
        /// <returns>A list of ListModel2 objects.</returns>
        [HttpGet]
        [Route("GetpointOfAttention")]
        public ActionResult GetPointOfAttention(Guid? prestadorId)
        {
            var response = new ResponseModel();
            var result = new List<ListModel2>();
            try
            {
                if (prestadorId != null)
                {
                    var service = CreateService();
                    result = service.GetNamePointOfAttention(prestadorId);
                    if (result.Count == 0)
                    {
                        return NoContent();
                    }
                }
                else
                {
                    response.Mensaje = "El PrestadorId no puede ser vacio";
                    response.IsValid = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
                return BadRequest(response);
            }
            response.ObjetoRespuesta = result;
            return Ok(response);
        }
       



        /// <summary>
        /// Gets a list of companies associated with a given Point of Attention.
        /// </summary>
        /// <param name="PointOfAttentionId">The Point of Attention identifier.</param>
        /// <returns>A list of companies associated with the given Point of Attention.</returns>
        [HttpGet]
        [Route("GetCompany")]
        public ActionResult GetCompanyByPointOfAttention(Guid? PointOfAttentionId)
        {
            var response = new ResponseModel();
            var result = new List<ListModel>();
            try
            {
                if (PointOfAttentionId != null)
                {
                    var service = CreateService();
                    result = service.GetCompany(PointOfAttentionId);
                    if (result.Count == 0)
                    {
                        return NoContent();
                    }

                }
                else
                {
                    response.Mensaje = "El Punto de atencion no puede ser vacio";
                    response.IsValid = false;
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
                return BadRequest(response);
            }
            response.ObjetoRespuesta = result;
            return Ok(response);
        }

    }

}
