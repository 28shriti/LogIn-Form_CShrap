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

namespace LogIn_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Password_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHRITI\\SQLEXPRESS;Initial Catalog=\"LogIn Form\";Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "Select Count(*) from loginForm where UserName = @Username and Password = @password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserName" , UserText.Text);
            cmd.Parameters.AddWithValue ("@Password" , Password.Text);
            int count = (int)cmd.ExecuteNonQuery();
            con.Close();
            if (count < 0)
            {
                MessageBox.Show("login Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error while login");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            PassText.PasswordChar=checkBox.Checked? '\0' : '*' ;
        }
    }
}
