using DianaOsipovaKT_42_21.Models;
using DianaOsipovaKT_42_21.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DianaOsipovaKT_42_21.Database
{

    public class OsipovaDbContext : DbContext
    {
        public DbSet<EducationalSubject> EducationalSubjects { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EducationSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }
        public OsipovaDbContext(DbContextOptions options) : base(options)
        {
        }
    }
    public class OsipovaDbContextFactory : IDesignTimeDbContextFactory<OsipovaDbContext>
    {
        public OsipovaDbContext CreateDbContext(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var optionsBuilder = new DbContextOptionsBuilder<OsipovaDbContext>();
            optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            return new OsipovaDbContext(optionsBuilder.Options);
        }
    }
}