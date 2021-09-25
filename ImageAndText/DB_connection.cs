using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_con_nmsp
{
   public class DB_connection
    {
        SqlConnection sqlConnection;
        public SqlConnection dbCon()
        {
            
            string connectionString = @"Data Source=TIMOFEY\SQLEXPRESS;Initial Catalog=Images;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();

            return sqlConnection;
        }
        public SqlConnection open()
        {
            sqlConnection.Open();
            return sqlConnection;
        }
        public SqlConnection close(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
            return sqlConnection;
        }
    }
}
