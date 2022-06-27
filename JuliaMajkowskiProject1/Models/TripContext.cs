using Microsoft.EntityFrameworkCore;

namespace TripLog.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        { }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    Destination = "Puerto Rico",
                    Accomidations = "Resort World",
                    AccomidationPhone= "475-890-1234",
                    AccomidationEmail=  "resortworld@resort.com",
                    StartDate = "05/20/2021",
                    EndDate = "05/27/2021",
                    ThingsToDo1 = "visit beach",
                    ThingsToDo2 = "have a margarita",
                    ThingsToDo3 = "tan"
                }

                );
        }
    }
}
