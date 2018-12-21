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
    public partial class Form1 : Form
    {

        //public SqlConnection sqlconhome;

        public SqlConnection homeconnect = new SqlConnection("Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;");
        public SqlCommand homecommand ;
        public SqlDataReader homedatareader;
        //public string ConnectionString;

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet.User". При необходимости она может быть перемещена или удалена.
            //this.userTableAdapter.Fill(this.kulinarnaya_knigaDataSet.User);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet.Recipe". При необходимости она может быть перемещена или удалена.
           // this.recipeTableAdapter.Fill(this.kulinarnaya_knigaDataSet.Recipe);

        }

        private void open_kn_button_Click(object sender, EventArgs e)
        {
            open_kn_button.Visible = false;

            //sqlconhome = new SqlConnection();
            try
            {
                //string ConnectionString = "Data Source=" + HostNameTextBox.Text +
                // ";Initial Catalog=Auction;Connect Timeout=20;User ID=" + UserNameTextBox.Text +
                // ";Password=" + PasswordTextBox.Text + ";";
                //string s1 = textBox1.Text;
                //string s2 = textBox2.Text;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Т.К. не был введен Data Source,\nон был выставлен по умолчанию на (local)", "ПРЕДУПРЕЖДЕНИЕ");
                    textBox1.Text = "(local)";
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Т.К. не был введен Initial Catalog,\nон был выставлен по умолчанию на Kulinarnaya_kniga", "ПРЕДУПРЕЖДЕНИЕ");
                    textBox2.Text = "Kulinarnaya_kniga";
                }

               // string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                string ConnectionString = "Data Source=" + textBox1.Text + ";Initial Catalog=" + textBox2.Text + ";Integrated Security=True;";
                homeconnect.ConnectionString = ConnectionString;

                homeconnect.Open();

                // MessageBox.Show("GOOD CONNECT!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
            }
            finally
            {
                homeconnect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
            }

            this.Hide();

            //AddRecipe addr = new AddRecipe();
            //addr.ShowDialog();


            Autorization autor = new Autorization();
            autor.ShowDialog();
            
        }
    }
}
