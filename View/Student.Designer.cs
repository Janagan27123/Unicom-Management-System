namespace UnicomManagementSystem.View
{
    partial class Student
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
            lbl_id = new Label();
            lbl_name = new Label();
            lal_adress = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btn_delete = new Button();
            btn_update = new Button();
            btn_add = new Button();
            dataGridView1 = new DataGridView();
            lbl_role = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbl_id
            // 
            lbl_id.AutoSize = true;
            lbl_id.Location = new Point(69, 65);
            lbl_id.Name = "lbl_id";
            lbl_id.Size = new Size(17, 15);
            lbl_id.TabIndex = 0;
            lbl_id.Text = "Id";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(69, 102);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(39, 15);
            lbl_name.TabIndex = 1;
            lbl_name.Text = "Name";
            // 
            // lal_adress
            // 
            lal_adress.AutoSize = true;
            lal_adress.Location = new Point(263, 68);
            lal_adress.Name = "lal_adress";
            lal_adress.Size = new Size(42, 15);
            lal_adress.TabIndex = 2;
            lal_adress.Text = "Adress";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 96);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(323, 65);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 8;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(108, 174);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(75, 23);
            btn_delete.TabIndex = 11;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(323, 174);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(75, 23);
            btn_update.TabIndex = 12;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(596, 174);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(75, 23);
            btn_add.TabIndex = 13;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 260);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(714, 150);
            dataGridView1.TabIndex = 14;
            // 
            // lbl_role
            // 
            lbl_role.AutoSize = true;
            lbl_role.Location = new Point(461, 73);
            lbl_role.Name = "lbl_role";
            lbl_role.Size = new Size(30, 15);
            lbl_role.TabIndex = 15;
            lbl_role.Text = "Role";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Admin", "Student", "Lecture", "Staff" });
            comboBox1.Location = new Point(506, 65);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 16;
            // 
            // Student
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(lbl_role);
            Controls.Add(dataGridView1);
            Controls.Add(btn_add);
            Controls.Add(btn_update);
            Controls.Add(btn_delete);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lal_adress);
            Controls.Add(lbl_name);
            Controls.Add(lbl_id);
            Name = "Student";
            Text = "Student";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_id;
        private Label lbl_name;
        private Label lal_adress;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btn_delete;
        private Button btn_update;
        private Button btn_add;
        private DataGridView dataGridView1;
        private Label lbl_role;
        private ComboBox comboBox1;
    }
}