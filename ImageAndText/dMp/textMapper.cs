using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAndText
{
    class textMapper
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=DESKTOP-A643SOE\SQLEXPRESS;Initial Catalog=Digital;Integrated Security=True";

        public bool add(Text o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                
                SqlCommand command = new SqlCommand("INSERT INTO [Texts] (Textt) " +
                       "VALUES (@Textt)", sqlConnection);
                command.Parameters.AddWithValue("Textt", o.Textt);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool read(Text o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataReader sqlReader = null;
            try
            {

                SqlCommand command = new SqlCommand("SELECT * FROM [Texts] WHERE [TextID]=2", sqlConnection);
                //command.Parameters.AddWithValue("Textt", o.Textt);
                sqlReader = command.ExecuteReader();
                sqlReader.Read();
                o.Textt = Convert.ToString(sqlReader["Textt"]);
                //command.ExecuteNonQuery();
                sqlReader.Close();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
