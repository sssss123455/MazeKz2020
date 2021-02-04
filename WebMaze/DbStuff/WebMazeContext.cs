using Microsoft.EntityFrameworkCore;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Morgue;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff
{
    public class WebMazeContext : DbContext
    {
        public DbSet<CitizenUser> CitizenUser { get; set; }

        public DbSet<Adress> Adress { get; set; }

        public DbSet<Policeman> Policemen { get; set; }

        public DbSet<Violation> Violations { get; set; }
        
        public DbSet<ViolationType> TypesOfViolation { get; set; }

        public DbSet<HealthDepartment> HealthDepartment { get; set; }

        public DbSet<Bus> Bus { get; set; }

        public DbSet<BusStop> BusStop { get; set; }

        public DbSet<BusRoute> BusRoute { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<RegisterCardForMorgue> RegisterCardForMorgue { get; set; }
        public DbSet<ForensicReport> ForensicReport { get; set; }
        public DbSet<BodyIdentificationReport> BodyIdentificationReport { get; set; }
        public DbSet<RitualService> RitualService { get; set; }
        public WebMazeContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitizenUser>()
                .HasMany(citizen => citizen.Adresses)
                .WithOne(adress => adress.Owner);
            modelBuilder.Entity<RegisterCardForMorgue>()
                .HasOne(corpse => corpse.ForensicReport)
                .WithOne(report => report.Corpse)
                .HasForeignKey<ForensicReport>(key => key.CorpseId);
            modelBuilder.Entity<RegisterCardForMorgue>()
                .HasOne(corpse => corpse.BodyIdentificationReport)
                .WithOne(date => date.Corpse)
                .HasForeignKey<BodyIdentificationReport>(key => key.CorpseId);
            modelBuilder.Entity<RitualService>()
                .HasMany(sevice => sevice.Corpses)
                .WithOne(corpse => corpse.RitualService);
            base.OnModelCreating(modelBuilder);
        }
    }
}
