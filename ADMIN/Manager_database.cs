using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace OOP2_PROJECT_2._0
{
   

    public partial class Manager_database : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
        public Manager_database()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_Info a = new Admin_Info();
            a.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox6.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "Select Gender")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into manager_info (id,pass,name,phone,address,age,DOB,gender) values(@id,@pass,@name,@phone,@address,@age,@DOB,@gender)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox6.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("phone", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                cmd.Parameters.AddWithValue("age", textBox5.Text);
                cmd.Parameters.AddWithValue("DOB", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("gender", comboBox1.Text);
               
                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Manager Added");
                    textBox1.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text="Select Gender";

                    SqlConnection con3 = new SqlConnection(cs);
                    string query3 = "select* from manager_info";
                    SqlDataAdapter sda = new SqlDataAdapter(query3, con3);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Manager Adding Error");
                }
            }
            else
            {
                MessageBox.Show("Fill ALL the information first!");
            }

        }

        private void Manager_database_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            SqlConnection con = new SqlConnection(cs);
            string query = "select* from manager_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != ""  )

            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from manager_info where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    string  pass = dt.Rows[0]["pass"].ToString();
                    string name = dt.Rows[0]["name"].ToString();
                    string phone = dt.Rows[0]["phone"].ToString();
                    string address = dt.Rows[0]["address"].ToString();
                    int age = Convert.ToInt32(dt.Rows[0]["age"].ToString());
                    string DOB = dt.Rows[0]["DOB"].ToString();
                    string gender = dt.Rows[0]["gender"].ToString();

                    textBox1.Text = id.ToString();
                    textBox6.Text = pass;
                    textBox2.Text = name;
                    textBox3.Text = phone;
                    textBox4.Text = address;
                    textBox5.Text = age.ToString();
                    dateTimePicker1.Text = DOB;
                    comboBox1.Text = gender;
                }
                else
                {
                    MessageBox.Show("ID not found");
                }
            }
            else
            {
                MessageBox.Show("INPUT ID FIRST");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" )
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "DELETE FROM manager_info WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
               
                cmd.Parameters.AddWithValue("id", textBox1.Text);
              

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("DELETED ID");
                    textBox1.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = "Select Gender";
                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "select* from manager_info";
                    SqlDataAdapter sda = new SqlDataAdapter(query2, con2);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("INCORRECT ID");
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox6.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "Select Gender" )
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update manager_info set pass = @pass , name = @name , phone = @phone,address = @address,age = @age ,DOB = @DOB, gender = @gender  where id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox6.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("phone", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                cmd.Parameters.AddWithValue("age", textBox5.Text);
                cmd.Parameters.AddWithValue("DOB", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("gender", comboBox1.Text);
          

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Manager Updated");
                    textBox1.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = "Select Gender";
                    
                    SqlConnection con1 = new SqlConnection(cs);
                    string query1 = "select* from manager_info";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con1);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("Manager Update Error");
                }
            }
            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }


        }
    }
}
