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
    public partial class SelectIngRecipe : Form
    {
        public SelectIngRecipe()
        {
            InitializeComponent();
        }

        Form1 frm1 = new Form1();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            string s3 = textBox3.Text;
            try
            {
                if (s1 != "" && s2 != "" && s3 != "" && (s1 != s2 || s1 != s3 || s2 != s3))
                {
                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                    frm1.homecommand.CommandType = CommandType.Text;
                    frm1.homecommand.CommandText = "EXEC ViewIngridientRecipes " + "'" + textBox1.Text + "'" + "," + "'" + textBox2.Text + "'" + "," + "'" + textBox3.Text + "'";
                    frm1.homeconnect.Open();
                    string str = frm1.homecommand.ExecuteScalar().ToString();

                    sqlda.SelectCommand = frm1.homecommand;
                    sqlda.Fill(DS);
                    DT = DS.Tables[0];
                    dataGridView1.DataSource = DT;

                    dataGridView1.Columns[0].Width = 645;
                    //dataGridView1.Columns[1].Width = 75;
                    //dataGridView1.Columns[2].Width = 130;
                    dataGridView1.Columns[0].HeaderText = "Рецепты в которых присутсвуют [" + s1 + "],[" + s2 + "],[" + s3 + "]";
                    //dataGridView1.Columns[1].HeaderText = "Дата";
                    //dataGridView1.Columns[2].HeaderText = "Имя пользователя";
                }
                else
                {
                    MessageBox.Show("Нельзя оставлять пустых полей\nЛибо вводить одинаковые название ингридиентов", "ОШИБКА");
                    s1 = "";
                    s2 = "";
                    s3 = "";
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
        }
    }
}
