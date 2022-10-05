namespace Demo_OTP
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
            this.components = new System.ComponentModel.Container();
            this.btLogin = new System.Windows.Forms.Button();
            this.btVerify = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbVerify = new System.Windows.Forms.TextBox();
            this.lbInformation = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(300, 152);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btVerify
            // 
            this.btVerify.Location = new System.Drawing.Point(300, 238);
            this.btVerify.Name = "btVerify";
            this.btVerify.Size = new System.Drawing.Size(75, 23);
            this.btVerify.TabIndex = 1;
            this.btVerify.Text = "Verify";
            this.btVerify.UseVisualStyleBackColor = true;
            this.btVerify.Click += new System.EventHandler(this.btVerify_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(73, 153);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(221, 22);
            this.tbLogin.TabIndex = 2;
            // 
            // tbVerify
            // 
            this.tbVerify.Location = new System.Drawing.Point(73, 239);
            this.tbVerify.Name = "tbVerify";
            this.tbVerify.Size = new System.Drawing.Size(221, 22);
            this.tbVerify.TabIndex = 3;
            this.tbVerify.TextChanged += new System.EventHandler(this.tbVerify_TextChanged);
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.Location = new System.Drawing.Point(70, 327);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(11, 16);
            this.lbInformation.TabIndex = 4;
            this.lbInformation.Text = "-";
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(417, 153);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(11, 16);
            this.lbTimer.TabIndex = 5;
            this.lbTimer.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 538);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.tbVerify);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btVerify);
            this.Controls.Add(this.btLogin);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btVerify;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbVerify;
        private System.Windows.Forms.Label lbInformation;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTimer;
    }
}

