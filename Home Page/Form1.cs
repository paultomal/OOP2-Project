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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int e_id;
        public static string ename;
        public static string ephone;
         public static string eaddress;
         public static int eage;
          public static string eDOB;
         public static string egender;
          public static string esalary;
           public static string ejob_post;
        public static int m_id;

        private void button2_Click(object sender, EventArgs e)
        {
            AboutUs a = new AboutUs();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            if (textBox1.Text != "" && textBox2.Text != "")

            {
               if (comboBox1.Text== "Admin")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select *from admin_info where id = @id and pass = @pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("id", textBox1.Text);
                    cmd.Parameters.AddWithValue("pass", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Admin_Info a = new Admin_Info();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your password or id is Incorrect,try again");
                    }
                }
               else if (comboBox1.Text == "Manager")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select *from manager_info where id = @id and pass = @pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("id", textBox1.Text);
                    cmd.Parameters.AddWithValue("pass", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        m_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                        Manager_Info a = new Manager_Info();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your password or id is Incorrect,try again");
                    }
                }
               else if(comboBox1.Text == "Employee")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select *from employee_info  where id = @id and pass = @pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("id", textBox1.Text);
                    cmd.Parameters.AddWithValue("pass", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        e_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                        
                       
                        ename = dt.Rows[0]["name"].ToString();
                        ephone = dt.Rows[0]["phone"].ToString();
                        eaddress = dt.Rows[0]["address"].ToString();
                        eage = Convert.ToInt32(dt.Rows[0]["age"].ToString());
                        eDOB = dt.Rows[0]["DOB"].ToString();
                        egender = dt.Rows[0]["gender"].ToString();
                        esalary = dt.Rows[0]["salary"].ToString();
                       ejob_post = dt.Rows[0]["job_post"].ToString();

                       

                        employee_info a = new employee_info();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your password or id is Incorrect,try again");
                    }

                }
               else
                {
                    MessageBox.Show("Select Valid Role");
                }

            }
            else
            {
                MessageBox.Show("Input ID and password");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "ID Cannot Be Empty!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
