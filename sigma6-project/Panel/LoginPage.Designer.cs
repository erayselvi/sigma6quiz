
namespace sigma6_project
{
    partial class LoginPage
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
            this.username_TB = new System.Windows.Forms.TextBox();
            this.password_TB = new System.Windows.Forms.TextBox();
            this.login_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.register_B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username_TB
            // 
            this.username_TB.Location = new System.Drawing.Point(110, 12);
            this.username_TB.Name = "username_TB";
            this.username_TB.Size = new System.Drawing.Size(125, 27);
            this.username_TB.TabIndex = 0;
            // 
            // password_TB
            // 
            this.password_TB.Location = new System.Drawing.Point(110, 64);
            this.password_TB.Name = "password_TB";
            this.password_TB.Size = new System.Drawing.Size(125, 27);
            this.password_TB.TabIndex = 0;
            // 
            // login_B
            // 
            this.login_B.Location = new System.Drawing.Point(110, 97);
            this.login_B.Name = "login_B";
            this.login_B.Size = new System.Drawing.Size(125, 29);
            this.login_B.TabIndex = 1;
            this.login_B.Text = "Login";
            this.login_B.UseVisualStyleBackColor = true;
            this.login_B.Click += new System.EventHandler(this.login_B_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // register_B
            // 
            this.register_B.Location = new System.Drawing.Point(110, 132);
            this.register_B.Name = "register_B";
            this.register_B.Size = new System.Drawing.Size(125, 29);
            this.register_B.TabIndex = 1;
            this.register_B.Text = "Register";
            this.register_B.UseVisualStyleBackColor = true;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.register_B);
            this.Controls.Add(this.login_B);
            this.Controls.Add(this.password_TB);
            this.Controls.Add(this.username_TB);
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_TB;
        private System.Windows.Forms.TextBox password_TB;
        private System.Windows.Forms.Button login_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button register_B;
    }
}