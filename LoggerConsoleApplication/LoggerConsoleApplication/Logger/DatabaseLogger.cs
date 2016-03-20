using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.Logger
{
    public class DatabaseLogger : IDatabaseLogger
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["LoggerDbConnectionString"].ConnectionString;

        public void LogMessage(string message, LogType logType)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Insert into Log Values(@message, @type)"
                };
                command.Parameters.Add("@message", SqlDbType.NVarChar).Value = message;
                command.Parameters.Add("@type", SqlDbType.Int).Value = (int)logType;
                command.ExecuteNonQuery();
            }
        }
    }
}
