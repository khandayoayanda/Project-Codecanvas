namespace Project
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNow = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnlType = new System.Windows.Forms.Panel();
            this.rdnIndividual = new System.Windows.Forms.RadioButton();
            this.rdnOrg = new System.Windows.Forms.RadioButton();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNow
            // 
            this.btnNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNow.Location = new System.Drawing.Point(44, 477);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(130, 51);
            this.btnNow.TabIndex = 0;
            this.btnNow.Text = "Donate now";
            this.btnNow.UseVisualStyleBackColor = false;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnApply.Location = new System.Drawing.Point(242, 477);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(192, 51);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply for donation";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // pnlType
            // 
            this.pnlType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlType.Controls.Add(this.rdnIndividual);
            this.pnlType.Controls.Add(this.rdnOrg);
            this.pnlType.Location = new System.Drawing.Point(12, 534);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(200, 78);
            this.pnlType.TabIndex = 2;
            // 
            // rdnIndividual
            // 
            this.rdnIndividual.AutoSize = true;
            this.rdnIndividual.Location = new System.Drawing.Point(0, 35);
            this.rdnIndividual.Name = "rdnIndividual";
            this.rdnIndividual.Size = new System.Drawing.Size(116, 26);
            this.rdnIndividual.TabIndex = 3;
            this.rdnIndividual.TabStop = true;
            this.rdnIndividual.Text = "Individual";
            this.rdnIndividual.UseVisualStyleBackColor = true;
            this.rdnIndividual.CheckedChanged += new System.EventHandler(this.rdnIndividual_CheckedChanged);
            // 
            // rdnOrg
            // 
            this.rdnOrg.AutoSize = true;
            this.rdnOrg.Location = new System.Drawing.Point(0, 3);
            this.rdnOrg.Name = "rdnOrg";
            this.rdnOrg.Size = new System.Drawing.Size(144, 26);
            this.rdnOrg.TabIndex = 4;
            this.rdnOrg.TabStop = true;
            this.rdnOrg.Text = "Organization";
            this.rdnOrg.UseVisualStyleBackColor = true;
            this.rdnOrg.CheckedChanged += new System.EventHandler(this.rdnOrg_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(1243, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(130, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project.Properties.Resources.Blank_background;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pnlType);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnNow);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHome";
            this.Text = "Home page";
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.RadioButton rdnIndividual;
        private System.Windows.Forms.RadioButton rdnOrg;
        private System.Windows.Forms.Button btnLogin;
    }
}

