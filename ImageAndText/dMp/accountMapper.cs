using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageAndText;

namespace accountMapper_nmsp
{
   
    class accountMapper
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=DESKTOP-V3IG0N4\SQLEXPRESS;Initial Catalog=Digital;Integrated Security=True";
        

        public bool isExist(Account_nmsp.Account o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            //DB_con_nmsp.DB_connection connect = new DB_con_nmsp.DB_connection();
            try
            {
                SqlCommand checkExisting = new SqlCommand("SELECT * FROM [Accounts] " +
                "WHERE [Login]=@Login", sqlConnection);
                checkExisting.Parameters.AddWithValue("Login", o.login);
                int i = Convert.ToInt32(checkExisting.ExecuteScalar());
                sqlConnection.Close();
                if (i == 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
            }
            return false;
        }
        public bool add(Account_nmsp.Account o)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //DB_con_nmsp.DB_connection connect = new DB_con_nmsp.DB_connection();
            //SqlTransaction transaction = connect.establishConnection().BeginTransaction();


            try
            {
                //sqlConnection.Open();
                SqlCommand checkExisting = new SqlCommand("SELECT * FROM [Accounts] " +
                "WHERE [Login]=@Login", sqlConnection);
                //---------------------начало транзакции--------------------------------------
                //checkExisting.Transaction = transaction;                                    //
                //----------------------------------------------------------------------------
                checkExisting.Parameters.AddWithValue("Login", o.login);
                int i = Convert.ToInt32(checkExisting.ExecuteScalar());
                
                if (i == 0)
                {
                    //sqlConnection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO [Accounts] (Login, Password) " +
                    "VALUES (@Login, @Password)", sqlConnection);
                    command.Parameters.AddWithValue("Login", o.login);
                    command.Parameters.AddWithValue("Password", o.password);

                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    //transaction.Commit();
                    //**************окончание транзакции**************************************
                    return true;
                }
                else
                {
                    sqlConnection.Close();
                    MessageBox.Show("Введённый вами логин уже существует!");
                    //transaction.Rollback();
                    return false;
                }
            }

            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //transaction.Rollback();
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
