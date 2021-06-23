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
    public partial class Transfere : Form
    {
        public Transfere()
        {
            InitializeComponent();
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

        private void Transfere_Load(object sender, EventArgs e)
        {
            afficher();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string v2 = textBox1.Text;

            string v3 = textBox3.Text;
            string V1 = textBox2.Text;


            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-H1FL3IL;Initial Catalog=ecom;Integrated Security=True";
            sql.Open();
            String req1 = "update compte set solde -='" + v3 + "' where numcompte='" + v2 + "'";
            Console.WriteLine(req1);
            SqlCommand st = new SqlCommand(req1, sql);


            String req2 = "update compte set solde +='" + v3 + "' where numcompte='" + V1 + "'";
            Console.WriteLine(req1);
            SqlCommand st2 = new SqlCommand(req2, sql);

            st2.ExecuteNonQuery();
            int a = st.ExecuteNonQuery();
            MessageBox.Show(a + " row updated");
            dataGridView1.Rows.Clear();
            afficher();
        }
    }
}
