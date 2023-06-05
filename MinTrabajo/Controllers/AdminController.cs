using Microsoft.AspNetCore.Mvc;
using MinTrabajo.Aplicaciones;
using MinTrabajo.Datos.Context;
using MinTrabajo.Datos.Repositories;
using MinTrabajo.Dominio.Model;
using System.Diagnostics;
using static MinTrabajo.Dominio.Model.RequestUpdateParameters;

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


        /// <summary>
        /// Obtiene una lista de criterios de la base de datos.
        /// </summary>
        /// <returns>
        /// Retorna una lista de criterios.
        /// </returns>
        [HttpGet]
        [Route("GetCristerios")]

        public ActionResult GetListCriterios()
        {
            var response = new ResponseModel();
            var result = new List<CriterioModel>();
            try
            {
                var service = CreateService();
                result = service.GetCriterios();
                if (result.Count == 0 || result == null)
                {
                    response.Mensaje = "Ocurrió un error con la obtención de los datos";
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
                return BadRequest(response);
            }

            return Ok(response);
        }


        /// <summary>
        /// Gets a list of parameters from the database.
        /// </summary>
        /// <returns>A list of parameters from the database.</returns>
        [HttpGet]
        [Route("GetParametersBD")]
        public ActionResult GetListParametersBD()
        {
            var response = new ResponseModel();
            var result = new List<GetParameters>();
            try
            {
                var service = CreateService();
                result = service.GetParameters();
                if (result.Count == 0 || result == null)
                {
                    response.Mensaje = "Ocurrió un error con la obtención de los datos";
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
        ////The method is missing a return statement at the end.


        /// <summary>
        /// Updates the parameters in the database.
        /// </summary>
        /// <param name="updateParameters">The list of parameters to update.</param>
        /// <returns>A response model with the result of the update.</returns>
        [HttpPut]
        [Route("UpdateParametersBD")]
        public ActionResult UpdateParametersBD([FromBody] RequestUpdateParameters updateParameters)
        {
            var response = new ResponseModel();
            var result = new bool();
            var requestUpdateparameter = new List<parameters>();

            try
            {

                if (updateParameters.parameter.Count > 0)
                {
                    foreach (var i in updateParameters.parameter)
                    {
                        requestUpdateparameter.Add(new parameters
                        {
                            ParameterId = i.ParameterId,
                            table = i.table,
                            Value = i.Value,
                            StartingRange = i.StartingRange,
                            EndRange = i.EndRange

                        });
                    }
                    var service = CreateService();
                    result = service.UpdateParameters(requestUpdateparameter, updateParameters.User);
                    if (!result)
                    {
                        return NoContent();
                    }

                    response.ObjetoRespuesta = result;
                    return Ok(response);

                }
                else
                {
                    response.Mensaje = "Debe llenar la lista de parámetros";
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


        }



    }
}
