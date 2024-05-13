using DynamicApplication.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationProgram> ApplicationPrograms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultContainer("ApplicationPrograms");

            modelBuilder.Entity<ApplicationProgram>()
                .ToContainer("ApplicationPrograms")
                .HasPartitionKey(a => a.Id)
                .HasNoDiscriminator();

            modelBuilder.Entity<Question>()
               .ToContainer("Questions")
               .HasPartitionKey(a => a.ProgramId)
               .HasNoDiscriminator();

            modelBuilder.Entity<QuestionAnswer>()
              .ToContainer("QuestionAnswers")
              .HasPartitionKey(a => a.UserId)
              .HasNoDiscriminator();
        }
    }
}
