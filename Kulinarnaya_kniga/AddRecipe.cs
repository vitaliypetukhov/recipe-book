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
//using System.String;


namespace Kulinarnaya_kniga
{
    public partial class AddRecipe : Form
    {

        Autorization aut = new Autorization();

        public AddRecipe(string login)
        {
            InitializeComponent();

            
            //button1.Visible = true;
            label1.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label13.Visible = false;
            label10.Visible = false;
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;

            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;

            label11.Text = login;

            Check_Admin();

            ReloadMainPage();
        }

        public static SqlConnection sqlcon;
        public SqlDataReader dataReader;
        public int typein, typein_1, typein_2, typein_3,typein_4;
        public string s1, str_user, str_admin;
        public string s_1, s_2, s_3, s_4, s_5, s_6, s_7, s_8; 
        Form1 frm1 = new Form1();



        public void Check_Admin()
        {
            //frm1.homecommand = frm1.homeconnect.CreateCommand();
            //frm1.homecommand.CommandType = CommandType.Text;
            //frm1.homecommand.CommandText = "EXEC Check_Admin_par ";
            //frm1.homeconnect.Open();
            //str_admin = frm1.homecommand.ExecuteScalar().ToString();

            //frm1.homeconnect.Close();

            if (label11.Text != "admin")
            {
                button9.Visible = false;
                button10.Visible = false;
                button12.Visible = false;
            }
            else if (label11.Text == "admin")
            {
                button9.Visible = true;
                button10.Visible = true;
                button12.Visible = true;
            } 
        }

        public void Check_UID()
        {
            frm1.homecommand = frm1.homeconnect.CreateCommand();
            frm1.homecommand.CommandType = CommandType.Text;
            frm1.homecommand.CommandText = "EXEC GiveUserID " + label11.Text;
            frm1.homeconnect.Open();
            str_user = frm1.homecommand.ExecuteScalar().ToString();

            frm1.homeconnect.Close();
            // str_user = frm1.homecommand.ExecuteReader();
            //frm1.homedatareader = frm1.homecommand.ExecuteReader();
        }

