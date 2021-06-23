using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeviseInterface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userlogin = textBox1.Text;
            string userPassword = textBox2.Text;
            //la connexion
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True");
            SqlCommand cm = new SqlCommand("select * from admin1 where username='" + userlogin + "' and pass='" + userPassword + "'", con);
            con.Open();
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {

                Form1 f = new Form1();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("info incoorect");
            }

            textBox1.Text="";
            textBox2.Text="";

        }
    }
}
