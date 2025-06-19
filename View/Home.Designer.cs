namespace UnicomManagementSystem.View
{
    partial class Home
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
            lbl_role = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // lbl_unicomtic
            // 
            lbl_unicomtic.AutoSize = true;
            lbl_unicomtic.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_unicomtic.Location = new Point(305, 30);
            lbl_unicomtic.Name = "lbl_unicomtic";
            lbl_unicomtic.Size = new Size(158, 32);
            lbl_unicomtic.TabIndex = 0;
            lbl_unicomtic.Text = "UNICOM TIC";
            // 
            // lbl_role
            // 
            lbl_role.AutoSize = true;
            lbl_role.Location = new Point(269, 121);
            lbl_role.Name = "lbl_role";
            lbl_role.Size = new Size(30, 15);
            lbl_role.TabIndex = 1;
            lbl_role.Text = "Role";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(364, 118);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(lbl_role);
            Controls.Add(lbl_unicomtic);
            Name = "Home";
            Text = "Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_unicomtic;
        private Label lbl_role;
        private ComboBox comboBox1;
    }
}