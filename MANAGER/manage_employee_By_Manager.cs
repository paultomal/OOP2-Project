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
    public partial class manage_employee_By_Manager : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
        public manage_employee_By_Manager()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manager_Info a = new Manager_Info();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox6.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "Select Gender" && textBox8.Text != "" && comboBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into employee_info (id,pass,name,phone,address,age,DOB,gender,salary, job_post ) values(@id,@pass,@name,@phone,@address,@age,@DOB,@gender,@salary, @job_post)";
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
                cmd.Parameters.AddWithValue("salary", textBox8.Text);
                cmd.Parameters.AddWithValue("job_post", comboBox2.Text);

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Employee Added");
                    textBox1.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = "Select Gender";
                    textBox8.Clear();
                    comboBox2.Text = "Select Post";
                    SqlConnection con1 = new SqlConnection(cs);
                    string query1 = "select* from employee_info";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con1);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("Employee Adding Error");
                }
            }
            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }


        }

        private void manage_employee_By_Manager_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select* from employee_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")

            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from employee_info where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    string pass = dt.Rows[0]["pass"].ToString();
                    string name = dt.Rows[0]["name"].ToString();
                    string phone = dt.Rows[0]["phone"].ToString();
                    string address = dt.Rows[0]["address"].ToString();
                    int age = Convert.ToInt32(dt.Rows[0]["age"].ToString());
                    string DOB = dt.Rows[0]["DOB"].ToString();
                    string gender = dt.Rows[0]["gender"].ToString();
                    string salary = dt.Rows[0]["salary"].ToString();
                    string job_post = dt.Rows[0]["job_post"].ToString();

                    textBox1.Text = id.ToString();
                    textBox6.Text = pass;
                    textBox2.Text = name;
                    textBox3.Text = phone;
                    textBox4.Text = address;
                    textBox5.Text = age.ToString();
                    dateTimePicker1.Text = DOB;
                    comboBox1.Text = gender;
                    textBox8.Text = salary;
                    comboBox2.Text = job_post;

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
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "DELETE FROM employee_info WHERE id = @id;";
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
                    textBox8.Clear();
                    comboBox2.Text = "Select Post";

                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "select* from employee_info";
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
            if (textBox1.Text != "" && textBox6.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "Select Gender" && textBox8.Text != "" && comboBox2.Text != "Select Post")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update employee_info set pass = @pass , name = @name , phone = @phone,address = @address,age = @age ,DOB = @DOB, gender = @gender, salary = @salary , job_post =  @job_post where id=@id";
               
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
                cmd.Parameters.AddWithValue("salary", textBox8.Text);
                cmd.Parameters.AddWithValue("job_post", comboBox2.Text);

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Employee Updated");
                    textBox1.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = "Select Gender";
                    textBox8.Clear();
                    comboBox2.Text = "Select Post";
                    SqlConnection con1 = new SqlConnection(cs);
                    string query1 = "select* from employee_info";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con1);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("Employee Update Error");
                }
            }
            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }
            

        }
    }
}
