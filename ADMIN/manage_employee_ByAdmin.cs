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
    public partial class manage_employee_ByAdmin : Form
    {
        public manage_employee_ByAdmin()
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void manage_employee_ByAdmin_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
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
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
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
                    /*
                     * int id
                     * string pass
                     *  string name
                     *  string phone
                     *  string address
                     *  int age
                     *  string DOB
                     *  string gender
                     *   string salary
                     *   string job_post
                     */

                    textBox1.Text = id.ToString();
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
    }
}
