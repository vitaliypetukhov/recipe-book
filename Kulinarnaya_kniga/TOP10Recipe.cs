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
    public partial class TOP10Recipe : Form
    {
        public TOP10Recipe()
        {
            InitializeComponent();
        }

       // public static SqlConnection sqlcon;

        Form1 frm1 = new Form1();

        private void TOP10Recipe_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            string s1 = dateTimePicker1.Value.Date.ToString().Substring(0,10);//textBox1.Text;
            string s2 = dateTimePicker2.Value.Date.ToString().Substring(0, 10);//textBox2.Text;
            try
            {
                if (s1 != "" && s2 != "")
                {
                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                    frm1.homecommand.CommandType = CommandType.Text;
                    frm1.homecommand.CommandText = "EXEC ViewRecipeActivity " + "'" + s1 /*textBox1.Text */+ "'" + "," + "'" + s2 /*textBox2.Text*/ + "'";
                    frm1.homeconnect.Open();
                    string str = frm1.homecommand.ExecuteScalar().ToString();

                    sqlda.SelectCommand = frm1.homecommand;
                    sqlda.Fill(DS);
                    DT = DS.Tables[0];
                    dataGridView1.DataSource = DT;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
