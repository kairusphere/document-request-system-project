using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Cachero_Group___Document_Request_System_Project
{
    public static class DatabaseHelper
    {
        private static string DbFilePath
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string dbFolder = Path.Combine(baseDir, "Database");
                string dbPath = Path.Combine(dbFolder, "plmun_doc_request_system.db");

                if (!Directory.Exists(dbFolder))
                    Directory.CreateDirectory(dbFolder);

                if (!File.Exists(dbPath))
                    SQLiteConnection.CreateFile(dbPath);

                return dbPath;
            }
        }

        private static string ConnectionString
        {
            get { return $"Data Source={DbFilePath};Version=3;"; }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}