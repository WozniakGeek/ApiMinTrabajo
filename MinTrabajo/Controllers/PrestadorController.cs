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
        [Route("GetVacantByPrestadorMatch")]
        public ActionResult GetVacantByPrestador(int PrestadorId)
        {
            ResponseModel response = new();
            if (PrestadorId > 0 || PrestadorId != 0)
            {
                List<ListModel> VacantsModel = new();
                try
                {
                    var servicio = CreateService();
                    VacantsModel = servicio.GetVacantByPrestadores(PrestadorId);
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;
                    response.IsValid = false;
                }
                response.ObjetoRespuesta = VacantsModel;

            }
            else
            {
                response.Mensaje = "El Valor PrestadorId no puede ser vacio o Cero";
                response.IsValid = false;

            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetVacantByPrestadorNoMatch")]
        public ActionResult GetVacantByPrestadorNoMatch(int PrestadorId)
        {

            ResponseModel response = new();
            try
            {
                if (PrestadorId > 0 || PrestadorId != 0)
                {
                    List<ListModel> VacantsModel = new();

                    var servicio = CreateService();
                    VacantsModel = servicio.GetVacantByPrestadores(PrestadorId);

                    response.ObjetoRespuesta = VacantsModel;

                }
                else
                {
                    response.Mensaje = "El Valor PrestadorId no puede ser vacio o Cero";
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
        /// 
        /// </summary>
        /// <param name="postVacantMatch"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostVacantMatch")]
        public ActionResult <ResponseModel> PostVacantMatch([FromBody] List<UpdateCriteriosByVacantModel> requestAtributte)
        {
            ResponseModel response = new();
            var ListmatchByVacantModel=new List<UpdateCriteriosMatchByVacantModel>();   

            try
            {
                foreach(var i in requestAtributte)
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
        public ActionResult GetPrestador( Guid prestadorId)
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

    }

}
