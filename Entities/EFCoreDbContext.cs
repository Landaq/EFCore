using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace EFCoreCodeFirstDemo.Entities
{
    internal class EFCoreDbContext : DbContext
    {
        // Constructor calling the Base DbContext Class Constructor
        public EFCoreDbContext() : base() 
        { 
        }

        // OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To display the Generated the Database Script
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            //use this to configure the model
            //Configuring the Connection String
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=EFCoreDB1; Trusted_Connection=True; TrustServerCertificate=True;");

            //Get the connection string from appsettings.json file

            //step2: Load the configuration file.
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //step3: Get the Section to Read from the Configuration File
            var configSection = configBuilder.GetSection("ConnectionStrings");

            //step4: Get the Configuration Values based on the Config key.
            var connectionString = configSection["SQLServerConnection"] ?? null;

            //Configuring the Connection String
            optionsBuilder.UseSqlServer(connectionString);
        }

        // OnModelCreation() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model
        }


        //Adding Domain Classes as DbSet Properties
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}
