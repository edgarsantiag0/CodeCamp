using CodeCamp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCamp.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public AppDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Talk> Talks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Camp>()
              .HasData(new
              {
                  CampId = 1,
                  Moniker = "BARCAMP2020",
                  Name = "BarCamp STI",
                  EventDate = new DateTime(2018, 10, 18),
                  LocationId = 1,
                  Length = 1
              });

            bldr.Entity<Location>()
              .HasData(new
              {
                  LocationId = 1,
                  VenueName = "Edificio Padre Arroyo",
                  Address1 = "Autopista Duarte Km 1 1/2",
                  CityTown = "Santiago",
                  StateProvince = "STI",
                  PostalCode = "51000",
                  Country = "DR"
              });

            bldr.Entity<Talk>()
              .HasData(new
              {
                  TalkId = 1,
                  CampId = 1,
                  SpeakerId = 1,
                  Title = "Entity Framework From Scratch",
                  Abstract = "Entity Framework from scratch in an hour. Probably cover it all",
                  Level = 100
              },
              new
              {
                  TalkId = 2,
                  CampId = 1,
                  SpeakerId = 2,
                  Title = "Writing Sample Data Made Easy",
                  Abstract = "Thinking of good sample data examples is tiring.",
                  Level = 200
              });

            bldr.Entity<Speaker>()
              .HasData(new
              {
                  SpeakerId = 1,
                  FirstName = "Edgar",
                  LastName = "Santiago",
                  BlogUrl = "http://edgarsantiago.com",
                  Company = "Edgar Santiago Dev",
                  CompanyUrl = "http://edgarsantiago.com",
                  GitHub = "edgarsantiag0",
                  Twitter = "edgarsantiag0"
              }, new
              {
                  SpeakerId = 2,
                  FirstName = "Leonardo",
                  LastName = "Gonell",
                  BlogUrl = "http://leogonell.com",
                  Company = "Ubicao SRL",
                  CompanyUrl = "http://leogonell.com",
                  GitHub = "leogonell",
                  Twitter = "leogonell"
              });

        }

    }
}
