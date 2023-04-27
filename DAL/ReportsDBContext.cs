using Microsoft.EntityFrameworkCore;
using reports_app_backend.DAL.Models;

namespace reports_app_backend.DAL
{
    public class ReportsDBContext : DbContext
    {
        public DbSet<TemplateData> TemplateDatas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=reportsdatabase.db;");   
        }
    }
}
