using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemQuiche
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
         
        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            //progressBar1.Width = this.Width;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            progressBar1.Visible = true;

            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value == 10)
            {
                label1.Text = "Lendo módulos...";
            }
            else if (this.progressBar1.Value == 20)
            {
                label1.Text = "Ativando módulos...";
            }
            else if (this.progressBar1.Value == 40)
            {
                label1.Text = "Iniciando módulos...";
            }
            else if (this.progressBar1.Value == 60)
            {
                label1.Text = "Carregando módulos...";
            }
            else if (this.progressBar1.Value == 80)
            {
                label1.Text = "Preparando módulos...";
            }
            else if (this.progressBar1.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                this.Hide();
            }
        }
    }
}
