using Microsoft.EntityFrameworkCore;
using reports_app_backend.DAL.Models;
using reports_app_backend.Service.DTOs;

namespace reports_app_backend.DAL
{
    public class ReportsDBContext : DbContext
    {
        public DbSet<TemplateData> TemplateDatas { get; set; }
        public DbSet<Report> Reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=reportsdatabase.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Template)
                .WithMany()
                .HasForeignKey(r => r.TemplateDataId); // use TemplateDataId as foreign key

            modelBuilder.Entity<TemplateDTO>()
        .Ignore(t => t.Fields);
        }
    }
}
