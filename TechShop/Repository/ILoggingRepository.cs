using System;
using System.IO;

namespace TechShop.Repository
{
    public class ILoggingRepository
    {
        public void LogError(string message)
        {
            try
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
