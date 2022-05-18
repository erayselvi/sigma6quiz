
namespace sigma6_project
{
    partial class RegisterPage
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
            this.Username_TB = new System.Windows.Forms.TextBox();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.PasswordR_TB = new System.Windows.Forms.TextBox();
            this.Name_TB = new System.Windows.Forms.TextBox();
            this.Surname_TB = new System.Windows.Forms.TextBox();
            this.Mail_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Register_BT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Username_TB
            // 
            this.Username_TB.Location = new System.Drawing.Point(184, 12);
            this.Username_TB.Name = "Username_TB";
            this.Username_TB.Size = new System.Drawing.Size(125, 27);
            this.Username_TB.TabIndex = 0;
            // 
            // Password_TB
            // 
            this.Password_TB.Location = new System.Drawing.Point(184, 45);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(125, 27);
            this.Password_TB.TabIndex = 0;
            // 
            // PasswordR_TB
            // 
            this.PasswordR_TB.Location = new System.Drawing.Point(184, 78);
            this.PasswordR_TB.Name = "PasswordR_TB";
            this.PasswordR_TB.Size = new System.Drawing.Size(125, 27);
            this.PasswordR_TB.TabIndex = 0;
            // 
            // Name_TB
            // 
            this.Name_TB.Location = new System.Drawing.Point(184, 111);
            this.Name_TB.Name = "Name_TB";
            this.Name_TB.Size = new System.Drawing.Size(125, 27);
            this.Name_TB.TabIndex = 0;
            // 
            // Surname_TB
            // 
            this.Surname_TB.Location = new System.Drawing.Point(184, 144);
            this.Surname_TB.Name = "Surname_TB";
            this.Surname_TB.Size = new System.Drawing.Size(125, 27);
            this.Surname_TB.TabIndex = 0;
            // 
            // Mail_TB
            // 
            this.Mail_TB.Location = new System.Drawing.Point(184, 177);
            this.Mail_TB.Name = "Mail_TB";
            this.Mail_TB.Size = new System.Drawing.Size(125, 27);
            this.Mail_TB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password(Rety)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Surname";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mail";
            // 
            // Register_BT
            // 
            this.Register_BT.Location = new System.Drawing.Point(65, 218);
            this.Register_BT.Name = "Register_BT";
            this.Register_BT.Size = new System.Drawing.Size(244, 29);
            this.Register_BT.TabIndex = 2;
            this.Register_BT.Text = "Register";
            this.Register_BT.UseVisualStyleBackColor = true;
            this.Register_BT.Click += new System.EventHandler(this.Register_BT_Click);
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Register_BT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mail_TB);
            this.Controls.Add(this.Surname_TB);
            this.Controls.Add(this.Name_TB);
            this.Controls.Add(this.PasswordR_TB);
            this.Controls.Add(this.Password_TB);
            this.Controls.Add(this.Username_TB);
            this.Name = "RegisterPage";
            this.Text = "RegisterPage";
            this.Load += new System.EventHandler(this.RegisterPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username_TB;
        private System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.TextBox PasswordR_TB;
        private System.Windows.Forms.TextBox Name_TB;
        private System.Windows.Forms.TextBox Surname_TB;
        private System.Windows.Forms.TextBox Mail_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Register_BT;
    }
}