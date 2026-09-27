using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            pnlType.Visible = false;
            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Apply ss = new Apply();
            ss.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage ss = new LoginPage();
            ss.Show();
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            pnlType.Visible=true;

        }

        private void rdnOrg_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            Organization ss = new Organization();
            ss.Show();
        }

        private void rdnIndividual_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            Individual ss = new Individual();
            ss.Show();
        }
    }
}
