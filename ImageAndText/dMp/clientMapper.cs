using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_con_nmsp;
using ImageAndText;
using System.Windows.Forms;
namespace clientMapper_nmsp
{
    class clientMapper
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=DESKTOP-A643SOE\SQLEXPRESS;Initial Catalog=Digital;Integrated Security=True";
        // Добавление нового клиента 
        public bool add(Client o)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [Users] (Name, Surname, PhoneNumber, Login, email) " +
                    "VALUES (@Name, @Surname, @PhoneNumber,@Login, @email)", sqlConnection);
                command.Parameters.AddWithValue("Name", o.Name);
                command.Parameters.AddWithValue("Surname", o.Surname);
                command.Parameters.AddWithValue("PhoneNumber", o.PhoneNumber);
                command.Parameters.AddWithValue("Login", o.User_login);
                command.Parameters.AddWithValue("email", o.email);

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
        // четение информации о клиенте для открытия личного кабинета
        public Client read(Client o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataReader sqlReader = null;
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Users] " +
                        "WHERE [Login]=@Login", sqlConnection);
                command.Parameters.AddWithValue("Login", o.User_login);
                sqlReader = command.ExecuteReader();
                sqlReader.Read();
                o.Name = Convert.ToString(sqlReader["Name"]);
                o.Surname = Convert.ToString(sqlReader["Surname"]);
                o.PhoneNumber = Convert.ToString(sqlReader["PhoneNumber"]);
                o.UserID = Convert.ToInt32(sqlReader["UserID"]);
                o.email = Convert.ToString(sqlReader["email"]);
                o.User_login = Convert.ToString(sqlReader["Login"]);
                sqlReader.Close();
                sqlConnection.Close();
                return o;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return o;
            }

        }
        public bool update(Client o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                SqlCommand command = new SqlCommand("UPDATE [Users] SET [Name]= @Name, [Surname]=@Surname, [PhoneNumber]=@PhoneNumber," +
                    " [email]=@email WHERE [Login]=@Login", sqlConnection);
                command.Parameters.AddWithValue("Name", o.Name);
                command.Parameters.AddWithValue("Surname", o.Surname);
                command.Parameters.AddWithValue("PhoneNumber", o.PhoneNumber);
                command.Parameters.AddWithValue("Login", o.User_login);
                command.Parameters.AddWithValue("email", o.email);

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
        public Client read(Account_nmsp.Account o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Client cl = new Client();
            //DB_con_nmsp.DB_connection connect = new DB_con_nmsp.DB_connection();
            SqlDataReader sqlReader = null;
            try // сначала ищем в таб аккаунтов а потом нужный аккаунт по имени
            {

                SqlCommand command = new SqlCommand("SELECT * FROM [Accounts] " +
                    "WHERE [Login]=@Login", sqlConnection);
                command.Parameters.AddWithValue("Login", o.login);

                int i = Convert.ToInt32(command.ExecuteScalar());

                if (i != 0)
                {
                    sqlReader = command.ExecuteReader();
                    sqlReader.Read();     // очень важная строчка, без неё не работает
                    string pass = Convert.ToString(sqlReader["Password"]);
                    if (pass == o.password)
                    {
                        sqlReader.Close();
                        sqlReader = null;
                        //MessageBox.Show("ITs OK!");
                        SqlCommand command2 = new SqlCommand("SELECT * FROM [Users] " +
                       "WHERE [Login]=@Login", sqlConnection);
                        command2.Parameters.AddWithValue("Login", o.login);
                        sqlReader = command2.ExecuteReader();
                        sqlReader.Read();
                        cl.Name = Convert.ToString(sqlReader["Name"]);
                        cl.Surname = Convert.ToString(sqlReader["Surname"]);
                        cl.PhoneNumber = Convert.ToString(sqlReader["PhoneNumber"]);
                        cl.UserID = Convert.ToInt32(sqlReader["UserID"]);
                        cl.email = Convert.ToString(sqlReader["email"]);
                        cl.User_login = Convert.ToString(sqlReader["Login"]);
                        sqlReader.Close();
                        sqlConnection.Close();
                        return cl;

                    }
                    else
                    {
                        MessageBox.Show("Введён неверный пароль!");
                        sqlConnection.Close();
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином не найден!");
                    sqlConnection.Close();
                    return null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();
                return null;
            }
        }
    }
}
