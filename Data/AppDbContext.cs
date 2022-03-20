using Microsoft.EntityFrameworkCore;
using quandomeutimejoga_server.Models;
using quandomeutimejoga_server.Models.Enums;

namespace quandomeutimejoga_server.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");

        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Competition> Competitions { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<CompetitionTeam> CompetitionTeams { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ==== Init Config Country ==== //
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.Name).IsRequired().HasMaxLength(120);
            builder.Entity<Country>().Property(p => p.CountryCode).IsRequired().HasMaxLength(4);
            builder.Entity<Country>().Property(p => p.Continent).HasConversion(v => v.ToString(), v => (Continent)Enum.Parse(typeof(Continent), v)).IsRequired();
            builder.Entity<Country>().HasMany(p => p.Organizations).WithOne(p => p.Country).HasForeignKey(p => p.CountryId).IsRequired();
            builder.Entity<Country>().HasMany(p => p.Competitions).WithOne(p => p.Country).HasForeignKey(p => p.CountryId).IsRequired();
            builder.Entity<Country>().HasMany(p => p.Teams).WithOne(p => p.Country).HasForeignKey(p => p.CountryId).IsRequired();
            // ==== End Config Country ==== //

            // ==== Init Config Organization ==== //
            builder.Entity<Organization>().HasKey(p => p.Id);
            builder.Entity<Organization>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Organization>().Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Entity<Organization>().Property(p => p.CountryId).IsRequired();
            builder.Entity<Organization>().HasMany(p => p.Competitions).WithOne(p => p.Organization).HasForeignKey(p => p.OrganizationId).IsRequired();
            // ==== End Config Organization ==== //

            // ==== Init Config Team ==== //
            builder.Entity<Team>().HasKey(p => p.Id);
            builder.Entity<Team>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Team>().Property(p => p.FullName).IsRequired().HasMaxLength(150);
            builder.Entity<Team>().Property(p => p.ShortName).IsRequired().HasMaxLength(80);
            builder.Entity<Team>().Property(p => p.Initials).IsRequired().HasMaxLength(5);
            builder.Entity<Team>().Property(p => p.CountryId).IsRequired();
            // ==== End Config Team ==== //

            // ==== Init Config Competition ==== //
            builder.Entity<Competition>().HasKey(p => p.Id);
            builder.Entity<Competition>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Competition>().Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Entity<Competition>().Property(p => p.OrganizationId).IsRequired();
            builder.Entity<Competition>().Property(p => p.TypeCompetition).HasConversion(v => v.ToString(), v => (TypeCompetition)Enum.Parse(typeof(TypeCompetition), v)).IsRequired();
            builder.Entity<Competition>().Property(p => p.Season).IsRequired().HasMaxLength(50);
            // ==== End Config Competition ==== //

            // ==== Init Config CompetitionTeam ==== //
            builder.Entity<CompetitionTeam>().HasKey(ct => new { ct.CompetitionId, ct.TeamId });
            builder.Entity<CompetitionTeam>().HasOne(ct => ct.Competition).WithMany(c => c.CompetitionTeams).HasForeignKey(c => c.CompetitionId);
            builder.Entity<CompetitionTeam>().HasOne(ct => ct.Team).WithMany(t => t.CompetitionTeams).HasForeignKey(t => t.TeamId);
            // ==== End Config CompetitionTeam ==== //
        }
    }
}
