using CarPool.Trip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool.Trip.Persistence.Configurations
{
    public class EventTripConfiguration : IEntityTypeConfiguration<EventTrip>
    {
        public void Configure(EntityTypeBuilder<EventTrip> builder)
        {
            builder.HasKey(et => et.Id);

            builder.HasOne(et => et.Event)
                .WithMany(e => e.EventTrips)
                .HasForeignKey(et => et.EventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(et => et.Driver)
                .WithMany(p => p.DrivingAt)
                .HasForeignKey(et => et.DriverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
