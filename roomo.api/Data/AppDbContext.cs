using Microsoft.EntityFrameworkCore;
using Room.api.Domain.Entities;

namespace roomo.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Rooms> room { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<CleaningStatus> cleaning_status { get; set; }
    }

}
