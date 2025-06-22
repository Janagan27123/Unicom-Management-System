# Unicom Management System

A comprehensive Windows Forms application for managing educational institutions, built with C# .NET 8.0 and SQLite database.

## Features

- **User Authentication**: Secure login system with role-based access control
- **Student Management**: Add, edit, and manage student information
- **Course Management**: Manage courses and subjects
- **Exam Management**: Create and manage exams
- **Marks Management**: Record and track student marks
- **Timetable Management**: Schedule classes and manage room assignments
- **Role-Based Access**: Different permissions for Admin, Staff, Lecturer, and Student roles

## System Requirements

- Windows 10 or later
- .NET 8.0 Runtime
- SQLite (included in the project)

## Installation

1. Clone or download the project
2. Open the solution in Visual Studio 2022 or later
3. Restore NuGet packages
4. Build the solution
5. Run the application

## Default Login Credentials

- **Username**: admin
- **Password**: admin123
- **Role**: Admin

## Database Schema

The application uses SQLite database with the following tables:

- **Users**: User accounts and authentication
- **Students**: Student information
- **Courses**: Course details
- **Subjects**: Subject information linked to courses
- **Exams**: Exam details linked to subjects
- **Marks**: Student marks for exams
- **Rooms**: Classroom information
- **Timetables**: Class schedules

## Project Structure

```
Unicom-Management-System/
├── Controller/          # Business logic controllers
├── Data/               # Database management and migrations
├── Model/              # Data models
├── View/               # Windows Forms UI
├── Program.cs          # Application entry point
└── Form1.cs           # Main application form
```

## Key Components

### Controllers
- **LoginController**: Handles user authentication and user management
- **StudentController**: Manages student operations
- **CourseController**: Handles course-related operations
- **ExamController**: Manages exam operations
- **MarksController**: Handles marks and grading
- **TimetableController**: Manages class schedules

### Models
- **User**: User account information with role-based access
- **Student**: Student personal and academic information
- **Course**: Course details
- **Subject**: Subject information
- **Exam**: Exam details
- **Mark**: Student marks
- **Room**: Classroom information
- **Timetable**: Class schedule information

## User Roles and Permissions

### Admin
- Full access to all modules
- User management
- System configuration

### Staff
- Student management
- Course management
- Subject management

### Lecturer
- Exam management
- Marks management
- View timetables

### Student
- View personal information
- View marks
- View timetables

## Security Features

- Password hashing using BCrypt
- Role-based access control
- Input validation
- SQL injection prevention using parameterized queries

## Development Notes

- The application uses Windows Forms for the UI
- SQLite is used as the database for simplicity and portability
- BCrypt.Net-Next is used for password hashing
- The project follows a simple MVC pattern

## Building and Running

1. Ensure you have .NET 8.0 SDK installed
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Build the solution (Ctrl+Shift+B)
5. Run the application (F5)

## Troubleshooting

- If the database file is not created, ensure the application has write permissions in the execution directory
- If login fails, check that the default admin user was created during first run
- For build errors, ensure all NuGet packages are properly restored

## Future Enhancements

- Web-based interface
- Advanced reporting features
- Email notifications
- Mobile app integration
- Advanced search and filtering
- Data import/export functionality
- Backup and restore features

## License

This project is for educational purposes. Feel free to modify and extend as needed. 