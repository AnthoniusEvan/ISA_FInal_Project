
namespace FlightReservationProject
{
    partial class BankAccountPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblException = new System.Windows.Forms.Label();
            this.btnSave = new FlightReservationProject.CustomBtn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpiredDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccNum = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pbOpen = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.line = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblException);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtExpiredDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAccNum);
            this.panel1.Controls.Add(this.line);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pbClose);
            this.panel1.Controls.Add(this.pbOpen);
            this.panel1.Controls.Add(this.txtCVV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 371);
            this.panel1.TabIndex = 0;
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.ForeColor = System.Drawing.Color.Red;
            this.lblException.Location = new System.Drawing.Point(12, 184);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(238, 17);
            this.lblException.TabIndex = 182;
            this.lblException.Text = "please enter a valid account number";
            this.lblException.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 20;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(307, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(169, 48);
            this.btnSave.TabIndex = 181;
            this.btnSave.Text = "SAVE/UPDATE";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(260, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 18);
            this.label4.TabIndex = 180;
            this.label4.Text = "CVV";
            // 
            // txtCVV
            // 
            this.txtCVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVV.Location = new System.Drawing.Point(263, 226);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.PasswordChar = '•';
            this.txtCVV.Size = new System.Drawing.Size(213, 34);
            this.txtCVV.TabIndex = 179;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 18);
            this.label3.TabIndex = 178;
            this.label3.Text = "Expired Date (MM/YY)";
            // 
            // txtExpiredDate
            // 
            this.txtExpiredDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpiredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpiredDate.Location = new System.Drawing.Point(15, 226);
            this.txtExpiredDate.Name = "txtExpiredDate";
            this.txtExpiredDate.Size = new System.Drawing.Size(198, 34);
            this.txtExpiredDate.TabIndex = 177;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 176;
            this.label2.Text = "Account Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 174;
            this.label1.Text = "Card Details";
            // 
            // txtAccNum
            // 
            this.txtAccNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccNum.Location = new System.Drawing.Point(15, 138);
            this.txtAccNum.Name = "txtAccNum";
            this.txtAccNum.Size = new System.Drawing.Size(461, 34);
            this.txtAccNum.TabIndex = 173;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 46);
            this.panel2.TabIndex = 175;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(148, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(223, 29);
            this.lblInfo.TabIndex = 171;
            this.lblInfo.Text = "Add Bank Account";
            // 
            // pbOpen
            // 
            this.pbOpen.Image = global::FlightReservationProject.Properties.Resources.open;
            this.pbOpen.Location = new System.Drawing.Point(446, 235);
            this.pbOpen.Name = "pbOpen";
            this.pbOpen.Size = new System.Drawing.Size(22, 19);
            this.pbOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOpen.TabIndex = 184;
            this.pbOpen.TabStop = false;
            this.pbOpen.Click += new System.EventHandler(this.pbOpen_Click);
            // 
            // pbClose
            // 
            this.pbClose.Image = global::FlightReservationProject.Properties.Resources.close;
            this.pbClose.Location = new System.Drawing.Point(446, 235);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(22, 19);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 183;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // line
            // 
            this.line.Image = global::FlightReservationProject.Properties.Resources.Asset_20;
            this.line.Location = new System.Drawing.Point(12, 93);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(241, 3);
            this.line.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.line.TabIndex = 172;
            this.line.TabStop = false;
            // 
            // BankAccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 371);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BankAccountPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankAccountPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccNum;
        private System.Windows.Forms.PictureBox line;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInfo;
        private CustomBtn btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpiredDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblException;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbOpen;
    }
}