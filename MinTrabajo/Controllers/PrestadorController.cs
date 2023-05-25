using Microsoft.AspNetCore.Mvc;
using MinTrabajo.Aplicaciones;
using MinTrabajo.Datos.Context;
using MinTrabajo.Datos.Repositories;
using MinTrabajo.Dominio.Model;
using System.Runtime.InteropServices;

namespace MinTrabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : Controller
    {

        private PrestadorService CreateService()
        {
            MinTra_Context db = new();
            PrestadorRepository repo = new(db);
            PrestadorService service = new(repo);
            return service;
        }
        /// <summary>
        /// Obtiene la lista de las vacantes por prestador
        /// </summary>
        /// <returns></returns>
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
                    VacantsModel =await service.GetVacantByPrestadores(getVacant);

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
        /// 
        /// </summary>
        /// <param name="postVacantMatch"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostVacantMatch")]
        public ActionResult<ResponseModel> PostVacantMatch([FromBody] List<UpdateCriteriosByVacantModel> requestAtributte)
        {
            ResponseModel response = new();
            var ListmatchByVacantModel = new List<UpdateCriteriosMatchByVacantModel>();

            try
            {
                foreach (var i in requestAtributte)
                {
                    if (i.atributtes.Count == 9)
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
                        response.Mensaje = "debe asegurarse de llevar los 9 criterios para cada vacante";
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
        /// obtener nombre de prestador por id de prestador
        /// </summary>
        /// <returns></returns>


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

        [HttpGet]
        [Route("GetpointOfAttention")]
        public ActionResult GetPointOfAttention(Guid prestadorId)
        {
            ResponseModel response = new();
            List<ListModel2> result = new();
            try
            {
                var service = CreateService();
                result = service.GetNamePointOfAttention(prestadorId);
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
            }
            response.ObjetoRespuesta = result;
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCompany")]
        public ActionResult GetCompanyByPointOfAttention(Guid PointOfAttentionId)
        {
            ResponseModel response = new();
            List<ListModel> result = new();
            try
            {
                var service = CreateService();
                result = service.GetCompany(PointOfAttentionId);
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
            }
            response.ObjetoRespuesta = result;
            return Ok(response);
        }

    }

}
