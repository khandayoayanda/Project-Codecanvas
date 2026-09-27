using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Individual : Form
    {
        public Individual()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {


            this.Hide();
            frmHome ss = new frmHome();
            ss.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

            string Firstname = txtName.Text;
            string Lastname = txtSurname.Text;
            string Number = txtNum.Text.Trim();
            string dateOfBirth =  dtpDOB.Value.ToString("dd/MM/yyyy");
            string Email = txtEmail.Text;
            string Gender="";
            string Adress = txtAdress.Text;
            string Create = txtCreate.Text;
            string Confirm = txtConfirm.Text;
            string Code = txtCode.Text;

            if(rdnMale.Checked)
            {
                Gender = "Male";
            }
            else
                if(rdnFemale.Checked)
                {
                    Gender = "Female";
                }

            string Province = "";

            if (cmbProvince.SelectedIndex == 0)
            {
                Province = "Eastern Cape";

            }
            else
                if (cmbProvince.SelectedIndex == 1)
                {
                    Province = "Kwazulu NAtal";

                }
                else
                    if (cmbProvince.SelectedIndex == 2)
                    {
                        Province = "Gauteng";
                    }
                    else
                        if (cmbProvince.SelectedIndex == 3)
                        {
                            Province = "Mpumalanga";
                        }
                        else
                            if (cmbProvince.SelectedIndex == 4)
                            {
                                Province = "Northern-Cape";
                            }
                            else
                                if (cmbProvince.SelectedIndex == 5)
                                {
                                    Province = "North-West";
                                }
                                else
                                    if (cmbProvince.SelectedIndex == 6)
                                    {
                                        Province = "Free State";
                                    }
                                    else
                                        if (cmbProvince.SelectedIndex == 7)
                                        {
                                            Province = "Limpopo";
                                        }
                                        else
                                        {
                                            Province = "Western-Cape";
                                        }

            // Check if the cellphone number is empty
            if (Number == "")
            {
                MessageBox.Show(
                    "Please enter your cellphone number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNum.Focus();
                return;
            }

            // Check for a valid South African mobile number
            // Starts with 0, followed by 6, 7, or 8,
            // followed by another 8 digits = 10 digits total
            if (!Regex.IsMatch(Number, @"^0[678]\d{8}$"))
            {
                MessageBox.Show(
                    "Please enter a valid 10-digit South African mobile number.\n\nExample: 0821234567",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNum.Focus();
                txtNum.SelectAll();
                return;
            }

            // 4. PHYSICAL ADDRESS VALIDATION
            if (string.IsNullOrWhiteSpace(Adress))
            {
                MessageBox.Show("Please enter the physical address.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdress.Focus();
                return;
            }

            if (Regex.IsMatch(Adress, @"\b\d{4}\b"))
            {
                MessageBox.Show("Please enter the physical address ONLY. Do not include a 4-digit postal code in this field.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdress.Focus();
                txtAdress.SelectAll();
                return;
            }
            //PASSWORD MATCH AND STRENGTH VALIDATION
            if (string.IsNullOrWhiteSpace(Create))
            {
                MessageBox.Show("Password cannot be empty.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }

            // Check if password has at least 8 characters
            if (Create.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }

            // Check for uppercase letter
            if (!Create.Any(char.IsUpper))
            {
                MessageBox.Show("Password must contain at least one uppercase letter.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }

            // Check for lowercase letter
            if (!Create.Any(char.IsLower))
            {
                MessageBox.Show("Password must contain at least one lowercase letter.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }

            // Check for number
            if (!Create.Any(char.IsDigit))
            {
                MessageBox.Show("Password must contain at least one number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }

            // Check for special character
            if (!Create.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Password must contain at least one special character.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }

            // Confirm password
            if (Create != Confirm)
            {
                MessageBox.Show("Passwords do not match.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCreate.Focus();
                return;
            }
            StreamWriter writer = new StreamWriter(@"C:\Users\Ayanda Khandayo\Desktop\Application.txt", true);

            using (writer)
            {
                writer.Write("Individual"+'\t'+Firstname +'\t'+Lastname+ '\t'+Number+'\t'+Email+'\t'+Gender +'\t' +dateOfBirth   + '\t' + Province + '\t' + Adress +'\t'+Code+ '\t' + Create + '\t' + Confirm + "\n");
            }

           

         

            txtName.Clear();

           
            txtEmail.Clear();
            txtAdress.Clear();
            txtCreate.Clear();
            txtConfirm.Clear();
            txtCode.Clear();
            
            cmbProvince.SelectedIndex = -1;

            this.Hide();
            Donor ss = new Donor();
            ss.Show();

            MessageBox.Show("Account registered successfully","Notification");
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            string cellNumber = txtNum.Text.Trim();

            // Allow the textbox to be empty while the user is typing
            if (cellNumber == "")
            {
                errorProvider1.SetError(txtNum, "");
                return;
            }

            // Check that numbers only are entered
            if (!Regex.IsMatch(cellNumber, @"^\d+$"))
            {
                errorProvider1.SetError(txtNum, "Numbers only are allowed.");
            }
            else
            {
                errorProvider1.SetError(txtNum, "");
            }


        }  

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            double i = 0;
            if (double.TryParse(txtCode.Text, out i))
            {
                errorProvider1.SetError(txtCode, "");
            }
            else
            {
                errorProvider1.SetError(txtCode, "Its allowed number's only.");
            }
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtCreate.Text != "" && txtConfirm.Text == txtCreate.Text)
            {
                errorProvider1.SetError(txtConfirm, "");
            }
            else
            {
                errorProvider1.SetError(txtConfirm, "Password does not match!!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Individual_Load(object sender, EventArgs e)
        {

        }
    }
}
