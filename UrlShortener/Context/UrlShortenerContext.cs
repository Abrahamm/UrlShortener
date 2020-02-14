using UrlShortener.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Context
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<User> Users { set; get; }

        public DbSet<Url> Urls { set; get; }

        public DbSet<Tagged> Taggeds { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options)
            : base(options)
        {
           // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Luka",
                    LastName = "Nuic",
                    BirthDate = new DateTime ( 1990, 2, 17)
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Davor",
                    LastName = "Lozic",
                    BirthDate = new DateTime(1980, 6, 29)
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Antun",
                    LastName = "Tun",
                    BirthDate = new DateTime(1986, 8, 25)
                });


            modelBuilder.Entity<Url>()
              .HasData(
                new Url()
                {
                    Id = 1,
                    LongUrl = "https://www.google.com",
                    ShortUrl = "gogle",
                    DateCreated = new DateTime(2020, 1, 12, 15, 32, 46),
                    DateExpires = new DateTime(2020, 2, 12, 15, 32, 46),
                    UserId = 1
                },
                new Url()
                {
                    Id = 2,
                    LongUrl = "https://www.index.hr",
                    ShortUrl = "index",
                    DateCreated = new DateTime(2020, 1, 24, 12, 01, 07),
                    DateExpires = new DateTime(2020, 2, 24, 12, 01, 07),
                    UserId = 1
                },
                new Url()
                {
                    Id = 3,
                    LongUrl = "https://www.net.hr",
                    ShortUrl = "nethr",
                    DateCreated = new DateTime(2020, 1, 20, 13, 17, 21),
                    DateExpires = new DateTime(2020, 2, 20, 13, 17, 21),
                    UserId = 2
                },
                new Url()
                {
                    Id = 4,
                    LongUrl = "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations",
                    ShortUrl = "linqq",
                    DateCreated = new DateTime(2020, 1, 17, 01, 36, 59),
                    DateExpires = new DateTime(2020, 2, 17, 01, 36, 59),
                    UserId = 2
                },
                new Url()
                {
                    Id = 5,
                    LongUrl = "https://www.entityframeworktutorial.net/efcore/entity-framework-core-dbcontext.aspx",
                    ShortUrl = "dbctx",
                    DateCreated = new DateTime(2020, 1, 31, 23, 59, 59),
                    DateExpires = new DateTime(2020, 2, 29, 23, 59, 59),
                    UserId = 3
                }
                );

            modelBuilder.Entity<Tagged>().
                HasData(
                new Tagged()
                {
                    Id = 1,
                    TagId = 1,
                    UrlId = 1
                },
                new Tagged()
                {
                    Id = 2,
                    TagId = 2,
                    UrlId = 2
                },
                new Tagged()
                {
                    Id = 3,
                    TagId = 8,
                    UrlId = 2
                },
                new Tagged()
                {
                    Id = 4,
                    TagId = 2,
                    UrlId = 3
                },
                new Tagged()
                {
                    Id = 5,
                    TagId = 8,
                    UrlId = 3
                },
                new Tagged()
                {
                    Id = 6,
                    TagId = 3,
                    UrlId = 4
                },
                new Tagged()
                {
                    Id = 7,
                    TagId = 6,
                    UrlId = 4
                },
                new Tagged()
                {
                    Id = 8,
                    TagId = 7,
                    UrlId = 4
                },
                new Tagged()
                {
                    Id = 9,
                    TagId = 3,
                    UrlId = 5
                },
                new Tagged()
                {
                    Id = 10,
                    TagId = 4,
                    UrlId = 5
                },
                new Tagged()
                {
                    Id = 11,
                    TagId = 5,
                    UrlId = 5
                },
                new Tagged()
                {
                    Id = 12,
                    TagId = 7,
                    UrlId = 5
                }
                );

            modelBuilder.Entity<Tag>().
                HasData(
                new Tag()
                {
                    Id = 1,
                    Name = "Web Search"
                },
                new Tag()
                {
                    Id = 2,
                    Name = "Web Portal"
                },
                new Tag()
                {
                    Id = 3,
                    Name = "Tutorial"
                }, 
                new Tag()
                {
                    Id = 4,
                    Name = "EF Core"
                }, 
                new Tag()
                {
                    Id = 5 ,
                    Name = "DB Context"
                },
                new Tag()
                {
                    Id = 6,
                    Name = "LINQ"
                },
                 new Tag()
                 {
                     Id = 7,
                     Name = "C#"
                 },
                  new Tag()
                  {
                      Id = 8,
                      Name = "News"
                  }
                );

            base.OnModelCreating(modelBuilder);
        }



    }
}
