
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Utility
{
    public static class DbConnUtil
    {
        private static IConfiguration _configuration;

        static DbConnUtil()
        {
            LoadAppSettings();
        }

        private static void LoadAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _configuration.GetConnectionString("LocalConnectionString");
        }
    }
}


