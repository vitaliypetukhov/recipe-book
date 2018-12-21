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
    public partial class UpdateRecipe : Form
    {
        public string recID;
        public static string lg;
        public int typein_2, typein_3, typein_4;

        AddRecipe adr = new AddRecipe(lg);
        Form1 frm1 = new Form1();


        public UpdateRecipe(string s_1, string s_2, string s_3, string s_4, string s_5, string s_6, string s_7, string s_8)
        {
           
            InitializeComponent();

            textBox1.Text = s_2;
            comboBox1.Text = s_3;
            comboBox2.Text = s_4;
            comboBox3.Text = s_5;
            comboBox4.Text = s_6;
            textBox4.Text = s_7;
            textBox5.Text = s_8;

            
            recID = s_1;
            LoadOpisan();
        }

        public void LoadOpisan()
        {
            try
            {
                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                    frm1.homecommand.CommandType = CommandType.Text;
                    frm1.homecommand.CommandText = "EXEC AboutBludo " + recID;
                    frm1.homeconnect.Open();
                    string str_p = frm1.homecommand.ExecuteScalar().ToString();
                    richTextBox1.Text = RetStr(str_p);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
            }
            finally
            {
                frm1.homeconnect.Close();
            }

        }

        private void UpdateRecipe_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet.Book". При необходимости она может быть перемещена или удалена.
            this.bookTableAdapter.Fill(this.kulinarnaya_knigaDataSet.Book);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.kulinarnaya_knigaDataSet.Category);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet.Cuisine". При необходимости она может быть перемещена или удалена.
            this.cuisineTableAdapter.Fill(this.kulinarnaya_knigaDataSet.Cuisine);
            
        }

        string RetStr(string S)
        {
            string Temp = "    ";
            int Count = 0;
            int i = 0;

            for (i = 0; i < S.Length; ++i)
            {
                Temp += S[i];
                if (S[i] == '.' || S[i] == '!' || S[i] == '?')
                {
                    ++i;
                    ++Count;
                    Temp += "\n   ";
                    continue;
                }
            }
            return Temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox4.Text != "" && textBox5.Text != "" &&
                   richTextBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
                {
                   
                    ComboBox_update();

                    //Check_UID();

                    //int userid = Convert.ToInt32(str_user);
                    frm1.homecommand = frm1.homeconnect.CreateCommand();
                    frm1.homecommand.CommandType = CommandType.Text;
                    frm1.homecommand.CommandText = "EXEC UpdateRecipe " + "'" + textBox4.Text + "', " + "'" + richTextBox1.Text + "'" + ", " + "'" + typein_4 + "'" + ", " + "'" + typein_3 + "'" + ", "
                        + "'" + typein_2 + "'" + "," + "'" + textBox1.Text + "'" + ", " + "'" + textBox5.Text + "'" + "," + "'" + recID + "'";
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
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            typein_2 = 0;
            typein_3 = 0;
            typein_4 = 0;
            this.Hide();
        }

        public void ComboBox_update()
        {
            switch (comboBox1.Text)
            {
                case "Русская кухня       ": typein_2 = 1; break;
                case "Французская кухня   ": typein_2 = 2; break;
                case "Итальянская кухня   ": typein_2 = 3; break;
                case "Испанская кухня     ": typein_2 = 4; break;
                case "Украинская кухня    ": typein_2 = 5; break;
                case "Швейцарская кухня   ": typein_2 = 6; break;
                case "Белорусская кухня   ": typein_2 = 8; break;
                case "Немецкая кухня      ": typein_2 = 9; break;
                case "Американская кухня  ": typein_2 = 10; break;
                case "Японская кухня      ": typein_2 = 11; break;
                case "Китайская кухня     ": typein_2 = 12; break;
            }
            switch (comboBox2.Text)
            {
                case "Напитки             ": typein_3 = 1; break;
                case "Салаты              ": typein_3 = 2; break;
                case "Выпечка             ": typein_3 = 3; break;
                case "Основные блюда      ": typein_3 = 4; break;
                case "Коктели             ": typein_3 = 5; break;
                case "Холодные закуски    ": typein_3 = 6; break;
                case "Гарниры             ": typein_3 = 7; break;
                case "Горячие закуски     ": typein_3 = 8; break;
                case "Десерты             ": typein_3 = 9; break;
                case "Соусы               ": typein_3 = 10; break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0) typein_4 = 1;
            if (comboBox3.SelectedIndex == 1) typein_4 = 2;
            if (comboBox3.SelectedIndex == 2) typein_4 = 3;
            if (comboBox3.SelectedIndex == 3) typein_4 = 4;
            if (comboBox3.SelectedIndex == 4) typein_4 = 5;
            if (comboBox3.SelectedIndex == 5) typein_4 = 6;
            if (comboBox3.SelectedIndex == 6) typein_4 = 7;
            if (comboBox3.SelectedIndex == 7) typein_4 = 8;
            if (comboBox3.SelectedIndex == 8) typein_4 = 9;
            if (comboBox3.SelectedIndex == 9) typein_4 = 10;
            if (comboBox3.SelectedIndex == 10) typein_4 = 11;
            if (comboBox3.SelectedIndex == 11) typein_4 = 12;
            if (comboBox3.SelectedIndex == 12) typein_4 = 13;
            if (comboBox3.SelectedIndex == 13) typein_4 = 14;
            if (comboBox3.SelectedIndex == 14) typein_4 = 15;
            if (comboBox3.SelectedIndex == 15) typein_4 = 16;
            if (comboBox3.SelectedIndex == 16) typein_4 = 17;
            if (comboBox3.SelectedIndex == 17) typein_4 = 18;
            if (comboBox3.SelectedIndex == 18) typein_4 = 19;
            if (comboBox3.SelectedIndex == 19) typein_4 = 20;
            if (comboBox3.SelectedIndex == 20) typein_4 = 21;
            if (comboBox3.SelectedIndex == 21) typein_4 = 22;
            if (comboBox3.SelectedIndex == 22) typein_4 = 23;
            if (comboBox3.SelectedIndex == 23) typein_4 = 24;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //MessageBox.Show("1");
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                typein_4 = 25;
            }
            else
            {
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                //typein_4 = 0;
            }
        }

    }
}
