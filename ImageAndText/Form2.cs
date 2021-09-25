using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAndText
{
    public partial class Form2 : Form
    {
        Client cl = new Client();  // создаем глобально видимый класс  // А зачем? // нет, он  нужен

        public Form2 (Client o)     // получаем объект класса Client Из form1
        {
          
            cl.User_login = o.User_login;  
            
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                 !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                 !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                 !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                cl.Name = textBox1.Text;                    // Присваиваем параметры из формы
                cl.Surname = textBox2.Text;
                cl.PhoneNumber = textBox3.Text;
                cl.email = textBox4.Text;
                // Создаем DataMapper
                //clientMapper_nmsp.clientMapper clM = new clientMapper_nmsp.clientMapper();
                //if(clM.add(cl) == true) // если add вернул true 
                if(cl.insertNewClient())
                {
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();  // 
                    label11.ForeColor = Color.Green;
                    label11.Text = "Вы успешно зарегистрированы!!!";
                    MessageBox.Show("Вы успешно зарегистрированы!!!");
                    this.Close();
                    if (cl.openAccount()!=null)
                    {
                        Form3 fm3 = new Form3(cl.openAccount());
                        fm3.Show();
                    }
                }
                else
                {
                    label11.ForeColor = Color.Red;
                    label11.Text = "Регистрация не выполнена!";
                }
            }
            else
            {
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.ForeColor = Color.Red;
                label11.Text = "Одно из ключевых полей не заполнено!";
            }
        }
    }
}
