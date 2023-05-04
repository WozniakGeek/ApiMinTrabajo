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
        private AdminService CreateService()
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
                var servicio = CreateService();
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
        /// Metodo para editar criterios desde administrador
        /// </summary>
        /// <returns></returns>

        [HttpPut]
        [Route("UpdateCriterios")]

        public ActionResult UpdateCriterion([FromBody] RequestAtributteModel requestAtributte)
        {


            ResponseModel response = new();
            try
            {
                var requestUpdateAtributte = new List<RequestUpdateAtributte>();                
                foreach (var i in requestAtributte.atributtes)
                {

                    requestUpdateAtributte.Add(new RequestUpdateAtributte
                    {
                        User = requestAtributte.User,
                        status = i.status,
                        atributte = i.atributte,
                        weight = i.weight

                    });

                }
                var service = CreateService();
                var result = service.UpdateCriterios(requestUpdateAtributte);
                if (!result)
                {
                    response.Mensaje = "Error al actualizar los criterios ";
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
    }
}
