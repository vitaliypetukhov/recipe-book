using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace Kulinarnaya_kniga
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        Form1 frm1 = new Form1();

        public static SqlConnection sqlcon;
        public string str_pass; 
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection();
            try
            {
                string str_1 = textBox1.Text;
                string str_2 = textBox2.Text;
                string str_3 = textBox3.Text;
                string str_pass = textBox4.Text;
                if (str_1.Length > 50)
                {
                    MessageBox.Show("Превышен лимит ввода символов в поле 'Имя пользователя'!");
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                    textBox4.Text = ""; textBox5.Text = "";
                }
                if (str_2.Length > 50)
                {
                    MessageBox.Show("Превышен лимит ввода символов в поле 'Фамилия пользователя'!");
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                    textBox4.Text = ""; textBox5.Text = "";
                }
                if (str_3.Length > 20)
                {
                    MessageBox.Show("Превышен лимит ввода символов в поле 'Логин пользователя'!");
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                    textBox4.Text = ""; textBox5.Text = "";
                }
                if (str_pass.Length > 20)
                {
                    MessageBox.Show("Превышен лимит ввода символов в поле 'Пароль пользователя'!");
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                    textBox4.Text = ""; textBox5.Text = "";
                }
                if (textBox4.Text != textBox5.Text)
                {
                    MessageBox.Show("Введенные пароли не совпадают");
                    textBox1.Text = ""; textBox2.Text = "";
                    textBox3.Text = ""; textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    //string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                    //sqlcon.ConnectionString = ConnectionString;
                    //SqlCommand sqlcmd = sqlcon.CreateCommand();

                    MD5 md5 = new MD5CryptoServiceProvider();
                    string pass = textBox4.Text;//Console.ReadLine();
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

                    

                    //Console.WriteLine("MD5: {0}", result);

                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                    frm1.homecommand.CommandType = CommandType.Text;
                    frm1.homecommand.CommandText = "EXEC Registration " + "'" + textBox1.Text + "'" + "," + "'" + textBox2.Text + "'" + ","
                        + "'" + textBox3.Text +"'" + "," + "'" + result/*textBox4.Text*/ + "'";


                    frm1.homeconnect.Open();

                    frm1.homedatareader = frm1.homecommand.ExecuteReader();

                }
                MessageBox.Show("Вы успешно зарегистрировали\n-> Логин [" + textBox3.Text + "], Пароль [" + textBox4.Text + "]");
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
            this.Hide();


            //Autorization autor = new Autorization();
            //autor.ShowDialog();

        }
    }
}
