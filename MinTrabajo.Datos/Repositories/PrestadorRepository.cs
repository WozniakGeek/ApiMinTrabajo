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
    public class PrestadorRepository : IPrestadorRepository
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

        public bool PostCriteriosVacant(List<UpdateCriteriosMatchByVacantModel> UpdateAtributte)
        {
            try
            {

                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    foreach (var i in UpdateAtributte)
                    {
                        connection.Open();

                        using (SqlCommand cmd = new("SP_INSERT_VACANTE_MATCH", connection))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@vacanteId", i.VacantId));
                            cmd.Parameters.Add(new SqlParameter("@variableId", i.atributte));
                            cmd.Parameters.Add(new SqlParameter("@valor", i.weight));
                            cmd.Parameters.Add(new SqlParameter("@usuarioCreacion", i.User));
                            var reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {

                            }
                        }
                        connection.Close();
                    }

                    return true;

                }
            }

            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public ListModel2 GetNamePrestadorByPrestadorId(Guid PrestadorId)
        {
            try
            {
                var Prestador = new ListModel2();
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_PRESTADOR_BY_ID", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@PrestadorId", PrestadorId));
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Prestador.Id = reader.GetGuid(0);
                            Prestador.Nombre = reader.GetString(1);
                        }
                    }
                    connection.Close();


                }
                return Prestador;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
