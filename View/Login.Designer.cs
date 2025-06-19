namespace UnicomManagementSystem.View
{
    partial class Login
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
            lbl_unicomtic = new Label();
            lbl_userid = new Label();
            lbl_password = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btn_cancel = new Button();
            btn_login = new Button();
            SuspendLayout();
            // 
            // lbl_unicomtic
            // 
            lbl_unicomtic.AutoSize = true;
            lbl_unicomtic.Location = new Point(335, 24);
            lbl_unicomtic.Name = "lbl_unicomtic";
            lbl_unicomtic.Size = new Size(76, 15);
            lbl_unicomtic.TabIndex = 0;
            lbl_unicomtic.Text = "UNICOM TIC";
            // 
            // lbl_userid
            // 
            lbl_userid.AutoSize = true;
            lbl_userid.Location = new Point(245, 106);
            lbl_userid.Name = "lbl_userid";
            lbl_userid.Size = new Size(43, 15);
            lbl_userid.TabIndex = 1;
            lbl_userid.Text = "User Id";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(245, 152);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(57, 15);
            lbl_password.TabIndex = 2;
            lbl_password.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(335, 98);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(335, 144);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(191, 241);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(75, 23);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(477, 241);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(75, 23);
            btn_login.TabIndex = 6;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_login);
            Controls.Add(btn_cancel);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lbl_password);
            Controls.Add(lbl_userid);
            Controls.Add(lbl_unicomtic);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_unicomtic;
        private Label lbl_userid;
        private Label lbl_password;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btn_cancel;
        private Button btn_login;
    }
}