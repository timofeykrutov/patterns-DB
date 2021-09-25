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
    public partial class Form3 : Form
    {
        Client cl = new Client();
        public Form3(Client o)
        {
            InitializeComponent();
            cl.Name = o.Name;
            cl.PhoneNumber = o.PhoneNumber;
            cl.Surname = o.Surname;
            cl.User_login = o.User_login;
            cl.UserID = o.UserID;
            cl.email = o.email;

            label2.Text = cl.Name.ToString() + " " + cl.Surname.ToString();

            textBox1.Text = cl.Name;
            textBox2.Text = cl.Surname;
            textBox3.Text = cl.PhoneNumber;
            textBox4.Text = cl.email;
            textBox5.Text = cl.User_login;
            textBox1.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false; textBox4.Enabled = false; textBox5.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true; textBox2.Enabled = true; textBox3.Enabled = true; textBox4.Enabled = true; 
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cl.Name = textBox1.Text; cl.Surname = textBox2.Text;
            cl.PhoneNumber = textBox3.Text; cl.email = textBox4.Text;
            if (cl.updateInformation())
            {
                textBox1.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false; textBox4.Enabled = false; 
                button4.Visible = false;
                label2.Text = cl.Name.ToString() + " " + cl.Surname.ToString();
                MessageBox.Show("Успешно!");
            }
            else
            {
                MessageBox.Show("Неудачно! Повторите попытку!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm4 = new Form4(cl);
            fm4.Show();
            
        }
    }
}
