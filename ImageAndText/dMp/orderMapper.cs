using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAndText
{
    class orderMapper
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=DESKTOP-A643SOE\SQLEXPRESS;Initial Catalog=Digital;Integrated Security=True";

        public bool add(Order o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Orders] (UserID, UserName, UserSurname, UserPhone, Date) " +
                 "VALUES (@UserID, @UserName, @UserSurname,@UserPhone, @Date)", sqlConnection);
                command.Parameters.AddWithValue("UserID", o.User_ID);
                command.Parameters.AddWithValue("UserName", o.UserName);
                command.Parameters.AddWithValue("UserSurname", o.UserSurname);
                command.Parameters.AddWithValue("UserPhone", o.UserPhone);
                command.Parameters.AddWithValue("Date", o.Date);

                command.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();
                return false;
            }
        }
    }
}
