using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomManagementSystem.Model;
using BCrypt.Net;
using UnicomManagementSystem.Model;

namespace WinFormsApp_2025_06_02.Controllers
{
    public class UserController
    {
        private readonly string _connectionString;

        public UserController(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all users (without passwords)
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "SELECT Id, Name, Username, Role FROM Users";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString() ?? string.Empty,
                    Username = reader["Username"].ToString() ?? string.Empty,
                    Role = Enum.TryParse<UserRole>(reader["Role"].ToString(), out var role) ? role : UserRole.Student
                });
            }

            return users;
        }

        // Add new user with password hashing
        public User AddUser(User user, string plainPassword)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "INSERT INTO Users (Name, Username, Password, Role) VALUES (@Name, @Username, @Password, @Role); " +
                           "SELECT last_insert_rowid();";

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", hashedPassword);
            cmd.Parameters.AddWithValue("@Role", user.Role.ToString());

            user.Id = Convert.ToInt32(cmd.ExecuteScalar());
            user.PasswordHash = hashedPassword;

            return user;
        }

        // Verify credentials for login
        public bool Login(Credentials credentials)
        {
            try
            {
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string query = "SELECT Password FROM Users WHERE Username = @Username";

                using var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", credentials.Username);

                var storedHash = cmd.ExecuteScalar() as string;

                if (storedHash == null)
                    return false;

                return BCrypt.Net.BCrypt.Verify(credentials.Password, storedHash);
            }
            catch
            {
                return false;
            }
        }
    }
}
