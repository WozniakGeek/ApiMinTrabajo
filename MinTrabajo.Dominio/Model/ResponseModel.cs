using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Dominio.Model
{
    public class ResponseModel
    {

        /// <summary>
        /// true si el consumo de la API fue valido
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Mensaje con información del consumo de la API
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Objeto con el Modelo de respuesta segun API consumida
        /// </summary>
        public object ObjetoRespuesta { get; set; }
        public ResponseModel()
        {
            IsValid = true;
            Mensaje = "Operación exitosa";
        }
    }
}
