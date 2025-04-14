using System.Data.SqlClient;


namespace Project.Common.Tools
{
    /// <summary>
    /// SQL Server veritabanını belirli bir klasöre yedekleyen yardımcı sınıftır.
    /// </summary>
    public static class DatabaseBackupHelper
    {
        /// <summary>
        /// SQL Server veritabanını belirtilen klasöre yedekler.
        /// </summary>
        /// <param name="connectionString">SQL bağlantı cümlesi</param>
        /// <param name="backupFolderPath">Hedef klasör yolu</param>
        /// <param name="databaseName">Yedeklenecek veritabanı adı</param>
        /// <returns>Oluşturulan yedek dosyasının tam yolu</returns>
        public static string CreateDatabaseBackup(string connectionString, string backupFolderPath, string databaseName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{databaseName}_{timestamp}.bak";
            string backupFilePath = Path.Combine(backupFolderPath, fileName);

            string backupCommand = $@"BACKUP DATABASE [{databaseName}] TO DISK = N'{backupFilePath}' WITH FORMAT, INIT, NAME = N'{databaseName}-Full Database Backup'";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new(backupCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return backupFilePath;
        }
    }
}
