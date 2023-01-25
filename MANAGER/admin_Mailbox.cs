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
    public partial class admin_Mailbox : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
        public admin_Mailbox()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manager_Info a = new Manager_Info();
            a.Show();
            this.Hide();
        }

        private void admin_Mailbox_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from manager_mailbox ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into admin_mailbox (id,msg ) values(@id,@msg)";
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
                    string query1 = "select* from manager_mailbox";
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
