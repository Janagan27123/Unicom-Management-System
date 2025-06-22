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

namespace UnicomManagementSystem.View
{
    public partial class UserManagement : Form
    {
        private AdminController _adminController;
        private List<User> _users;
        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Button btnDeleteUser;
        private Button btnChangePassword;
        private Button btnRefresh;

        public UserManagement()
        {
            InitializeComponent();
            InitializeUserManagementForm();
            _adminController = new AdminController("Data Source=management.db;Version=3;");
            LoadUsers();
        }

        private void InitializeUserManagementForm()
        {
            this.Text = "User Management - Admin Panel";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create DataGridView
            dgvUsers = new DataGridView();
            dgvUsers.Location = new Point(20, 20);
            dgvUsers.Size = new Size(750, 400);
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            this.Controls.Add(dgvUsers);

            // Create buttons
            btnAddUser = new Button();
            btnAddUser.Text = "Add New User";
            btnAddUser.Location = new Point(20, 440);
            btnAddUser.Size = new Size(120, 30);
            btnAddUser.Click += BtnAddUser_Click;
            this.Controls.Add(btnAddUser);

            btnDeleteUser = new Button();
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.Location = new Point(160, 440);
            btnDeleteUser.Size = new Size(120, 30);
            btnDeleteUser.Click += BtnDeleteUser_Click;
            this.Controls.Add(btnDeleteUser);

            btnChangePassword = new Button();
            btnChangePassword.Text = "Change Admin Password";
            btnChangePassword.Location = new Point(300, 440);
            btnChangePassword.Size = new Size(150, 30);
            btnChangePassword.Click += BtnChangePassword_Click;
            this.Controls.Add(btnChangePassword);

            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(470, 440);
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Click += BtnRefresh_Click;
            this.Controls.Add(btnRefresh);
        }

        private void LoadUsers()
        {
            try
            {
                _users = _adminController.GetAllUsers();
                
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _users;
                
                // Configure columns
                dgvUsers.Columns["Id"].HeaderText = "User ID";
                dgvUsers.Columns["Id"].Width = 80;
                dgvUsers.Columns["Username"].HeaderText = "Username";
                dgvUsers.Columns["Username"].Width = 150;
                dgvUsers.Columns["Role"].HeaderText = "Role";
                dgvUsers.Columns["Role"].Width = 100;
                
                // Hide password-related columns
                if (dgvUsers.Columns.Contains("PasswordHash"))
                    dgvUsers.Columns["PasswordHash"].Visible = false;
                if (dgvUsers.Columns.Contains("Name"))
                    dgvUsers.Columns["Name"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addUserForm = new Form())
                {
                    addUserForm.Text = "Add New User";
                    addUserForm.Size = new Size(400, 300);
                    addUserForm.StartPosition = FormStartPosition.CenterParent;
                    addUserForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    addUserForm.MaximizeBox = false;
                    addUserForm.MinimizeBox = false;

                    // Username
                    var lblUsername = new Label { Text = "Username:", Location = new Point(20, 20), Size = new Size(80, 20) };
                    var txtUsername = new TextBox { Location = new Point(120, 20), Size = new Size(200, 20) };
                    addUserForm.Controls.AddRange(new Control[] { lblUsername, txtUsername });

                    // Password
                    var lblPassword = new Label { Text = "Password:", Location = new Point(20, 50), Size = new Size(80, 20) };
                    var txtPassword = new TextBox { Location = new Point(120, 50), Size = new Size(200, 20), PasswordChar = '*' };
                    addUserForm.Controls.AddRange(new Control[] { lblPassword, txtPassword });

                    // Role
                    var lblRole = new Label { Text = "Role:", Location = new Point(20, 80), Size = new Size(80, 20) };
                    var cboRole = new ComboBox { Location = new Point(120, 80), Size = new Size(200, 20) };
                    cboRole.Items.AddRange(Enum.GetValues<UserRole>().Select(r => r.ToString()).ToArray());
                    cboRole.SelectedIndex = 0;
                    addUserForm.Controls.AddRange(new Control[] { lblRole, cboRole });

                    // Buttons
                    var btnSave = new Button { Text = "Save", Location = new Point(120, 120), Size = new Size(80, 30) };
                    var btnCancel = new Button { Text = "Cancel", Location = new Point(220, 120), Size = new Size(80, 30) };
                    addUserForm.Controls.AddRange(new Control[] { btnSave, btnCancel });

                    btnSave.Click += (s, args) =>
                    {
                        if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            MessageBox.Show("Please enter both username and password.", "Validation Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (Enum.TryParse<UserRole>(cboRole.Text, out var role))
                        {
                            bool success = _adminController.CreateUser(txtUsername.Text.Trim(), txtPassword.Text, role);
                            if (success)
                            {
                                MessageBox.Show("User created successfully!", "Success", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUsers();
                                addUserForm.Close();
                            }
                        }
                    };

                    btnCancel.Click += (s, args) => addUserForm.Close();

                    addUserForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a user to delete.", "Selection Required", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;
                if (selectedUser == null) return;

                if (selectedUser.Username == "admin")
                {
                    MessageBox.Show("Cannot delete the admin user.", "Protected User", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = _adminController.DeleteUser(selectedUser.Id);
                    if (success)
                    {
                        MessageBox.Show("User deleted successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                using (var passwordForm = new Form())
                {
                    passwordForm.Text = "Change Admin Password";
                    passwordForm.Size = new Size(400, 200);
                    passwordForm.StartPosition = FormStartPosition.CenterParent;
                    passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    passwordForm.MaximizeBox = false;
                    passwordForm.MinimizeBox = false;

                    // New Password
                    var lblNewPassword = new Label { Text = "New Password:", Location = new Point(20, 20), Size = new Size(100, 20) };
                    var txtNewPassword = new TextBox { Location = new Point(130, 20), Size = new Size(200, 20), PasswordChar = '*' };
                    passwordForm.Controls.AddRange(new Control[] { lblNewPassword, txtNewPassword });

                    // Confirm Password
                    var lblConfirmPassword = new Label { Text = "Confirm Password:", Location = new Point(20, 50), Size = new Size(100, 20) };
                    var txtConfirmPassword = new TextBox { Location = new Point(130, 50), Size = new Size(200, 20), PasswordChar = '*' };
                    passwordForm.Controls.AddRange(new Control[] { lblConfirmPassword, txtConfirmPassword });

                    // Buttons
                    var btnSave = new Button { Text = "Save", Location = new Point(130, 90), Size = new Size(80, 30) };
                    var btnCancel = new Button { Text = "Cancel", Location = new Point(230, 90), Size = new Size(80, 30) };
                    passwordForm.Controls.AddRange(new Control[] { btnSave, btnCancel });

                    btnSave.Click += (s, args) =>
                    {
                        if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                        {
                            MessageBox.Show("Please enter a new password.", "Validation Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (txtNewPassword.Text != txtConfirmPassword.Text)
                        {
                            MessageBox.Show("Passwords do not match.", "Validation Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        bool success = _adminController.ChangeAdminPassword(txtNewPassword.Text);
                        if (success)
                        {
                            MessageBox.Show("Admin password changed successfully!", "Success", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            passwordForm.Close();
                        }
                    };

                    btnCancel.Click += (s, args) => passwordForm.Close();

                    passwordForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
} 