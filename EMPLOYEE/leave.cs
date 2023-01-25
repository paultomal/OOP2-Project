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
    public partial class leave : Form
    {
        public leave()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employee_info a = new employee_info();
            a.Show();
            this.Hide();
        }

        private void leave_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            textBox1.Text =  Form1.e_id.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            if (textBox1.Text != ""  && dateTimePicker1.Text != ""&& dateTimePicker2.Text != "" && textBox3.Text != "" &&  textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into applyforleave (id,leave_from, leave_end, total_days, reason  ) values(@id,@leave_from, @leave_end, @total_days, @reason)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("leave_from", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("leave_end", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("total_days", textBox3.Text);
                cmd.Parameters.AddWithValue("reason", textBox2.Text);
                

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Application Submitted");
                    textBox2.Clear();
                    textBox3.Clear();


                }
                else
                {
                    MessageBox.Show("Application Submittion Failled");
                }
            }
            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            

            
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from leave_approve where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    textBox4.Text = "You're on Leave";

                }
                SqlConnection con1 = new SqlConnection(cs);
                string query1 = "select *from leave_deny where id = @id ";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                con1.Open();
                cmd1.Parameters.AddWithValue("id", textBox1.Text);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {

                    textBox4.Text = "You're appliction Denied";

                }
            
           
        }
    }
}
