using System.Data;
using LoggerConsoleApplication.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LoggerConsoleApplication.Logger
{
    public class DatabaseLogger : IDatabaseLogger
    {
        private readonly IConfiguration configuration;

        public DatabaseLogger(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void LogMessage(string message, LogType logType)
        {
            var connectionString = configuration.GetConnectionString("LoggerDbConnectionString");
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "INSERT INTO Log VALUES(@message, @type)"
            };
            command.Parameters.Add("@message", SqlDbType.NVarChar).Value = message;
            command.Parameters.Add("@type", SqlDbType.Int).Value = (int)logType;
            command.ExecuteNonQuery();
        }
    }
}
