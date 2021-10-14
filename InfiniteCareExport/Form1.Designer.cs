namespace CreateBridgeCourses
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtSubID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.txtSubURL = new System.Windows.Forms.TextBox();
            this.lblSubURL = new System.Windows.Forms.Label();
            this.pnlCreateSubAccount = new System.Windows.Forms.Panel();
            this.btnExportEnrollments = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlCreateSubAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Account Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Domain Name:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(186, 69);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(676, 26);
            this.txtAccountName.TabIndex = 4;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(186, 3);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(274, 26);
            this.txtDomain.TabIndex = 1;
            this.txtDomain.Leave += new System.EventHandler(this.txtDomain_Leave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtSubID
            // 
            this.txtSubID.Location = new System.Drawing.Point(588, 3);
            this.txtSubID.Name = "txtSubID";
            this.txtSubID.Size = new System.Drawing.Size(274, 26);
            this.txtSubID.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Sub ID:";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // txtSubURL
            // 
            this.txtSubURL.Location = new System.Drawing.Point(186, 36);
            this.txtSubURL.Name = "txtSubURL";
            this.txtSubURL.Size = new System.Drawing.Size(676, 26);
            this.txtSubURL.TabIndex = 3;
            this.txtSubURL.Leave += new System.EventHandler(this.txtSubURL_Leave);
            // 
            // lblSubURL
            // 
            this.lblSubURL.AutoSize = true;
            this.lblSubURL.Location = new System.Drawing.Point(21, 45);
            this.lblSubURL.Name = "lblSubURL";
            this.lblSubURL.Size = new System.Drawing.Size(138, 20);
            this.lblSubURL.TabIndex = 57;
            this.lblSubURL.Text = "SubAccount URL:";
            // 
            // pnlCreateSubAccount
            // 
            this.pnlCreateSubAccount.Controls.Add(this.btnExportEnrollments);
            this.pnlCreateSubAccount.Controls.Add(this.label5);
            this.pnlCreateSubAccount.Controls.Add(this.label3);
            this.pnlCreateSubAccount.Controls.Add(this.txtEnd);
            this.pnlCreateSubAccount.Controls.Add(this.txtStart);
            this.pnlCreateSubAccount.Controls.Add(this.btnExport);
            this.pnlCreateSubAccount.Controls.Add(this.lblSubURL);
            this.pnlCreateSubAccount.Controls.Add(this.txtSubURL);
            this.pnlCreateSubAccount.Controls.Add(this.label4);
            this.pnlCreateSubAccount.Controls.Add(this.txtSubID);
            this.pnlCreateSubAccount.Controls.Add(this.label2);
            this.pnlCreateSubAccount.Controls.Add(this.label1);
            this.pnlCreateSubAccount.Controls.Add(this.txtAccountName);
            this.pnlCreateSubAccount.Controls.Add(this.txtDomain);
            this.pnlCreateSubAccount.Location = new System.Drawing.Point(15, 9);
            this.pnlCreateSubAccount.Name = "pnlCreateSubAccount";
            this.pnlCreateSubAccount.Size = new System.Drawing.Size(1098, 158);
            this.pnlCreateSubAccount.TabIndex = 60;
            // 
            // btnExportEnrollments
            // 
            this.btnExportEnrollments.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnExportEnrollments.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportEnrollments.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportEnrollments.Location = new System.Drawing.Point(924, 69);
            this.btnExportEnrollments.Name = "btnExportEnrollments";
            this.btnExportEnrollments.Size = new System.Drawing.Size(171, 36);
            this.btnExportEnrollments.TabIndex = 70;
            this.btnExportEnrollments.Text = "Learnables";
            this.btnExportEnrollments.UseVisualStyleBackColor = false;
            this.btnExportEnrollments.Click += new System.EventHandler(this.btnExportEnrollments_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(466, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "Completed Before:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 68;
            this.label3.Text = "Completed After:";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(614, 110);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(248, 26);
            this.txtEnd.TabIndex = 67;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(188, 110);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(271, 26);
            this.txtStart.TabIndex = 66;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExport.Location = new System.Drawing.Point(924, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(171, 36);
            this.btnExport.TabIndex = 65;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 183);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1081, 340);
            this.richTextBox1.TabIndex = 61;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1125, 561);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pnlCreateSubAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Armighorn Export";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCreateSubAccount.ResumeLayout(false);
            this.pnlCreateSubAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtSubID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox txtSubURL;
        private System.Windows.Forms.Label lblSubURL;
        private System.Windows.Forms.Panel pnlCreateSubAccount;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Button btnExportEnrollments;
    }
}

