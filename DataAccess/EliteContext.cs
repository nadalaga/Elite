using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace DataAccess
{
    public class EliteContext : DbContext
    {

        /// <summary>
        /// Manipulate the Users table
        /// </summary>
        /// <value>The property that allows to access the Users table</value>
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        private const string databaseName = "elite.db";

        protected string DatabasePath { get; set; }


        public EliteContext(string databasePath)
        {
            DatabasePath = databasePath;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(DatabasePath))
            {
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    SQLitePCL.Batteries_V2.Init();
                    DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName);
                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {

                    DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                }
                else
                {
                    throw new NotImplementedException("Platform not supported");
                }
            }

            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

    }
}
