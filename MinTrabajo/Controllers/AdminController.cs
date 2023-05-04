using Microsoft.AspNetCore.Mvc;
using MinTrabajo.Aplicaciones;
using MinTrabajo.Datos.Context;
using MinTrabajo.Datos.Repositories;
using MinTrabajo.Dominio.Model;

namespace MinTrabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private AdminService CrearServicio()
        {
            MinTra_Context db = new();
            AdminRepository repo = new(db);
            AdminService service = new(repo);
            return service;
        }

        [HttpGet]
        [Route("GetCristerios")]

        public ActionResult GetListCriterios()
        {
            ResponseModel response = new();
            List<CriterioModel> result = new();
            try
            {
                var servicio = CrearServicio();
                result = servicio.GetCriterios();
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
        /// Metodo para editar criterios
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("EditionCriterion")]

        public ActionResult EditionCriterion()
        {
            ResponseModel response = new();
            try
            {

            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.IsValid = false;
            }
            //response.ObjetoRespuesta = result;
            return Ok(response);
        }
    }
}
