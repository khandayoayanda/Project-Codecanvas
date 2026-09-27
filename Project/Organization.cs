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
    public partial class Organization : Form
    {
        string selectedFilePath = "";
        public Organization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome ss = new frmHome();
            ss.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage ss = new LoginPage();
            ss.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string Regnum = txtRegnum.Text;
            string Email = txtEmail.Text;
            string Adress = txtAdress.Text;
            string Create = txtCreate.Text;
            string Confirm = txtConfirm.Text;
            string selectedFilePath = "";


            int Code = int.Parse(txtCode.Text);





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
            // 2. NPO NUMBER VALIDATION (000-000 format

            if (!Regex.IsMatch(Regnum, @"^\d{3}-\d{3}$"))
            {
                MessageBox.Show("Invalid NPO Registration Number.\nPlease use the format: 000-000 (e.g., 123-456).",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRegnum.Focus();
                txtRegnum.SelectAll();
                return;
            }

            // 3. ORGANISATION EMAIL VALIDATION
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.\nPlease enter a valid organisation email (e.g., info@organisation.org).",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            string[] personalDomains = { "@gmail.com", "@yahoo.com", "@outlook.com", "@hotmail.com" };
            foreach (string domain in personalDomains)
            {
                if (Email.EndsWith(domain, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Please provide an official organisation email address rather than a personal account.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    return;
                }
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

            // 5. PASSWORD MATCH VALIDATION
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
                writer.Write(Name + '\t' + Regnum + '\t' + Email + '\t' + Province + '\t' + Adress + '\t' + Create + '\t' + Confirm + "\n");
            }
            try
            {
                // 1. Target location: "SavedDocuments" on your Desktop
                string destinationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SavedDocuments");

                // 2. Create the folder if it doesn't exist
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // 3. Create a unique file name
                string fileExtension = Path.GetExtension(selectedFilePath);
                string cleanNPO = txtRegnum.Text.Replace("-", "");
                string newFileName = $"NPO_{cleanNPO}_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}";

                // 4. Full target path
                string destinationPath = Path.Combine(destinationFolder, newFileName);

                // 5. Save/Copy the file directly to your PC
                File.Copy(selectedFilePath, destinationPath, true);

                // 6. Append record to Applications.txt (use destinationPath as the saved document location)
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Application.txt");
                string record = $"{Name}#{Regnum}#{destinationPath}#{Email}#{Province}#{Adress}#{Code}#{Create}";

                using (StreamWriter SW = new StreamWriter(filePath, true))
                {
                    SW.WriteLine(record);
                }

                MessageBox.Show("Application submitted and document saved to PC successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtName.Clear();
            txtRegnum.Clear();
            txtEmail.Clear();
            txtAdress.Clear();
            txtCreate.Clear();
            txtConfirm.Clear();
            txtCode.Clear();
            cmbProvince.SelectedIndex = -1;

            MessageBox.Show("Account Registerd successfully Successfully", "Notification");

            this.Hide();
            Donor ss = new Donor();
            ss.Show();

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Legal Proof Document";

                openFileDialog.Filter =
                    "Supported Documents (*.pdf;*.docx;*.jpg;*.png)|*.pdf;*.docx;*.jpg;*.png|" +
                    "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the full path
                    this.selectedFilePath = openFileDialog.FileName;

                    // Display only the file name
                    txtBrowse.Text = Path.GetFileName(openFileDialog.FileName);
                }
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

        private void txtRegnum_TextChanged(object sender, EventArgs e)
        {
            
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
    }

    }