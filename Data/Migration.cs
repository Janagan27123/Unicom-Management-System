using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManagementSystem.Data
{
    internal static class Migration
    {
        public static void CreateTable()
        {
            using(var getDbconn = DatabaseManager.GetConnection())
            {
                
                
                string Createtable= @"
                CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL
                );

                CREATE TABLE Courses (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CourseName TEXT NOT NULL,               
                );

                CREATE TABLE Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                adress TEXT NOT NULL,
                nic INTEGER NOT NULL,
                CourseId INTEGER,
                FOREIGN KEY (CourseId) REFERENCES Courses(Id)
                );

                CREATE TABLE Subjects (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                CourseId INTEGER,
                FOREIGN KEY (CourseId) REFERENCES Courses(Id)
                );

                CREATE TABLE Exams (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ExamName TEXT NOT NULL,
                Date TEXT,
                SubjectId INTEGER,
                FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                );

                CREATE TABLE Marks (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StudentId INTEGER,
                ExamId INTEGER,
                Marksvalue INTEGER,
                FOREIGN KEY (StudentId) REFERENCES Students(Id),
                FOREIGN KEY (ExamId) REFERENCES Exams(Id)
                );

                CREATE TABLE Rooms (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                RoomNumber TEXT NOT NULL,
                Capacity INTEGER
                );

                CREATE TABLE Timetables (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                SubjectId INTEGER,
                RoomId INTEGER,
                Day TEXT,
                StartTime TEXT,
                EndTime TEXT,
                FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
                FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
                );
                ";
                SQLiteCommand cmd = new SQLiteCommand (Createtable, getDbconn);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}
