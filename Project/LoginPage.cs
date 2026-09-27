using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btbCancell_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome ss = new frmHome();
            ss.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(
        @"C:\Users\Ayanda Khandayo\Desktop\Application.txt"
    );

            string[] Array = new string[12];

            string lineRec = "";
            string username = txtUser.Text;
            string password = txtPass.Text;

            bool login = false;
            string userType = "";

            using (reader)
            {
                lineRec = reader.ReadLine();

                while (lineRec != null)
                {
                    Array = lineRec.Split('\t');

                    // Check Organization Donor or Apply for Donation
                    if (Array[0] == "Organization" ||
                        Array[0] == "Apply")
                    {
                        if (username == Array[2] && password == Array[5])
                        {
                            login = true;
                            userType = Array[0];
                            break;
                        }
                    }

                    // Check Individual Donor
                    else if (Array[0] == "Individual")
                    {
                        if (username == Array[4] && password == Array[10])
                        {
                            login = true;
                            userType = Array[0];
                            break;
                        }
                    }

                    lineRec = reader.ReadLine();
                }
            }

            if (login)
            {
                MessageBox.Show("Login Successfully", "Notification");

                // Open the correct form depending on user type
                if (userType == "Apply")
                {
                    this.Hide();

                    Application ss = new Application();
                    ss.Show();
                }
                else if (userType == "Organization" ||
                         userType == "Individual")
                {
                    this.Hide();

                    Donor ss = new Donor();
                    ss.Show();
                }
            }
            else
            {
                MessageBox.Show(
                    "Invalid Username or Password. Please try again.",
                    "Notification"
                );
            }

            txtUser.Clear();
            txtPass.Clear();



        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void chkMask_CheckedChanged(object sender, EventArgs e)
        {
           if(chkMask.Checked)
            {
                // Unmask password to reveal plain text
                txtPass.UseSystemPasswordChar = false;
               
            }
            else
            {
                // Mask password characters
                txtPass.UseSystemPasswordChar = true;
               
            }
        }
    }
}
