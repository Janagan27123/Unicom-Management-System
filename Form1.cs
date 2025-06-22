using UnicomManagementSystem.Data;
using UnicomManagementSystem.View;

namespace UnicomManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            try
            {
                // Create database tables
                Migration.CreateTable();
                
                // Seed default data
                DatabaseManager.SeedDefaultData();
                
                // Show login form
                var loginForm = new Login();
                loginForm.ShowDialog();
                
                // Close main form if login is cancelled
                if (loginForm.DialogResult != DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing application: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
