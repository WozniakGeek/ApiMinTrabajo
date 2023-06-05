using MinTrabajo.Datos.Context;
using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static MinTrabajo.Dominio.Model.RequestAtributteModel;
using static MinTrabajo.Dominio.Model.RequestUpdateParameters;

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

        public List<GetParameters> GetParametersAdmin()
        {
            var getParameters = new List<GetParameters>();
            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {
                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_TABLE_PARAMETERS", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            var DateConvert = reader.GetDateTimeOffset(9).DateTime;
                            var formattedDate = DateConvert.ToString("dd-MM-yyyy");

                            getParameters.Add(new GetParameters
                            {
                                ParameterId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Typevalue = SafeGetString(reader, 3),
                                Table = SafeGetString(reader, 4),
                                Value = SafeGetString(reader, 5),
                                StartingRange = SafeGetDecimal(reader, 6),
                                EndRange = SafeGetDecimal(reader, 7),
                                Proccess = SafeGetString(reader, 8),
                                ModifyDate = formattedDate,
                                Status = reader.GetInt32(10)

                            });
                        }
                    }
                    connection.Close();
                }
                return getParameters;


            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public bool UpdateParametersAdmin(List<parameters> parameter, string username)
        {
            var flag = false;
            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {
                    foreach (var i in parameter)
                    {
                        connection.Open();

                        using (SqlCommand cmd = new("SP_UPDATE_PARAMETERS", connection))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@parametroId", i.ParameterId));
                            cmd.Parameters.Add(new SqlParameter("@tabla", i.table));
                            cmd.Parameters.Add(new SqlParameter("@valor", i.Value));
                            cmd.Parameters.Add(new SqlParameter("@RangoInicial", i.StartingRange));
                            cmd.Parameters.Add(new SqlParameter("@RangoFinal", i.EndRange));
                            cmd.Parameters.Add(new SqlParameter("@usuarioModificacion", username));
                            var reader = cmd.ExecuteReader();

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

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public decimal SafeGetDecimal(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDecimal(colIndex);
            return decimal.Zero;
        }
      


    }
}
