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
    public partial class givework : Form
    {
        public givework()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager_Info a = new Manager_Info();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into work_for_employee (id,work ) values(@id,@work)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);

                cmd.Parameters.AddWithValue("work", textBox2.Text);


                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("SENTED");
                    textBox1.Clear();

                    textBox2.Clear();

                    

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

        private void givework_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
