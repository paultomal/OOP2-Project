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
    public partial class details : Form
    {
        public details()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employee_info a = new employee_info();
            a.Show();
            this.Hide();
        }

        private void details_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.e_id.ToString();
            textBox2.Text = Form1.ename;
            textBox3.Text = Form1.ephone;
            textBox4.Text = Form1.eaddress;
            textBox5.Text = Form1.eage.ToString();
            dateTimePicker1.Text = Form1.eDOB;
            comboBox1.Text = Form1.egender;
            textBox8.Text = Form1.esalary;
            comboBox2.Text = Form1.ejob_post;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["OOP2_PROJECT"].ConnectionString;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "" && comboBox1.Text != "Select Gender" && textBox8.Text != "" && comboBox2.Text != "Select Post")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update employee_info  set  name = @name , phone = @phone,address = @address,age = @age ,DOB = @DOB, gender = @gender  where id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("phone", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                cmd.Parameters.AddWithValue("age", textBox5.Text);
                cmd.Parameters.AddWithValue("DOB", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("gender", comboBox1.Text);


                int a = cmd.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("My Details Updated");

                    textBox1.Text = Form1.e_id.ToString();
                    textBox2.Text = Form1.ename;
                    textBox3.Text = Form1.ephone;
                    textBox4.Text = Form1.eaddress;
                    textBox5.Text = Form1.eage.ToString();
                    dateTimePicker1.Text = Form1.eDOB;
                    comboBox1.Text = Form1.egender;
                    textBox8.Text = Form1.esalary;
                    comboBox2.Text = Form1.ejob_post;

                   

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
