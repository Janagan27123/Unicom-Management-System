using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomManagementSystem.Controller;
using UnicomManagementSystem.Model;
using UnicomManagementSystem.Data;

namespace UnicomManagementSystem.View
{
    public partial class Login : Form
    {
        private LoginController _loginController;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblUsername;
        private Label lblPassword;

        public Login()
        {
            InitializeComponent();
            InitializeLoginForm();
            _loginController = new LoginController("Data Source=management.db;Version=3;");
        }

        private void InitializeLoginForm()
        {
            this.Text = "Unicom Management System - Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Username Label
            lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(50, 50);
            lblUsername.Size = new Size(80, 20);
            this.Controls.Add(lblUsername);

            // Username TextBox
            txtUsername = new TextBox();
            txtUsername.Location = new Point(150, 50);
            txtUsername.Size = new Size(200, 20);
            this.Controls.Add(txtUsername);

            // Password Label
            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(50, 90);
            lblPassword.Size = new Size(80, 20);
            this.Controls.Add(lblPassword);

            // Password TextBox
            txtPassword = new TextBox();
            txtPassword.Location = new Point(150, 90);
            txtPassword.Size = new Size(200, 20);
            txtPassword.PasswordChar = '*';
            this.Controls.Add(txtPassword);

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(150, 130);
            btnLogin.Size = new Size(80, 30);
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            // Cancel Button
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(250, 130);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);

            // Set default button
            this.AcceptButton = btnLogin;
            this.CancelButton = btnCancel;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var credentials = new Credentials
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                if (_loginController.Login(credentials))
                {
                    var userRole = _loginController.GetUserRole(credentials.Username);
                    if (userRole.HasValue)
                    {
                        MessageBox.Show($"Welcome! You are logged in as {userRole.Value}.", "Login Successful", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Open dashboard
                        var dashboard = new Dashboard(userRole.Value, credentials.Username);
                        this.Hide();
                        dashboard.ShowDialog();
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
