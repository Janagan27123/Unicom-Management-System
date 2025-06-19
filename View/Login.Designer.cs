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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lbl_password = new Label();
            btn_cancel = new Button();
            lbl_userid = new Label();
            btn_login = new Button();
            lbl_unicomtic = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(363, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(363, 216);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(263, 224);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(57, 15);
            lbl_password.TabIndex = 2;
            lbl_password.Text = "Password";
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(245, 316);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(75, 23);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_userid
            // 
            lbl_userid.AutoSize = true;
            lbl_userid.Location = new Point(263, 164);
            lbl_userid.Name = "lbl_userid";
            lbl_userid.Size = new Size(43, 15);
            lbl_userid.TabIndex = 1;
            lbl_userid.Text = "User Id";
            // 
            // btn_login
            // 
            btn_login.Location = new Point(448, 306);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(75, 23);
            btn_login.TabIndex = 6;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // lbl_unicomtic
            // 
            lbl_unicomtic.AutoSize = true;
            lbl_unicomtic.Location = new Point(72, 27);
            lbl_unicomtic.Name = "lbl_unicomtic";
            lbl_unicomtic.Size = new Size(75, 15);
            lbl_unicomtic.TabIndex = 0;
            lbl_unicomtic.Text = "UNICOM TIC";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(lbl_unicomtic);
            panel1.Controls.Add(btn_login);
            panel1.Controls.Add(lbl_userid);
            panel1.Controls.Add(btn_cancel);
            panel1.Controls.Add(lbl_password);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(-5, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(699, 476);
            panel1.TabIndex = 7;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 469);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label lbl_password;
        private Button btn_cancel;
        private Label lbl_userid;
        private Button btn_login;
        private Label lbl_unicomtic;
        private Panel panel1;
    }
}