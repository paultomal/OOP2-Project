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
    public partial class manager_mailbox : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
        public manager_mailbox()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_Info a = new Admin_Info();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Info a = new Admin_Info();
            a.Show();
            this.Hide();
        }

        private void manager_mailbox_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from admin_mailbox ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" &&  textBox2.Text != "" )
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into manager_mailbox (id,msg ) values(@id,@msg)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                
                cmd.Parameters.AddWithValue("msg", textBox2.Text);
               

                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Work Done");
                    textBox1.Clear();
                   
                    textBox2.Clear();
                   
                    SqlConnection con1 = new SqlConnection(cs);
                    string query1 = "select* from admin_mailbox";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con1);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    MessageBox.Show("WorkDone Error");
                }
            }
            else
            {
                MessageBox.Show("Fill ALL the Information First!");
            }
        }
    }
}
