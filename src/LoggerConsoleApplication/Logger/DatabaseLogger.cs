using System.Data;
using LoggerConsoleApplication.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LoggerConsoleApplication.Logger;

public class DatabaseLogger(IConfiguration configuration) : IDatabaseLogger
{
    public void LogMessage(string message, LogType logType)
    {
        var connectionString = configuration["ConnectionStrings:LoggerDbConnectionString"];
        using var connection = new SqlConnection(connectionString);

        using var command = new SqlCommand
        {
            Connection = connection,
            CommandTimeout = 1,
            CommandText = "INSERT INTO Log VALUES(@message, @type)"
        };
        command.Parameters.Add("@message", SqlDbType.NVarChar).Value = message;
        command.Parameters.Add("@type", SqlDbType.Int).Value = (int)logType;

        connection.Open();
        command.ExecuteNonQuery();
    }
}
