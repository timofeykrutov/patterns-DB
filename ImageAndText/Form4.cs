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
    public partial class Form4 : Form
    {
        Text txt = new Text();
        Order ord = new Order();
        public Form4(Client o)
        {
           

            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.jpg)|*.jpg|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.jpg)|*.jpg|All files(*.*)|*.*";
            Order ord = new Order();
            ord.User_ID = o.UserID;
            ord.UserName = textBox1.Text;
            ord.UserSurname = textBox2.Text;
            ord.UserPhone = textBox3.Text;
            if (ord.openOrder())
            {
                
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {


                ord.UserName = textBox1.Text;
                ord.UserSurname = textBox2.Text;
                ord.UserPhone = textBox3.Text;
                ord.Date = DateTime.Now;


                if (ord.createOrder())
                {
                    txt.TextOwner = ord.UserSurname;
                    //txt.User_ID = ord.User_ID;
                    txt.addText();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            //string filename  ; 
            txt.TextName = openFileDialog1.FileName;
            txt.Textt = txt.ImgToStr(openFileDialog1.FileName);      // преобразуем открытый файл 
            txt.SizeOfText = txt.Textt.Length;
            //txt.addText();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;      //  имя файла
            if (txt.read() != null)
            {
                txt.StrToImg(txt.Textt).Save(saveFileDialog1.FileName);
            }
            // txt.StrToImg(image).Save(saveFileDialog1.FileName);  // сохраняем файлик 
            MessageBox.Show("Файл сохранен");
           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form ordForm = Application.OpenForms[1];
            ordForm.Show();
        }
    }
}
