using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManagementSystem.Model;

namespace UnicomManagementSystem.Controller
{
    public class MarksController
    {
        private readonly string _connectionString;

        public MarksController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT * FROM Marks";
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            ExamId = Convert.ToInt32(reader["ExamId"]),
                            Marksvalue = Convert.ToInt32(reader["Score"])
                        });
                    }
                }
            }

            return marks;
        }

        public Mark GetMarkById(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT * FROM Marks WHERE Id = @Id";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Mark
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            ExamId = Convert.ToInt32(reader["ExamId"]),
                            Marksvalue = Convert.ToInt32(reader["Score"])
                        };
                    }
                }
            }
            return null;
        }

        public bool AddMark(Mark mark)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "INSERT INTO Marks (StudentId, ExamId, Score) VALUES (@StudentId, @ExamId, @Score)";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                cmd.Parameters.AddWithValue("@ExamId", mark.ExamId);
                cmd.Parameters.AddWithValue("@Score", mark.Marksvalue);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateMark(Mark mark)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "UPDATE Marks SET StudentId = @StudentId, ExamId = @ExamId, Score = @Score WHERE Id = @Id";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                cmd.Parameters.AddWithValue("@ExamId", mark.ExamId);
                cmd.Parameters.AddWithValue("@Score", mark.Marksvalue);
                cmd.Parameters.AddWithValue("@Id", mark.Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMark(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "DELETE FROM Marks WHERE Id = @Id";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

}
