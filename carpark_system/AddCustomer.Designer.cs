namespace carpark_system
{
    partial class AddCustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustomerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizebtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uidtxt = new System.Windows.Forms.TextBox();
            this.licenseplatetxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.phonetxt = new System.Windows.Forms.TextBox();
            this.gendercb = new System.Windows.Forms.ComboBox();
            this.datepaycheckpicker = new System.Windows.Forms.DateTimePicker();
            this.addbtn = new System.Windows.Forms.Button();
            this.scanbtn = new System.Windows.Forms.Button();
            this.connectbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.minimizebtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 45);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // minimizebtn
            // 
            this.minimizebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizebtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.minimizebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("minimizebtn.BackgroundImage")));
            this.minimizebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimizebtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.minimizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizebtn.Location = new System.Drawing.Point(538, 0);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.Size = new System.Drawing.Size(45, 45);
            this.minimizebtn.TabIndex = 1;
            this.minimizebtn.UseVisualStyleBackColor = false;
            this.minimizebtn.Click += new System.EventHandler(this.minimizebtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelbtn.BackgroundImage")));
            this.cancelbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelbtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Location = new System.Drawing.Point(589, 0);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(45, 45);
            this.cancelbtn.TabIndex = 1;
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "ADD CUSTOMER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Uid";
            // 
            // uidtxt
            // 
            this.uidtxt.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uidtxt.Location = new System.Drawing.Point(162, 92);
            this.uidtxt.Name = "uidtxt";
            this.uidtxt.Size = new System.Drawing.Size(314, 26);
            this.uidtxt.TabIndex = 4;
            this.uidtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uidtxt_KeyDown);
            // 
            // licenseplatetxt
            // 
            this.licenseplatetxt.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseplatetxt.Location = new System.Drawing.Point(162, 134);
            this.licenseplatetxt.Name = "licenseplatetxt";
            this.licenseplatetxt.Size = new System.Drawing.Size(314, 26);
            this.licenseplatetxt.TabIndex = 4;
            this.licenseplatetxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.licenseplatetxt_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "License plate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Gender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Phone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Date paycheck";
            // 
            // usernametxt
            // 
            this.usernametxt.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametxt.Location = new System.Drawing.Point(162, 176);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(314, 26);
            this.usernametxt.TabIndex = 4;
            this.usernametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernametxt_KeyDown);
            // 
            // phonetxt
            // 
            this.phonetxt.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonetxt.Location = new System.Drawing.Point(162, 259);
            this.phonetxt.Name = "phonetxt";
            this.phonetxt.Size = new System.Drawing.Size(314, 26);
            this.phonetxt.TabIndex = 4;
            this.phonetxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phonetxt_KeyDown);
            // 
            // gendercb
            // 
            this.gendercb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gendercb.FormattingEnabled = true;
            this.gendercb.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.gendercb.Location = new System.Drawing.Point(162, 217);
            this.gendercb.Name = "gendercb";
            this.gendercb.Size = new System.Drawing.Size(314, 27);
            this.gendercb.TabIndex = 5;
            this.gendercb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gendercb_KeyDown);
            // 
            // datepaycheckpicker
            // 
            this.datepaycheckpicker.CalendarFont = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepaycheckpicker.Location = new System.Drawing.Point(162, 300);
            this.datepaycheckpicker.Name = "datepaycheckpicker";
            this.datepaycheckpicker.Size = new System.Drawing.Size(314, 20);
            this.datepaycheckpicker.TabIndex = 6;
            this.datepaycheckpicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datepaycheckpicker_KeyDown);
            // 
            // addbtn
            // 
            this.addbtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.Location = new System.Drawing.Point(252, 342);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(134, 40);
            this.addbtn.TabIndex = 7;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // scanbtn
            // 
            this.scanbtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanbtn.Location = new System.Drawing.Point(489, 125);
            this.scanbtn.Name = "scanbtn";
            this.scanbtn.Size = new System.Drawing.Size(99, 44);
            this.scanbtn.TabIndex = 8;
            this.scanbtn.Text = "Scan";
            this.scanbtn.UseVisualStyleBackColor = true;
            this.scanbtn.Click += new System.EventHandler(this.scanbtn_Click);
            // 
            // connectbtn
            // 
            this.connectbtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectbtn.Location = new System.Drawing.Point(489, 52);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(99, 66);
            this.connectbtn.TabIndex = 8;
            this.connectbtn.Text = "Connect com";
            this.connectbtn.UseVisualStyleBackColor = true;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(634, 394);
            this.Controls.Add(this.connectbtn);
            this.Controls.Add(this.scanbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.datepaycheckpicker);
            this.Controls.Add(this.gendercb);
            this.Controls.Add(this.phonetxt);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.licenseplatetxt);
            this.Controls.Add(this.uidtxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCustomer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCustomerForm_FormClosing);
            this.Load += new System.EventHandler(this.AddCustomerForm_Load);
            this.Shown += new System.EventHandler(this.AddCustomerForm_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button minimizebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uidtxt;
        private System.Windows.Forms.TextBox licenseplatetxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.TextBox phonetxt;
        private System.Windows.Forms.ComboBox gendercb;
        private System.Windows.Forms.DateTimePicker datepaycheckpicker;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button scanbtn;
        private System.Windows.Forms.Button connectbtn;
    }
}