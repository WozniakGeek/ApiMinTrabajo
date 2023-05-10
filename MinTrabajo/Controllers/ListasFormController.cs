﻿using Microsoft.AspNetCore.Mvc;
using MinTrabajo.Aplicaciones;
using MinTrabajo.Datos.Context;
using MinTrabajo.Datos.Repositories;
using MinTrabajo.Dominio.Model;

namespace MinTrabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasFormController : ControllerBase
    {
    
        private ListasFormService CrearServicio()
        {
            MinTra_Context db = new();
            ListFormRepository repo = new(db);
            ListasFormService service = new(repo);//agregar parametro
            return service;
        }

        /// <summary>
        /// Obtiene la lista de los prestadores para administrador
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetListPrestadores")]
        public ActionResult<ResponseModel> GetListPrestadores()
        {
            ResponseModel response = new();
            List<ListModel2> result = new();
            try
            {
                var servicio = CrearServicio();
                result = servicio.GetAllListPrestadores();
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
        /// Obtiene la lista de las sedes para rol admin y prestador
        /// </summary>
        /// <returns></returns>
        /// 




        [HttpGet]
        [Route("GetListSedesByPrestadorId")]
        public ActionResult<ResponseModel> GetListSedes(int PrestadorId)
        {
            ResponseModel response = new();
            List<ListModel> result = new();
            try
            {
                var servicio = CrearServicio();
                result = servicio.GetAllListSedes(PrestadorId);
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
        /// Obtiene la lista de los estados para rol admin y prestador
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetListStatus")]
        public ActionResult<ResponseModel> GetListStatus()
        {
            ResponseModel response = new();
            List<ListModel> result = new();
            try
            {
                var servicio = CrearServicio();
                result = servicio.GetAllListStatus();
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
        [Route("GetListCriterios")]
        public ActionResult<ResponseModel> GetListCriterios()
        {
            ResponseModel response = new();
            List<ListModel> result = new();
            try
            {
                var service = CrearServicio();
                result = service.GetAllListCriterios();
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