        public void NewOtzivAdd()
        {
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            try
            {
                string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                sqlcon.ConnectionString = ConnectionString;

                SqlCommand sqlcmd = sqlcon.CreateCommand();

                //string s1 = row.Cells[0].Value.ToString();

                sqlcon.Open();

                Check_UID();

                int userid = Convert.ToInt32(str_user);

                DateTime curDate = DateTime.Now;
                string ThData = curDate.ToString("dd/mm/yyyy");
                sqlcmd.CommandText = "EXEC NewOtzivAd " + "'" + richTextBox2.Text + "'" + ", " + "'" + ThData + "', " + s1 + "," + userid + ", " + s1;


                //string str4 = sqlcmd.ExecuteScalar().ToString();
                //MessageBox.Show(str3);
                // индекс выделенного элемента row.Index.ToString()
                dataGridView2.Visible = true;
                label13.Visible = false;

                sqlda.SelectCommand = sqlcmd;
                sqlda.Fill(DS);
                DT = DS.Tables[0];
                dataGridView2.DataSource = DT;

                richTextBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
             
        }
        
        public void GridOptions()
        {
            dataGridView1.Columns[0].HeaderText = "ИД";
            dataGridView1.Columns[1].HeaderText = "Название рецепта";
            dataGridView1.Columns[2].HeaderText = "Название кухни";
            dataGridView1.Columns[3].HeaderText = "Категория блюда";
            dataGridView1.Columns[4].HeaderText = "Название книги";
            dataGridView1.Columns[5].HeaderText = "Автор книги";
            dataGridView1.Columns[6].HeaderText = "Калории (ккал.)";
            dataGridView1.Columns[7].HeaderText = "Мера (гр.)";
            dataGridView1.Columns[8].HeaderText = "Логин";
            dataGridView1.Columns[0].Width = 45;
            dataGridView1.Columns[1].Width = 165;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[5].Width = 125;
            dataGridView1.Columns[4].Width = 115;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[7].Width = 85;
        }

        public void AddRecipeForm()
        {
            
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label1.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label13.Visible = false;
            label10.Visible = false;
            richTextBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            comboBox2.Visible = false;
            label6.Visible = false;
            richTextBox2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button2.Visible = false;
            button9.Visible = false;
            button11.Visible = false;
            button10.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button12.Visible = false;
        }

        public void ReloadMainPage()
        {
            sqlcon = new SqlConnection();
            SqlCommand sqlcmd = sqlcon.CreateCommand();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
            sqlcon.ConnectionString = ConnectionString;

            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "EXEC ViewMainPage";

            sqlcon.Open();
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Visible = false;

            

            GridOptions();

            sqlcon.Close();

           // MessageBox.Show(aut.login);
            //label11.Text = aut.login;
        }

        public void ReloadFilter()
        {
            sqlcon = new SqlConnection();
            SqlCommand sqlcmd = sqlcon.CreateCommand();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
            sqlcon.ConnectionString = ConnectionString;

            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "EXEC Filter_2 " + typein;

            sqlcon.Open();
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Visible = false;

            sqlcon.Close();
        }

        public void ReloadFilter_1()
        {
            sqlcon = new SqlConnection();
            SqlCommand sqlcmd = sqlcon.CreateCommand();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
            sqlcon.ConnectionString = ConnectionString;

            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "EXEC FILTER_1 " + typein_1;

            sqlcon.Open();
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Visible = false;

            sqlcon.Close();
        }

        public void ReloadCalorFilter_3()
        {
            sqlcon = new SqlConnection();
            SqlCommand sqlcmd = sqlcon.CreateCommand();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
            sqlcon.ConnectionString = ConnectionString;

            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "EXEC CalorFilter_3 "+ textBox1.Text + ", " + textBox6.Text;

            sqlcon.Open();
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Visible = false;

            sqlcon.Close();
        }

        public void ReloadCalorFilter_2()
        {
            sqlcon = new SqlConnection();
            SqlCommand sqlcmd = sqlcon.CreateCommand();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
            sqlcon.ConnectionString = ConnectionString;

            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "EXEC CalorFilter_2 " + textBox6.Text;

            sqlcon.Open();
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Visible = false;

            sqlcon.Close();
        }

        public void ReloadCalorFilter_1()
        {
            sqlcon = new SqlConnection();
            SqlCommand sqlcmd = sqlcon.CreateCommand();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
            sqlcon.ConnectionString = ConnectionString;

            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "EXEC CalorFilter_1 " + textBox1.Text;

            sqlcon.Open();
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Visible = false;

            sqlcon.Close();
        }

        
        private void AddRecipe_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet1.Book". При необходимости она может быть перемещена или удалена.
            this.bookTableAdapter.Fill(this.kulinarnaya_knigaDataSet1.Book);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet1.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter1.Fill(this.kulinarnaya_knigaDataSet1.Category);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kulinarnaya_knigaDataSet1.Cuisine". При необходимости она может быть перемещена или удалена.
            this.cuisineTableAdapter1.Fill(this.kulinarnaya_knigaDataSet1.Cuisine);

            ReloadMainPage();         
        }

      
        // Фильтр по кухне
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Русская кухня       ": typein = 1; ReloadFilter(); break;
                case "Французская кухня   ": typein = 2; ReloadFilter(); break;
                case "Итальянская кухня   ": typein = 3; ReloadFilter(); break;
                case "Испанская кухня     ": typein = 4; ReloadFilter(); break;
                case "Украинская кухня    ": typein = 5; ReloadFilter(); break;
                case "Швейцарская кухня   ": typein = 6; ReloadFilter(); break;
                case "Белорусская кухня   ": typein = 8; ReloadFilter(); break;
                case "Немецкая кухня      ": typein = 9; ReloadFilter(); break;
                case "Американская кухня  ": typein = 10; ReloadFilter(); break;
                case "Японская кухня      ": typein = 11; ReloadFilter(); break;
                case "Китайская кухня     ": typein = 12; ReloadFilter(); break;
            }
           
        }

        // Фильтр по категории
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Напитки             ": typein_1 = 1; ReloadFilter_1(); break;
                case "Салаты              ": typein_1 = 2; ReloadFilter_1(); break;
                case "Выпечка             ": typein_1 = 3; ReloadFilter_1(); break;
                case "Основные блюда      ": typein_1 = 4; ReloadFilter_1(); break;
                case "Коктели             ": typein_1 = 5; ReloadFilter_1(); break;
                case "Холодные закуски    ": typein_1 = 6; ReloadFilter_1(); break;
                case "Гарниры             ": typein_1 = 7; ReloadFilter_1(); break;
                case "Горячие закуски     ": typein_1 = 8; ReloadFilter_1(); break;
                case "Десерты             ": typein_1 = 9; ReloadFilter_1(); break;
                case "Соусы               ": typein_1 = 10; ReloadFilter_1(); break;
            }

        }

        public void OptionsAbout()
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label1.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            richTextBox1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            comboBox2.Visible = false;
            label6.Visible = false;
            richTextBox2.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = false;
            button6.Visible = true;
            button2.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button12.Visible = false;
            button14.Visible = false;
        }

        public void OptionsAbout_1()
        {
            

            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            textBox6.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label1.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label13.Visible = false;
            label10.Visible = false;
            richTextBox1.Visible = false ;
            button1.Visible = true;
            button2.Visible = true;
            comboBox2.Visible = true;
            label6.Visible = true;
            richTextBox2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = true;
            button6.Visible = false;
            button2.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button12.Visible = true;
            button14.Visible = true;
            button11.Visible = true;

            Check_Admin();
        }
        
        // Все о рецепте
        private void button3_Click(object sender, EventArgs e)
        {
            int selectrow_1 = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {

                DataGridViewRow row = dataGridView1.SelectedRows[i];
                SqlDataAdapter sqlda = new SqlDataAdapter();
                DataTable DT = new DataTable();
                DataSet DS = new DataSet();
                DataTable DT1 = new DataTable();
                DataSet DS1 = new DataSet();

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
                        //else if (selectrow_1 == 0) MessageBox.Show("Не выбрана строка для подробного рассмотрения рецепта!");
                        else
                        {

                            OptionsAbout();
                            // НАЗВАНИЕ
                            label1.Text = row.Cells[1].Value.ToString();

                            // СПОСОБ ПРИГОТОВЛЕНИЯ
                            try
                            {
                                string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                                sqlcon.ConnectionString = ConnectionString;

                                SqlCommand sqlcmd = sqlcon.CreateCommand();

                                s1 = row.Cells[0].Value.ToString();
                                sqlcmd.CommandText = "EXEC AboutBludo " + s1;

                                sqlcon.Open();
                                string str = sqlcmd.ExecuteScalar().ToString();

                                //str = RetStr(str);
                                richTextBox1.Text = RetStr(str);
                                richTextBox1.ReadOnly = true;
                                // индекс выделенного элемента row.Index.ToString()

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
                            }
                            finally
                            {
                                sqlcon.Close();
                            }

                            // ОТЗЫВЫ
                            try
                            {
                                string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                                sqlcon.ConnectionString = ConnectionString;

                                SqlCommand sqlcmd = sqlcon.CreateCommand();

                                s1 = row.Cells[0].Value.ToString();
                                sqlcmd.CommandText = "EXEC Otzivi " + s1;

                                sqlcon.Open();

                                //if (str_1 = "")
                                string str1 = sqlcmd.ExecuteScalar().ToString();
                                //ExecuteScalar().ToString();

                                // индекс выделенного элемента row.Index.ToString()

                                //listBox1.Items.Add(str);
                                sqlda.SelectCommand = sqlcmd;
                                sqlda.Fill(DS);
                                DT = DS.Tables[0];
                                dataGridView2.DataSource = DT;

                                dataGridView2.Columns[0].Width = 400;
                                dataGridView2.Columns[1].Width = 75;
                                dataGridView2.Columns[2].Width = 130;
                                dataGridView2.Columns[0].HeaderText = "Отзыв о рецепте";
                                dataGridView2.Columns[1].HeaderText = "Дата";
                                dataGridView2.Columns[2].HeaderText = "Имя пользователя";

                            }
                            catch 
                            {
                                //MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message); Exception ex
                                dataGridView2.Visible = false;
                                label13.Visible = true;
                            }
                            finally
                            {
                                sqlcon.Close();
                            }

                            //СОСТАВ
                            try
                            {
                                string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                                sqlcon.ConnectionString = ConnectionString;

                                SqlCommand sqlcmd = sqlcon.CreateCommand();

                                s1 = row.Cells[0].Value.ToString();
                                sqlcmd.CommandText = "EXEC ViewIngridient " + s1;

                                sqlcon.Open();

                                string strz = sqlcmd.ExecuteScalar().ToString();

                                sqlda.SelectCommand = sqlcmd;
                                sqlda.Fill(DS1);
                                DT1 = DS1.Tables[0];
                                dataGridView3.DataSource = DT1;

                                dataGridView3.Columns[0].Width = 275;
                                dataGridView3.Columns[1].Width = 70;
                                dataGridView3.Columns[2].Width = 95;
                                dataGridView3.Columns[0].HeaderText = "Ингридиенты";
                                dataGridView3.Columns[1].HeaderText = "Кол-во";
                                dataGridView3.Columns[2].HeaderText = "Единица Измерения";

                                dataGridView3.Columns[1].Visible = false;
                                dataGridView3.Columns[2].Visible = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
                            }
                            finally
                            {
                                sqlcon.Close();
                            }

                            selectrow_1 = 0;

                        }

                    }
                }
                
                
                    //MessageBox.Show(row.Index.ToString());
            }
           

        }

        // процедура для вывода способа приготовления
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" && textBox1.Text != "")
            {

                ReloadCalorFilter_1();
                // MessageBox.Show("Ошибка вывода калорийности, не введено 2 параметра");
                //textBox1.Text = "";
                //textBox6.Text = "";
            }
            else if (textBox6.Text != "" && textBox1.Text == "")
            {

                ReloadCalorFilter_2();
                //MessageBox.Show("ok");
            }
            else if (textBox6.Text != "" && textBox1.Text != "")
            {

                ReloadCalorFilter_3();
            }
            else if (textBox6.Text == "" && textBox1.Text == "") MessageBox.Show("Необходимо ввести данные в поля калорийности для нахождения блюда!");
        }

        // ОБНОВЛЕНИЕ ТАБЛИЦЫ РЕЦЕПТОВ
        private void button2_Click(object sender, EventArgs e)
        {
            ReloadMainPage();
        }

        // ОСТАВЛЯЕМ НОВЫЙ ОТЗЫВ
        private void button4_Click(object sender, EventArgs e)
        {
            NewOtzivAdd();
        }

        // ДОБАВЛЕНИЕ НОВОГО РЕЦЕПТА
        private void button5_Click(object sender, EventArgs e)
        {
            AddNewRecipe adr = new AddNewRecipe(label11.Text);
            adr.ShowDialog();
            ReloadMainPage();
        }

        //Назад к рецептам
        private void button6_Click(object sender, EventArgs e)
        {
            OptionsAbout_1();
        }

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    OptionsAbout_1();
        //}

        private void button13_Click(object sender, EventArgs e)
        {
            //New_Book nb = new New_Book();
            //nb.ShowDialog();
        }
       
        private void button9_Click(object sender, EventArgs e)
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
                            //Check_Admin();
                            if (label11.Text != "admin")
                            {
                                MessageBox.Show("Для удаления рецепта вам необходимо зайти как администратор", "Ошибка");
                                ReloadMainPage();
                            }
                            else
                            {
                                try
                                {
                                    string ConnectionString = "Data Source=\"(local)\";Initial Catalog=\"Kulinarnaya_kniga\";Integrated Security=True;";
                                    sqlcon.ConnectionString = ConnectionString;

                                    SqlCommand sqlcmd = sqlcon.CreateCommand();

                                    s1 = row.Cells[0].Value.ToString();
                                    sqlcmd.CommandText = "EXEC DeleteRecipe " + s1;

                                    sqlcon.Open();
                                    string str = sqlcmd.ExecuteScalar().ToString();
                                    sqlcon.Close();
                                    //str = RetStr(str);
                                    //richTextBox1.Text = RetStr(str);
                                    // индекс выделенного элемента row.Index.ToString()

                                }
                                catch 
                                {
                                   // SqlCommand sqlcmd = sqlcon.CreateCommand();

                                    //s1 = row.Cells[0].Value.ToString();
                                    //sqlcmd.CommandText = "EXEC DeleteRecipe " + s1;

                                    //sqlcon.Open();
                                    //string str = sqlcmd.ExecuteScalar().ToString();
                                    //sqlcon.Close();
                                    //MessageBox.Show("Ошибка соединения! Т.к. ->  " + ex.Message);
                                }
                                //finally
                                //{
                                //    sqlcon.Close();
                                //}
                                ReloadMainPage();
                            }

                           

                            
                        }


                    }
                }
            } 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TOP10Recipe top10r = new TOP10Recipe();
            top10r.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TOP10Users top10u = new TOP10Users();
            top10u.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SelectIngRecipe selingrec = new SelectIngRecipe();
            selingrec.ShowDialog();
        }




        private void button10_Click(object sender, EventArgs e)
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
                            if (label11.Text != "admin")
                            {
                                MessageBox.Show("Для редактирования рецепта, вам необходимо зайти как администратор", "Ошибка");
                                ReloadMainPage();
                            }
                            else
                            {
                                s_1 = row.Cells[0].Value.ToString();
                                s_2 = row.Cells[1].Value.ToString();
                                s_3 = row.Cells[2].Value.ToString();
                                s_4 = row.Cells[3].Value.ToString();
                                s_5 = row.Cells[4].Value.ToString();
                                s_6 = row.Cells[5].Value.ToString();
                                s_7 = row.Cells[6].Value.ToString();
                                s_8 = row.Cells[7].Value.ToString();


                                UpdateRecipe updr = new UpdateRecipe(s_1, s_2, s_3, s_4, s_5, s_6, s_7, s_8);
                                updr.ShowDialog();

                                ReloadMainPage();
                            }
                        }

                  }
               }
            } 

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization autor = new Autorization();
            autor.ShowDialog();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Users usr = new Users();
            usr.ShowDialog();

        }

       
                              
    }
}
