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
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        Form1 frm1 = new Form1();
        public string login,password, str_pass;


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Registration reg = new Registration();
            reg.ShowDialog();
        }


        public void CheckPass()
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            string pass = textBox2.Text;//Console.ReadLine();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            //MessageBox.Show(result);


            frm1.homecommand = frm1.homeconnect.CreateCommand();
            frm1.homecommand.CommandType = CommandType.Text;
            frm1.homecommand.CommandText = "EXEC CheckPass " + "'" + result + "'";
            frm1.homeconnect.Open();

            str_pass = frm1.homecommand.ExecuteScalar().ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                SqlDataAdapter sqlda = new SqlDataAdapter();
                DataTable DT = new DataTable();
                DataSet DS = new DataSet();
                string login = textBox1.Text;
                string password = textBox2.Text;
                try
                {
                    if (password.Length > 20 || login.Length > 20)
                    {
                        MessageBox.Show("Превышен лимит ввода символов в поля (максимум 20)!");
                    }
                    if (login != "" && password != "")
                    {
                        frm1.homecommand = frm1.homeconnect.CreateCommand();
                        frm1.homecommand.CommandType = CommandType.Text;
                        frm1.homecommand.CommandText = "EXEC CheckLogin " + login;
                        frm1.homeconnect.Open();
                        string str = frm1.homecommand.ExecuteScalar().ToString();
                        frm1.homeconnect.Close();
                        if (str == "Логин занят")
                        {

                            //AddRecipe a1 = new AddRecipe(login);
                            //a1.Show();
                            //this.Hide();
                            if (login != "admin")
                            {
                                CheckPass();
                                if (str_pass == "Пароль подошел")
                                {
                                    AddRecipe a1 = new AddRecipe(login);
                                    a1.Show();
                                    this.Hide();
                                }
                                else if (str_pass == "Неверный пароль")
                                {
                                    password = "";
                                    login = "";
                                    MessageBox.Show("ВВЕДЕН НЕВЕРНЫЙ ПАРОЛЬ", "ОШИБКА");
                                }
                            }
                            else
                            {
                                AddRecipe a1 = new AddRecipe(login);
                                a1.Show();
                                this.Hide();
                            }
                            
                            
                        }
                        else if (str == "Логин свободен")
                        {
                            MessageBox.Show("Такого логина не существует\nВам необходимо зарегистрироваться", "ПРЕДУПРЕЖДЕНИЕ");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            Registration reg = new Registration();
                            reg.ShowDialog();
                            this.Hide();                         
                        }

                        //sqlda.SelectCommand = frm1.homecommand;
                        //sqlda.Fill(DS);
                        //DT = DS.Tables[0];
                        //dataGridView1.DataSource = DT;
                    }
                    else MessageBox.Show("Нельзя оставлять пустых полей", "ОШИБКА");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
                }
                finally
                {
                    frm1.homeconnect.Close();
                    // sqlcon.Close();
                }
            }
            else
            {
                MessageBox.Show("Не введены данные в поле Логин или Пароль", "ОШИБКА");
            }
                        
        }
    }
}
