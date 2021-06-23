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
    public partial class GestionCompte : Form
    {
        public GestionCompte()
        {
            InitializeComponent();
        }

        public void combotitu()
        {

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            sql.Open();
            string req = "select  DISTINCT(nom),id from titulaire";
            SqlCommand cmd = new SqlCommand(req, sql);
            SqlDataAdapter da = new SqlDataAdapter(req, sql);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            sql.Close();

            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = ds.Tables[0];




        }

        public void afficher()
        {

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            String req1 = "select a.numcompte,p.nom,a.solde,a.plafond from compte a join titulaire p on(a.id=p.id) ";

            SqlCommand st = new SqlCommand(req1, sql);




            sql.Open();
            SqlDataReader Dr = st.ExecuteReader();
            while (Dr.Read())
            {
              
                this.dataGridView1.Rows.Add(Dr["numcompte"], Dr["nom"], Dr["solde"], Dr["plafond"]);
            }
            sql.Close();




        }



        private void GestionCompte_Load(object sender, EventArgs e)
        {
            combotitu();
           afficher();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string v1 = textBox1.Text;
            string v2 = textBox3.Text;
            string v3 = textBox4.Text;


            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";




            sql.Open();
            String req1 = "insert into compte values('"+v1+"','" + comboBox1.SelectedValue + "','"+v2+"','"+v3+"') ";
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
       
            textBox1.Text = this.dataGridView1.Rows[p].Cells[0].Value.ToString();
            comboBox1.Text = this.dataGridView1.Rows[p].Cells[1].Value.ToString();
            textBox3.Text = this.dataGridView1.Rows[p].Cells[2].Value.ToString();
            textBox4.Text = this.dataGridView1.Rows[p].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";

            int p = this.dataGridView1.CurrentRow.Index; // il donne la valeur de la ligne qui il selectione

            string id = this.dataGridView1.Rows[p].Cells[0].Value.ToString();

            String req1 = "delete from compte where numcompte = '" + id + "'";

            SqlCommand st = new SqlCommand(req1, sql);
            sql.Open();
            int a = st.ExecuteNonQuery();
            MessageBox.Show(a + "row suprimer");
            dataGridView1.Rows.Clear();
            afficher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string v2 = textBox1.Text;
     
            string v3 = textBox3.Text;
            string v4 = textBox4.Text;

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            sql.Open();
            String req1 = "update compte set id='" + comboBox1.SelectedValue + "',solde='" + v3 + "',plafond='" + v4 + "' where numcompte='" + v2 + "'";
            Console.WriteLine(req1);
            SqlCommand st = new SqlCommand(req1, sql);

            int a = st.ExecuteNonQuery();
            MessageBox.Show(a + " row updated");
            dataGridView1.Rows.Clear();
            afficher();
        }
    }
}
