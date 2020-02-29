using CarPool.Trip.Domain.Entities;
using CarPool.Trip.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

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
    }
}
