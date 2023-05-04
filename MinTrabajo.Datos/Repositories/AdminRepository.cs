using MinTrabajo.Datos.Context;
using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Datos.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        private readonly MinTra_Context db;
        public AdminRepository(MinTra_Context _db)
        {
            db = _db;
        }

        public List<CriterioModel> GetCriterios()
        {
            try
            {
                var ListCriterios = new List<CriterioModel>();
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {
                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_CRITERIO", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            ListCriterios.Add(new CriterioModel
                            {
                                VariableId = reader.GetInt32(0),
                                PesoDefault = reader.GetDecimal(4),
                                NombreEstado = reader.GetInt32(9),
                                FechaCreacion = reader.GetString(6),
                                FechaModificacion = reader.GetString(8),

                            });
                        }


                    }
                    connection.Close();

                }
                return ListCriterios;
            }

            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCriterios(List<RequestUpdateAtributte> atributtes)
        {
            var flag = false;
            try
            {
                var NewAtributtes = atributtes;
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {
                    foreach (var i in NewAtributtes)
                    {
                        connection.Open();

                        using (SqlCommand cmd = new("SP_UPDATE_CRITERIOS", connection))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@variableId", i.atributte));
                            cmd.Parameters.Add(new SqlParameter("@user", i.User));
                            cmd.Parameters.Add(new SqlParameter("@peso", i.weight));
                            cmd.Parameters.Add(new SqlParameter("@estado", i.status));
                            var reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {

                            }
                        }
                        connection.Close();
                    }
                    flag = true;

                }
                return flag;
            }

            catch (Exception ex)
            {
                flag = false;
                throw;
            }
        }
    }
}
