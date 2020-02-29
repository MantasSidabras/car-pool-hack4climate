using Microsoft.EntityFrameworkCore;
using System;

namespace CarPool.Trip.Persistence
{
    public class TripDbContext : DbContext
    {
        protected TripDbContext()
        {
        }
    }
}
