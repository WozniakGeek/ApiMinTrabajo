using MinTrabajo.Datos.Context;
using MinTrabajo.Dominio.Interfaces;
using MinTrabajo.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static MinTrabajo.Dominio.Model.ListVacantsModel;

namespace MinTrabajo.Datos.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly MinTra_Context db;
        public PrestadorRepository(MinTra_Context _db)
        {
            db = _db;
        }
        public async Task<List<Vacants>> GetVacantByPrestador(GetVacantModel getVacant)
        {
            var GuidValue = new Guid();
            var getVacantSPModel = new List<GetVacantSPModel>();
            var listVacants = new List<Vacants>();
            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {
                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_VACANTES", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@PrestadoId", getVacant.PrestadorId));
                        cmd.Parameters.AddWithValue("@PuntoAtencion", getVacant.PointOfAttention == null ? (object)DBNull.Value : getVacant.PointOfAttention);
                        cmd.Parameters.AddWithValue("@Empresa", getVacant.CompanyId == null ? (object)DBNull.Value : getVacant.CompanyId);
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var guidtest = reader.GetGuid(8);
                            getVacantSPModel.Add(new GetVacantSPModel
                            {
                                IdVacant = reader.GetGuid(0),
                                NameVacant = reader.GetString(1),
                                Campus = reader.GetString(2),
                                CampusId = reader.GetInt32(3),
                                IsHidrocarburos = reader.GetBoolean(4),
                                prestadorName = reader.GetString(5),
                                PointAttentionName = reader.GetString(6),
                                PointAttentionId = reader.GetGuid(7),
                                VacanteMatchId = reader.GetGuid(8),
                                WeightDefault = reader.GetString(9),
                                VariableId = reader.GetInt32(10),
                                NameVariable = reader.GetString(11),
                                ValueVariable = reader.GetDecimal(12),
                            });

                        };
                        var getVacantSPModelGeneral = getVacantSPModel.Where(x => x.IsHidrocarburos == false).ToList().Take(1800);//cambiar el top
                        var GetVacanteAndName = (from a in getVacantSPModelGeneral
                                                 select new { id = a.IdVacant, Name = a.NameVacant, isMatch = a.VacanteMatchId }).Distinct().ToList();


                        foreach (var i in GetVacanteAndName)
                        {

                            listVacants.Add(new Vacants
                            {
                                VacanteId = i.id,
                                Vacante = i.Name,
                                Match = i.isMatch == GuidValue ? false : true,
                                CriteriosList =
                                                (from a in getVacantSPModelGeneral
                                                 where a.IdVacant == i.id
                                                 select new Criterios
                                                 {
                                                     VariableId = a.VariableId,
                                                     NombreVariable = a.NameVariable,
                                                     Peso = a.ValueVariable,

                                                 }).ToList()

                            });

                        }


                    }
                    connection.Close();

                }
                return listVacants;
            }
            catch (Exception ex)
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

        public List<ListModel2> GetNamePointOfAttentionPrestadorId(Guid PrestadorId)
        {
            try
            {
                var ListPointOfAttention = new List<ListModel2>();
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_PUNTOATENCION_BY_PRESTADORID", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@PrestadorId", PrestadorId));
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListPointOfAttention.Add(new ListModel2
                            {
                                Id = reader.GetGuid(0),
                                Nombre = reader.GetString(1)
                            });

                        }

                    }
                    connection.Close();


                }
                return ListPointOfAttention;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ListModel> GetCompanyPointOfAttentionId(Guid PointOfAttention)
        {
            try
            {
                var ListCompany = new List<ListModel>();
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_EMPRESAS_BY_PUNTOATENCION", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@PuntoAtencionId", PointOfAttention));
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListCompany.Add(new ListModel
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });

                        }

                    }
                    connection.Close();


                }
                return ListCompany;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
