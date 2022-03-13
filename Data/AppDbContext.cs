using Microsoft.EntityFrameworkCore;
using quandomeutimejoga_server.Models;

namespace quandomeutimejoga_server.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");

        public DbSet<Team> Teams { get; set; } = null!;


    }
}
