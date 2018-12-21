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

namespace Kulinarnaya_kniga
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        Form1 frm1 = new Form1();
          public string s_1, s_2, s_3, s_4, s_5, s_6, s_7, s_8; 

        public void ReloadUsers()
        {
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            try
            {

                frm1.homecommand = frm1.homeconnect.CreateCommand();
                frm1.homecommand.CommandType = CommandType.Text;
                frm1.homecommand.CommandText = "EXEC ViewUsers ";
                frm1.homeconnect.Open();
                string str = frm1.homecommand.ExecuteScalar().ToString();

                sqlda.SelectCommand = frm1.homecommand;
                sqlda.Fill(DS);
                DT = DS.Tables[0];
                dataGridView1.DataSource = DT;
                
                dataGridView1.Columns[0].Visible = false;
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

        private void Users_Load(object sender, EventArgs e)
        {
            ReloadUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AddRecipe adr = new AddRecipe(login);
            //adr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            int selectrow_1 = 0;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {

                DataGridViewRow row = dataGridView1.SelectedRows[i];
                SqlDataAdapter sqlda = new SqlDataAdapter();
                //if (row.Index == dataGridView1.RowCount - 1)
                //{
                //    MessageBox.Show("Невозможно выбрать пустую строку,\nдля подробного рассмотрения!", "Ошибка выборки данных");
                //}
                //else
                //{
                    if (row == dataGridView1.SelectedRows[i])
                    {
                        selectrow_1++;
                        if (selectrow_1 > 1) MessageBox.Show("Выбрано более одной строки для подробного рассмотрения рецепта!");
                        else
                        {
                            try
                            {

                                string s1 = row.Cells[0].Value.ToString();

                                if (s1 != "1")
                                {
                                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                                    frm1.homecommand.CommandType = CommandType.Text;
                                    frm1.homecommand.CommandText = "EXEC DeleteUsers " + s1;
                                    frm1.homeconnect.Open();
                                    string str = frm1.homecommand.ExecuteScalar().ToString();

                                    sqlda.SelectCommand = frm1.homecommand;
                                    sqlda.Fill(DS);
                                    DT = DS.Tables[0];
                                    dataGridView1.DataSource = DT;
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно удалить администратора");
                                }

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
                            ReloadUsers();
                        }

                    //}

                }
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddUser adu = new AddUser();
            adu.ShowDialog();
            ReloadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectrow_1 = 0;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {

                DataGridViewRow row = dataGridView1.SelectedRows[i];
                SqlDataAdapter sqlda = new SqlDataAdapter();
                if (row.Index == dataGridView1.RowCount - 1)
                {
                    MessageBox.Show("Невозможно выбрать пустую строку,\nдля подробного рассмотрения!", "Ошибка выборки данных");
                }
                else
                {
                    if (row == dataGridView1.SelectedRows[i])
                    {
                        selectrow_1++;
                        if (selectrow_1 > 1) MessageBox.Show("Выбрано более одной строки для подробного рассмотрения рецепта!");
                        else
                        {
                            //if (label11.Text != "admin")
                            //{
                            //    MessageBox.Show("Для редактирования рецепта, вам необходимо зайти как администратор", "Ошибка");
                            //    ReloadMainPage();
                            //}
                            //else
                            //{
                            string s1 = row.Cells[0].Value.ToString();

                            if (s1 != "1")
                            {
                                s_1 = row.Cells[0].Value.ToString();
                                s_2 = row.Cells[1].Value.ToString();
                                s_3 = row.Cells[2].Value.ToString();
                                s_4 = row.Cells[3].Value.ToString();
                                s_5 = row.Cells[4].Value.ToString();
                                //s_6 = row.Cells[5].Value.ToString();
                                //s_7 = row.Cells[6].Value.ToString();
                                //s_8 = row.Cells[7].Value.ToString();


                                UpdateUsers updu = new UpdateUsers(s_1, s_2, s_3, s_4, s_5);
                                updu.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Невозможно редактировать администратора");
                            }

                            //    ReloadMainPage();
                                ReloadUsers();
                            }
                        }

                  }
               }
        }
    }
}
