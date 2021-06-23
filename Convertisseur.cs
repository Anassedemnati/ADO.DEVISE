using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviseLibrary;

namespace DeviseInterface
{
    public partial class Convertisseur : Form
    {
        public Convertisseur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double start = double.Parse(textBox1.Text);
            string type_start = comboBox1.Text;
            string type_end = comboBox2.Text;

           Devise d1;
           
            if(type_start=="MAD")
            {
                d1 = new MAD(start);
            }
            else if (type_start=="US")
            {
               d1=new US(start);
            }
           else
           {
             d1=new EU(start);
           }

           //ConvertTo
           Devise res= d1.CovertTo(type_end);
          //  MessageBox.Show(d1.CovertTo(type_end).ToString());
           textBox2.Text=res.ToString();

       


        }
    }
}
