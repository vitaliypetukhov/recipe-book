using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Kulinarnaya_kniga
{
    
    public partial class UpdateUsers : Form
    {
        public string uIDD;
        Form1 frm1 = new Form1();

        public UpdateUsers(string s_1, string s_2, string s_3, string s_4, string s_5)
        {
            InitializeComponent();

            textBox1.Text = s_2;
            textBox2.Text = s_3;
            textBox3.Text = s_4;
            //textBox4.Text = s_5;
            //textBox5.Text = s_5;
            uIDD = s_1;
            
        }

        private void UpdateUsers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {

                    MD5 md5 = new MD5CryptoServiceProvider();
                    string pass = textBox4.Text;//Console.ReadLine();
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);


                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                    frm1.homecommand.CommandType = CommandType.Text;
                    frm1.homecommand.CommandText = "EXEC UpdateUser " + "'" + textBox1.Text + "', " + "'" + textBox2.Text + "'" + ", " + "'" + textBox3.Text + "'" + ", " + "'" + /*textBox4.Text*/result + "'" + 
                         "," + "'" + uIDD + "'";
                    frm1.homeconnect.Open();
                    frm1.homedatareader = frm1.homecommand.ExecuteReader();
                }
                else MessageBox.Show("Заполните все поля.", "Ошибка");

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
            }


            finally
            {
                //sqlcon.Close();
                frm1.homeconnect.Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            //textbox4.Text = "";
            //textbox5.Text = "";
            //typein_2 = 0;
            //typein_3 = 0;
            //typein_4 = 0;
            this.Hide();
        }
    }
}
