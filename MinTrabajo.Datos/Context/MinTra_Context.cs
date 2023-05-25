using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTrabajo.Datos.Context
{
    public class MinTra_Context
    {
        public SqlConnectionStringBuilder DBContext()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = "mintrabajodb.database.windows.net",
                UserID = "micrositio",
                Password = "M1nTr4H1t55*",
                InitialCatalog = "DB_SPE_MOTOR"
            };
            return builder;
        }


    }
}
