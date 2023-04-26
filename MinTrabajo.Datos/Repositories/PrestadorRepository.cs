using MinTrabajo.Datos.Context;
using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Datos.Repositories
{
    public class PrestadorRepository : IPrestadorRepository<ListModel, string>
    {
        private readonly MinTra_Context db;
        public PrestadorRepository(MinTra_Context _db)
        {
            db = _db;
        }

        public List<ListModel> GetVacantByPrestador(int PrestadorId)
        {
            try
            {
                var ListVacants = new List<ListModel>();
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    //CONSULTA EN BASE DE DATOS LAS LISTAS vacantes por prestador
                    connection.Close();
                    int i = 0;
                    while (i < 10)
                    {
                        ListVacants.Add(new ListModel
                        {
                            Id = i,
                            Nombre = "Vacantes por prestador " + i
                        });
                        i++;
                    }

                }
                return ListVacants;
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
