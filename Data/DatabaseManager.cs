using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManagementSystem.Controller;
using UnicomManagementSystem.Model;

namespace UnicomManagementSystem.Data
{
    //using System.Data.SQLite;

    public static class DatabaseManager
    {
        private static string connectionString = "Data Source=management.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void SeedDefaultData()
        {
            try
            {
                var adminController = new AdminController(connectionString);
                
                // Create default admin user using AdminController
                bool adminCreated = adminController.CreateDefaultAdmin();
                
                if (adminCreated)
                {
                    var adminUser = adminController.GetAdminUser();
                    if (adminUser != null)
                    {
                        Console.WriteLine($"Admin user ready - ID: {adminUser.Id}, Username: {adminUser.Username}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding default data: {ex.Message}");
            }
        }
    }

}
