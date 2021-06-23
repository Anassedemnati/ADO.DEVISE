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
    public partial class GestionClient : Form
    {
        public GestionClient()
        {
            InitializeComponent();
        }



      
       
        public void afficher()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            String req1 = "select * from titulaire";
            SqlCommand st = new SqlCommand(req1, sql);
            sql.Open();
            SqlDataReader Dr = st.ExecuteReader();
            while (Dr.Read())
            {
                this.dataGridView1.Rows.Add(Dr["id"], Dr["nom"], Dr["prenom"], Dr["adresse"]);
            }
            sql.Close();

        }

        private void GestionClient_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            afficher();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            string v2 = textBox2.Text;
 
            string v3 = textBox3.Text;
            string v1 = textBox1.Text;

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            sql.Open();
            String req1 = "insert into titulaire values('" + v1 + "','" + v2 + "','" + v3 + "')";
            SqlCommand st = new SqlCommand(req1, sql);

            int a = st.ExecuteNonQuery(); // where where  1 0 = eureru
            MessageBox.Show(a + "row ADD");
            dataGridView1.Rows.Clear();
            afficher();
            sql.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = this.dataGridView1.CurrentRow.Index;
            label4.Text= this.dataGridView1.Rows[p].Cells[0].Value.ToString();
            textBox1.Text = this.dataGridView1.Rows[p].Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.Rows[p].Cells[2].Value.ToString();
            textBox3.Text = this.dataGridView1.Rows[p].Cells[3].Value.ToString();
 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";

            int p = this.dataGridView1.CurrentRow.Index; // il donne la valeur de la ligne qui il selectione

            string id = this.dataGridView1.Rows[p].Cells[0].Value.ToString();

            String req1 = "delete from titulaire where id = '" + id + "'";

            SqlCommand st = new SqlCommand(req1, sql);
            sql.Open();
            int a = st.ExecuteNonQuery();
            MessageBox.Show(a + "row suprimer");
            dataGridView1.Rows.Clear();
            afficher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string v1 = label4.Text;
            string v2 = textBox1.Text;
            string v3 = textBox2.Text;
            string v4 = textBox3.Text;

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            sql.Open();
            String req1 = "update titulaire set nom='" + v2 + "',prenom='" + v3 + "',adresse='" + v4 + "' where id='" + v1 + "'";
            Console.WriteLine(req1);
            SqlCommand st = new SqlCommand(req1, sql);

            int a = st.ExecuteNonQuery();
            MessageBox.Show(a + " row updated");
            dataGridView1.Rows.Clear();
            afficher();
        }
    }
}
