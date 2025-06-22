using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomManagementSystem.Model;

namespace UnicomManagementSystem.View
{
    public partial class Dashboard : Form
    {
        private UserRole _currentUserRole;
        private string _currentUsername;

        public Dashboard(UserRole userRole, string username)
        {
            InitializeComponent();
            _currentUserRole = userRole;
            _currentUsername = username;
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            this.Text = $"Unicom Management System - Dashboard ({_currentUserRole})";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Create main menu
            var mainMenu = new MenuStrip();
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);

            // File Menu
            var fileMenu = new ToolStripMenuItem("File");
            var exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += (s, e) => Application.Exit();
            fileMenu.DropDownItems.Add(exitItem);
            mainMenu.Items.Add(fileMenu);

            // Management Menu
            var managementMenu = new ToolStripMenuItem("Management");
            
            // Add menu items based on user role
            if (_currentUserRole == UserRole.Admin || _currentUserRole == UserRole.Staff)
            {
                var studentsItem = new ToolStripMenuItem("Students");
                studentsItem.Click += (s, e) => OpenStudentsForm();
                managementMenu.DropDownItems.Add(studentsItem);

                var coursesItem = new ToolStripMenuItem("Courses");
                coursesItem.Click += (s, e) => OpenCoursesForm();
                managementMenu.DropDownItems.Add(coursesItem);

                var subjectsItem = new ToolStripMenuItem("Subjects");
                subjectsItem.Click += (s, e) => OpenSubjectsForm();
                managementMenu.DropDownItems.Add(subjectsItem);
            }

            if (_currentUserRole == UserRole.Admin || _currentUserRole == UserRole.Lecturer)
            {
                var examsItem = new ToolStripMenuItem("Exams");
                examsItem.Click += (s, e) => OpenExamsForm();
                managementMenu.DropDownItems.Add(examsItem);

                var marksItem = new ToolStripMenuItem("Marks");
                marksItem.Click += (s, e) => OpenMarksForm();
                managementMenu.DropDownItems.Add(marksItem);
            }

            if (_currentUserRole == UserRole.Admin)
            {
                var timetableItem = new ToolStripMenuItem("Timetable");
                timetableItem.Click += (s, e) => OpenTimetableForm();
                managementMenu.DropDownItems.Add(timetableItem);

                var usersItem = new ToolStripMenuItem("Users");
                usersItem.Click += (s, e) => OpenUsersForm();
                managementMenu.DropDownItems.Add(usersItem);
            }

            mainMenu.Items.Add(managementMenu);

            // Reports Menu
            var reportsMenu = new ToolStripMenuItem("Reports");
            var studentReportItem = new ToolStripMenuItem("Student Report");
            studentReportItem.Click += (s, e) => ShowStudentReport();
            reportsMenu.DropDownItems.Add(studentReportItem);
            mainMenu.Items.Add(reportsMenu);

            // Help Menu
            var helpMenu = new ToolStripMenuItem("Help");
            var aboutItem = new ToolStripMenuItem("About");
            aboutItem.Click += (s, e) => ShowAboutDialog();
            helpMenu.DropDownItems.Add(aboutItem);
            mainMenu.Items.Add(helpMenu);

            // Create welcome panel
            var welcomePanel = new Panel();
            welcomePanel.Dock = DockStyle.Fill;
            welcomePanel.BackColor = Color.LightBlue;

            var welcomeLabel = new Label();
            welcomeLabel.Text = $"Welcome to Unicom Management System\n\nLogged in as: {_currentUsername}\nRole: {_currentUserRole}\n\nPlease select an option from the menu above.";
            welcomeLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.Dock = DockStyle.Fill;
            welcomeLabel.AutoSize = false;

            welcomePanel.Controls.Add(welcomeLabel);
            this.Controls.Add(welcomePanel);
        }

        private void OpenStudentsForm()
        {
            MessageBox.Show("Students form will be opened here.", "Students", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Students form
        }

        private void OpenCoursesForm()
        {
            MessageBox.Show("Courses form will be opened here.", "Courses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Courses form
        }

        private void OpenSubjectsForm()
        {
            MessageBox.Show("Subjects form will be opened here.", "Subjects", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Subjects form
        }

        private void OpenExamsForm()
        {
            MessageBox.Show("Exams form will be opened here.", "Exams", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Exams form
        }

        private void OpenMarksForm()
        {
            MessageBox.Show("Marks form will be opened here.", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Marks form
        }

        private void OpenTimetableForm()
        {
            MessageBox.Show("Timetable form will be opened here.", "Timetable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement Timetable form
        }

        private void OpenUsersForm()
        {
            try
            {
                var userManagementForm = new UserManagement();
                userManagementForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening user management: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowStudentReport()
        {
            MessageBox.Show("Student report will be generated here.", "Student Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implement report generation
        }

        private void ShowAboutDialog()
        {
            MessageBox.Show("Unicom Management System\nVersion 1.0\n\nA comprehensive school management system.", 
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
