# Admin User Management Guide

## Admin User ID மற்றும் Password Storage System

### 1. Admin User Creation Process

**Database Table Structure:**
```sql
CREATE TABLE Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-generated unique ID
    Username TEXT NOT NULL,                -- Username for login
    Password TEXT NOT NULL,                -- Hashed password (BCrypt)
    Role TEXT NOT NULL                     -- User role (Admin, Staff, Lecturer, Student)
);
```

### 2. Default Admin User Setup

**Automatic Creation:**
- Application starts → Database tables created → Default admin user created
- **Default Credentials:**
  - Username: `admin`
  - Password: `admin123`
  - Role: `Admin`
  - ID: Auto-generated (usually 1)

**Code Location:** `Data/DatabaseManager.cs` → `SeedDefaultData()` method

### 3. Password Security (BCrypt Hashing)

**Password Storage Process:**
```csharp
// 1. User enters password
string plainPassword = "admin123";

// 2. Password is hashed using BCrypt
string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

// 3. Only hashed password is stored in database
// Original password is never stored!
```

**Password Verification Process:**
```csharp
// 1. User enters password during login
string enteredPassword = "admin123";

// 2. Get stored hash from database
string storedHash = "hashed_password_from_database";

// 3. Verify password against hash
bool isValid = BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
```

### 4. Admin User Management Features

#### A. View All Users
- **Location:** Dashboard → Management → Users
- **Shows:** User ID, Username, Role
- **Security:** Passwords are never displayed

#### B. Add New Users
- **Process:**
  1. Enter username and password
  2. Select role (Admin, Staff, Lecturer, Student)
  3. Password is automatically hashed
  4. User ID is auto-generated
  5. User is added to database

#### C. Change Admin Password
- **Security:** Only admin can change admin password
- **Process:**
  1. Enter new password
  2. Confirm new password
  3. Old password is replaced with new hashed password
  4. Old password is permanently lost

#### D. Delete Users
- **Protection:** Admin user cannot be deleted
- **Process:** Select user → Confirm deletion → User removed from database

### 5. User ID System

**Auto-Generated IDs:**
- Database uses `AUTOINCREMENT` for User IDs
- First admin user typically gets ID = 1
- Each new user gets next available ID
- IDs are never reused (even if user is deleted)

**ID Usage:**
- User ID is used as foreign key in other tables
- Student records link to User ID
- Marks records link to Student ID (which links to User ID)

### 6. Security Features

#### Password Security:
- ✅ Passwords are hashed using BCrypt
- ✅ Original passwords are never stored
- ✅ Hash includes salt for additional security
- ✅ Each password hash is unique (even for same password)

#### Access Control:
- ✅ Role-based permissions
- ✅ Admin has full access
- ✅ Other roles have limited access
- ✅ Login required for all operations

#### Data Protection:
- ✅ SQL injection prevention (parameterized queries)
- ✅ Input validation
- ✅ Error handling without exposing sensitive data

### 7. Database Schema Relationships

```
Users (ID, Username, Password, Role)
    ↓ (User ID)
Students (ID, Name, Address, NIC, CourseId)
    ↓ (Student ID)
Marks (ID, StudentId, ExamId, MarksValue)
```

### 8. Admin User Operations

#### Login Process:
1. User enters username/password
2. System looks up user by username
3. System verifies password against stored hash
4. If valid, user role is retrieved
5. Dashboard opens with appropriate permissions

#### User Management:
1. Admin logs in
2. Navigates to Users menu
3. Can view, add, delete users
4. Can change admin password
5. All changes are immediately saved to database

### 9. Troubleshooting

#### Common Issues:

**Q: Admin password forgotten?**
A: Delete the database file and restart application - new admin user will be created with default credentials

**Q: Cannot login as admin?**
A: Check if database file exists and has proper permissions

**Q: User management not working?**
A: Ensure you're logged in as admin user

**Q: Database errors?**
A: Check if SQLite is properly installed and database file is writable

### 10. Best Practices

#### For Administrators:
- ✅ Change default admin password immediately
- ✅ Use strong passwords
- ✅ Regularly backup database
- ✅ Monitor user activities
- ✅ Delete unused user accounts

#### For Developers:
- ✅ Never log or display passwords
- ✅ Always use parameterized queries
- ✅ Validate all user inputs
- ✅ Handle exceptions gracefully
- ✅ Use proper error messages

### 11. Code Examples

#### Creating Admin User:
```csharp
var adminController = new AdminController(connectionString);
bool success = adminController.CreateDefaultAdmin();
```

#### Changing Admin Password:
```csharp
var adminController = new AdminController(connectionString);
bool success = adminController.ChangeAdminPassword("newPassword123");
```

#### Getting Admin User Info:
```csharp
var adminController = new AdminController(connectionString);
var adminUser = adminController.GetAdminUser();
Console.WriteLine($"Admin ID: {adminUser.Id}, Username: {adminUser.Username}");
```

This system ensures that admin user IDs and passwords are stored securely and managed properly throughout the application. 