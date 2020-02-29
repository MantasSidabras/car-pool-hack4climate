using CarPool.Trip.Domain.Entities;
using CarPool.Trip.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarPool.Trip.Persistence
{
    public class TripDbContext : DbContext
    {
        protected TripDbContext(DbContextOptions<TripDbContext> options)
            : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventTrip> EventTrips { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<TripJoinRequest> TripJoinRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new EventTripConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new TripJoinRequestConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TripDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
