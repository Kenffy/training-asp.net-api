using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    id = 1,
                    name = "Royal Villa",
                    details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                    occupancy = 4,
                    rate = 200,
                    sqft = 550,
                    amenity = "",
                    createdAt=DateTime.Now
                },
                new Villa
                {
                    id = 2,
                    name = "Premium Pool Villa",
                    details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                    occupancy = 4,
                    rate = 300,
                    sqft = 550,
                    amenity = "",
                    createdAt = DateTime.Now
                },
                new Villa
                {
                    id = 3,
                    name = "Luxury Pool Villa",
                    details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                    occupancy = 4,
                    rate = 400,
                    sqft = 750,
                    amenity = "",
                    createdAt = DateTime.Now
                },
                new Villa
                {
                    id = 4,
                    name = "Diamond Villa",
                    details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                    occupancy = 4,
                    rate = 550,
                    sqft = 900,
                    amenity = "",
                    createdAt = DateTime.Now
                },
                new Villa
                {
                    id = 5,
                    name = "Diamond Pool Villa",
                    details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                    occupancy = 4,
                    rate = 600,
                    sqft = 1100,
                    amenity = "",
                    createdAt = DateTime.Now
                });
        }
    }
}
