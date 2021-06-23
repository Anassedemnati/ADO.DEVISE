using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviseInterface
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
               index= random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if(btnSender!=null)
            {
                if(currentButton!=(Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    
                }
            }
        }
        private void DisableButton()
        {
            foreach(Control previousBtn in panel1.Controls)
            {
                if(previousBtn.GetType()==typeof(Button))
                {
                    // previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(childForm);
            this.panelAffichage.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblAccueil.Text = childForm.Text;
        }

        private void convertisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convertisseur c = new Convertisseur();
            c.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void btnGestionClient_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new Convertisseur(),sender);

            GestionClient gc = new GestionClient();
            activeForm = gc;
            gc.TopLevel = false;
            gc.FormBorderStyle = FormBorderStyle.None;
            gc.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(gc);
            this.panelAffichage.Tag = gc;
            gc.BringToFront();
            gc.Show();

        }

        private void btnGestionCompte_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            GestionCompte gc = new GestionCompte();
            activeForm = gc;
            gc.TopLevel = false;
            gc.FormBorderStyle = FormBorderStyle.None;
            gc.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(gc);
            this.panelAffichage.Tag = gc;
            gc.BringToFront();
            gc.Show();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (panel3.Visible==false)
            {
                panel3.Show();
            }
            else
            {
                panel3.Hide();
            }
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
           
            
            Convertisseur cv = new Convertisseur();
            activeForm = cv;
            cv.TopLevel = false;
            cv.FormBorderStyle = FormBorderStyle.None;
            cv.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(cv);
            this.panelAffichage.Tag = cv;
            cv.BringToFront();
            cv.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            debite d = new debite();
            activeForm = d;
            d.TopLevel = false;
            d.FormBorderStyle = FormBorderStyle.None;
            d.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(d);
            this.panelAffichage.Tag = d;
            d.BringToFront();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            creadite d = new creadite();
           
            activeForm = d;
            d.TopLevel = false;
            d.FormBorderStyle = FormBorderStyle.None;
            d.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(d);
            this.panelAffichage.Tag = d;
            d.BringToFront();
            d.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Transfere d = new Transfere();

            activeForm = d;
            d.TopLevel = false;
            d.FormBorderStyle = FormBorderStyle.None;
            d.Dock = DockStyle.Fill;
            this.panelAffichage.Controls.Add(d);
            this.panelAffichage.Tag = d;
            d.BringToFront();
            d.Show();

        }

        private void panelAffichage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
