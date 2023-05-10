using MinTrabajo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MinTrabajo.Datos.Context;
using MinTrabajo.Dominio.Model;
using System.Data.SqlClient;

namespace MinTrabajo.Datos.Repositories
{
    public class ListFormRepository : IListFormRepository
    {
        private readonly MinTra_Context db;
        public ListFormRepository(MinTra_Context _db)
        {
            db = _db;
        }

        public List<ListModel2> GetListPrestadores()
        {
            var ListPrestadores = new List<ListModel2>();

            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_LISTPRESTADOR", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            ListPrestadores.Add(new ListModel2
                            {
                                Id = reader.GetGuid(0),
                                Nombre = reader.GetString(1),
                            });
                        }


                    }
                    connection.Close();


                }
                return ListPrestadores;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ListModel> GetListSedes( int PrestadorId)
        {
            var ListSedes = new List<ListModel>();
            //string? mensajeSP = "";
            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    //CONSULTA EN BASE DE DATOS LAS LISTAS SEDES POR PRESTADOR
                    connection.Close();
                    int i = 0;
                    while (i < 10)
                    {
                        ListSedes.Add(new ListModel
                        {
                            Id = i,
                            Nombre = "Sede " + i
                        });
                        i++;
                    }

                }
                return ListSedes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ListModel> GetListStatus()
        {
            var ListStatus = new List<ListModel>();
            //string? mensajeSP = "";
            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    using (SqlCommand cmd = new("GetStatusList", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            
                            ListStatus.Add(new ListModel
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                            });
                        }
                    

                    }
                    connection.Close();


                }
                return ListStatus;

              
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<ListModel> GetListCriterios()
        {
            var ListStatus = new List<ListModel>();
            //string? mensajeSP = "";
            try
            {
                SqlConnectionStringBuilder dbContext = db.DBContext();
                using SqlConnection connection = new(dbContext.ConnectionString);
                {

                    connection.Open();
                    using (SqlCommand cmd = new("SP_GET_ONLY_CRITERIOS", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            ListStatus.Add(new ListModel
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                            });
                        }


                    }
                    connection.Close();


                }
                return ListStatus;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
