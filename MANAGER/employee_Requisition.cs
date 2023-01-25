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
    public partial class employee_Requisition : Form
    {
       public static int total_days;
        string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
        public employee_Requisition()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manager_Info a = new Manager_Info();
            a.Show();
            this.Hide();
        }

        private void employee_Requisition_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from applyforleave";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            SqlConnection con1 = new SqlConnection(cs);
            string query1 = "select *from leave_approve";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")

            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from applyforleave where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["id"].ToString());

                     total_days = Convert.ToInt32(dt.Rows[0]["total_days"].ToString());
                    

                    textBox1.Text = id.ToString();
                   
                    textBox2.Text = total_days.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into leave_approve (id,total_days) values(@id,@total_days)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                
                cmd.Parameters.AddWithValue("total_days", textBox2.Text);


                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Leave APPROVED");
                    SqlConnection con4 = new SqlConnection(cs);
                    string query4 = "select *from leave_approve";
                    SqlDataAdapter sda1 = new SqlDataAdapter(query4, con4);
                    DataTable data1 = new DataTable();
                    sda1.Fill(data1);
                    dataGridView2.DataSource = data1;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("Something Wrong. Try again");
                }
                
                SqlConnection con1 = new SqlConnection(cs);
                string query1 = "DELETE FROM applyforleave WHERE id = @id;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                con1.Open();

                cmd1.Parameters.AddWithValue("id", textBox1.Text);
                int a1 = cmd1.ExecuteNonQuery();
                if (a1 > 0)
                {
                    SqlConnection con3 = new SqlConnection(cs);
                    string query3 = "select *from applyforleave";
                    SqlDataAdapter sda = new SqlDataAdapter(query3, con3);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }

            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into leave_deny  (id) values(@id)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);

               

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Leave DENIED");
                    

                }
                else
                {
                    MessageBox.Show("Something Wrong. Try again");
                }

                SqlConnection con1 = new SqlConnection(cs);
                string query1 = "DELETE FROM applyforleave WHERE id = @id;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                con1.Open();

                cmd1.Parameters.AddWithValue("id", textBox1.Text);
                int a1 = cmd1.ExecuteNonQuery();
                if (a1 > 0)
                {
                    SqlConnection con3 = new SqlConnection(cs);
                    string query3 = "select *from applyforleave";
                    SqlDataAdapter sda = new SqlDataAdapter(query3, con3);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }

            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }

        }
    }
}
