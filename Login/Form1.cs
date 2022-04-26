using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            SqlConnection con = new SqlConnection(Elaqe.GetConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM USERS WHERE usernames = '" + name + "' AND password = '" + password + "'", con);
            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            int dr = Convert.ToInt32(cmd.ExecuteScalar());
            if (dr==1)
            {
                MessageBox.Show("Succes");
            }
            else
            {
                MessageBox.Show("Is invalid Username or Password");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
