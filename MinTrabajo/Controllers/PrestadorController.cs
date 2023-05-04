using Microsoft.AspNetCore.Mvc;
using MinTrabajo.Aplicaciones;
using MinTrabajo.Datos.Context;
using MinTrabajo.Datos.Repositories;
using MinTrabajo.Dominio.Model;

namespace MinTrabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : Controller
    {

        private PrestadorService CrearServicio()
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
                    var servicio = CrearServicio();
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
            if (PrestadorId > 0 || PrestadorId != 0)
            {
                List<ListModel> VacantsModel = new();
                try
                {
                    var servicio = CrearServicio();
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

    }

}
