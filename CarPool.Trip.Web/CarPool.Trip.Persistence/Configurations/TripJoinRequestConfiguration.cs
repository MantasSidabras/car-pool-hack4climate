using CarPool.Trip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPool.Trip.Persistence.Configurations
{
    public class TripJoinRequestConfiguration : IEntityTypeConfiguration<TripJoinRequest>
    {
        public void Configure(EntityTypeBuilder<TripJoinRequest> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Passenger)
                .WithMany(p => p.TripJoinRequests)
                .HasForeignKey(t => t.PassengerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(t => t.Trip)
                .WithMany(e => e.TripJoinRequests)
                .HasForeignKey(t => t.EventTripId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
