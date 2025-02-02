namespace carpark_system
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.employeebtn = new System.Windows.Forms.Button();
            this.namelb = new System.Windows.Forms.Label();
            this.customerbtn = new System.Windows.Forms.Button();
            this.dashboardbtn = new System.Windows.Forms.Button();
            this.Customergridview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.findCustomertxt = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.addCustomerbtn = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customergridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.logoutbtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.employeebtn);
            this.panel1.Controls.Add(this.namelb);
            this.panel1.Controls.Add(this.customerbtn);
            this.panel1.Controls.Add(this.dashboardbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 452);
            this.panel1.TabIndex = 0;
            // 
            // logoutbtn
            // 
            this.logoutbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoutbtn.BackColor = System.Drawing.Color.LightSalmon;
            this.logoutbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoutbtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutbtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.Image = ((System.Drawing.Image)(resources.GetObject("logoutbtn.Image")));
            this.logoutbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutbtn.Location = new System.Drawing.Point(0, 385);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Padding = new System.Windows.Forms.Padding(4);
            this.logoutbtn.Size = new System.Drawing.Size(178, 55);
            this.logoutbtn.TabIndex = 11;
            this.logoutbtn.Text = "     Logout";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSalmon;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 136);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // employeebtn
            // 
            this.employeebtn.BackColor = System.Drawing.Color.LightSalmon;
            this.employeebtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.employeebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeebtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeebtn.Image = ((System.Drawing.Image)(resources.GetObject("employeebtn.Image")));
            this.employeebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeebtn.Location = new System.Drawing.Point(0, 301);
            this.employeebtn.Name = "employeebtn";
            this.employeebtn.Padding = new System.Windows.Forms.Padding(4);
            this.employeebtn.Size = new System.Drawing.Size(178, 55);
            this.employeebtn.TabIndex = 12;
            this.employeebtn.Text = "        Add employee";
            this.employeebtn.UseVisualStyleBackColor = false;
            this.employeebtn.Click += new System.EventHandler(this.employeebtn_Click);
            // 
            // namelb
            // 
            this.namelb.AutoSize = true;
            this.namelb.BackColor = System.Drawing.Color.LightSalmon;
            this.namelb.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelb.Location = new System.Drawing.Point(19, 151);
            this.namelb.Name = "namelb";
            this.namelb.Size = new System.Drawing.Size(140, 25);
            this.namelb.TabIndex = 10;
            this.namelb.Text = "Welcome User";
            // 
            // customerbtn
            // 
            this.customerbtn.BackColor = System.Drawing.Color.LightSalmon;
            this.customerbtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.customerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customerbtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerbtn.Image = ((System.Drawing.Image)(resources.GetObject("customerbtn.Image")));
            this.customerbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customerbtn.Location = new System.Drawing.Point(0, 240);
            this.customerbtn.Name = "customerbtn";
            this.customerbtn.Padding = new System.Windows.Forms.Padding(4);
            this.customerbtn.Size = new System.Drawing.Size(178, 55);
            this.customerbtn.TabIndex = 13;
            this.customerbtn.Text = "        Add customer";
            this.customerbtn.UseVisualStyleBackColor = false;
            // 
            // dashboardbtn
            // 
            this.dashboardbtn.BackColor = System.Drawing.Color.LightSalmon;
            this.dashboardbtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.dashboardbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardbtn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardbtn.Image = ((System.Drawing.Image)(resources.GetObject("dashboardbtn.Image")));
            this.dashboardbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardbtn.Location = new System.Drawing.Point(0, 179);
            this.dashboardbtn.Name = "dashboardbtn";
            this.dashboardbtn.Padding = new System.Windows.Forms.Padding(4);
            this.dashboardbtn.Size = new System.Drawing.Size(178, 55);
            this.dashboardbtn.TabIndex = 14;
            this.dashboardbtn.Text = "        Dashboard";
            this.dashboardbtn.UseVisualStyleBackColor = false;
            this.dashboardbtn.Click += new System.EventHandler(this.dashboardbtn_Click);
            // 
            // Customergridview
            // 
            this.Customergridview.AllowUserToAddRows = false;
            this.Customergridview.AllowUserToDeleteRows = false;
            this.Customergridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Customergridview.BackgroundColor = System.Drawing.Color.White;
            this.Customergridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Customergridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.Customergridview.GridColor = System.Drawing.Color.White;
            this.Customergridview.Location = new System.Drawing.Point(184, 66);
            this.Customergridview.Name = "Customergridview";
            this.Customergridview.ReadOnly = true;
            this.Customergridview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Customergridview.RowHeadersVisible = false;
            this.Customergridview.Size = new System.Drawing.Size(1099, 374);
            this.Customergridview.TabIndex = 0;
            this.Customergridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Customergridview_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer";
            // 
            // findCustomertxt
            // 
            this.findCustomertxt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCustomertxt.Location = new System.Drawing.Point(353, 17);
            this.findCustomertxt.Name = "findCustomertxt";
            this.findCustomertxt.Size = new System.Drawing.Size(233, 30);
            this.findCustomertxt.TabIndex = 3;
            this.findCustomertxt.TextChanged += new System.EventHandler(this.findCustomertxt_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Bisque;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(586, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 30);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // addCustomerbtn
            // 
            this.addCustomerbtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.addCustomerbtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addCustomerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCustomerbtn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCustomerbtn.Image = ((System.Drawing.Image)(resources.GetObject("addCustomerbtn.Image")));
            this.addCustomerbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addCustomerbtn.Location = new System.Drawing.Point(1120, 11);
            this.addCustomerbtn.Name = "addCustomerbtn";
            this.addCustomerbtn.Size = new System.Drawing.Size(163, 43);
            this.addCustomerbtn.TabIndex = 5;
            this.addCustomerbtn.Text = "      Add customer";
            this.addCustomerbtn.UseVisualStyleBackColor = false;
            this.addCustomerbtn.Click += new System.EventHandler(this.addCustomerbtn_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "license_plate";
            this.Column2.HeaderText = "License Plate";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "username";
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "gender";
            this.Column4.HeaderText = "Gender";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "phone";
            this.Column5.HeaderText = "Phone";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "date_created";
            this.Column6.HeaderText = "Date Created";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "date_paycheck";
            this.Column7.HeaderText = "Date Paycheck";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "date_end";
            this.Column8.HeaderText = "Date End";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "month_ticket";
            this.Column9.HeaderText = "Month Ticket";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column10.HeaderText = "";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Text = "Edit";
            this.Column10.UseColumnTextForButtonValue = true;
            // 
            // Column11
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column11.HeaderText = "";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Text = "Delete";
            this.Column11.UseColumnTextForButtonValue = true;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1290, 452);
            this.Controls.Add(this.addCustomerbtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.findCustomertxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Customergridview);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Shown += new System.EventHandler(this.CustomerForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customergridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Button employeebtn;
        private System.Windows.Forms.Button customerbtn;
        private System.Windows.Forms.Button dashboardbtn;
        private System.Windows.Forms.Label namelb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView Customergridview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findCustomertxt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button addCustomerbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn Column10;
        private System.Windows.Forms.DataGridViewButtonColumn Column11;
    }
}