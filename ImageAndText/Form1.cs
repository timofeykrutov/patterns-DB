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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
          
        }

        private void button1_Click(object sender, EventArgs e)  // Регистрация
        {
            
            Account_nmsp.Account acc = new Account_nmsp.Account();          // создание экземпляра аккаунта
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                 !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                acc.login = textBox1.Text;
                acc.password = textBox2.Text;

                if (acc.registartion())
                {
                    Client cl = new Client();
                    cl.User_login = acc.login;
                    Form2 fm2 = new Form2(cl);
                    fm2.Show();
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все ключевые поля!");
            }

            // Добавление нового пользователя
           
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                 !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Account_nmsp.Account acc = new Account_nmsp.Account();
                Client cl = new Client();
                //accountMapper_nmsp.accountMapper accM = new accountMapper_nmsp.accountMapper();
                acc.login = textBox1.Text;
                acc.password = textBox2.Text;
                cl = acc.openAccount(acc);
                if (acc.openAccount(acc)!=null)
                {
                    this.Hide();
                    Form3 form = new Form3(cl);
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все ключевые поля!");
            }
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
