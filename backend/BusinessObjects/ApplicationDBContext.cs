using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseMySQL(config.GetConnectionString("MySQLNguyen"));
        }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Testcase> Testcases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionId);
            });

            modelBuilder.Entity<Testcase>(entity =>
            {
                entity.HasKey(e => e.TestcaseId);
                entity.HasOne(e => e.question).WithMany(
                        e => e.Testcases);
            });
        }
    }
}
