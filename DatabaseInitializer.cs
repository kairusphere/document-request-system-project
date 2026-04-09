using System.Data.SQLite;

namespace Cachero_Group___Document_Request_System_Project
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // User Table
                string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS users (
                    user_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL UNIQUE,
                    password TEXT NOT NULL,
                    role TEXT NOT NULL,
                    student_number TEXT,
                    full_name TEXT NOT NULL
                );";

                // Document Type
                string createDocumentTypesTable = @"
                CREATE TABLE IF NOT EXISTS document_types (
                    document_type_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    document_name TEXT NOT NULL UNIQUE,
                    price REAL NOT NULL
                );";

                // Document Requests
                string createRequestsTable = @"
                CREATE TABLE IF NOT EXISTS requests (
                    request_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    student_number TEXT NOT NULL,
                    student_name TEXT NOT NULL,
                    document_type TEXT NOT NULL,
                    purpose TEXT NOT NULL,
                    additional_notes TEXT,
                    copies INTEGER NOT NULL,
                    price_per_copy REAL NOT NULL,
                    total_amount REAL NOT NULL,
                    status TEXT NOT NULL,
                    date_requested TEXT NOT NULL
                );";

                // Request Status - Notification
                string createRequestStatusLogsTable = @"
                CREATE TABLE IF NOT EXISTS request_status_logs (
                    log_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    request_id INTEGER NOT NULL,
                    status TEXT NOT NULL,
                    log_message TEXT,
                    date_logged TEXT NOT NULL
                );";

                using (SQLiteCommand cmd = new SQLiteCommand(createUsersTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createDocumentTypesTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createRequestsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createRequestStatusLogsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                SeedDocumentTypes(conn);
                SeedUsers(conn);
            }
        }

        private static void SeedDocumentTypes(SQLiteConnection conn)
        {
            string insert = @"
            INSERT OR IGNORE INTO document_types (document_name, price) VALUES
            ('Certificate of Matriculation', 50),
            ('Certificate of Grades', 30),
            ('Certificate of Graduation', 50),
            ('Certificate of Good Moral Character', 30),
            ('Honorable Dismissal', 150),
            ('Permit to Transfer', 150),
            ('Transcript of Records', 120),
            ('True Copy of Grades', 100);";

            using (SQLiteCommand cmd = new SQLiteCommand(insert, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void SeedUsers(SQLiteConnection conn)
        {
            string insert = @"
            INSERT OR IGNORE INTO users (username, password, role, student_number, full_name) VALUES
            ('student1', '1234', 'student', '2024-0001', 'Juan Dela Cruz'),
            ('admin1', '1234', 'admin', NULL, 'Registrar Admin');";

            using (SQLiteCommand cmd = new SQLiteCommand(insert, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}