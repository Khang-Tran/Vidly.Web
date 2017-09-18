using System.Web.Configuration;
using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.MembershipTypeSet.AddOrUpdate(m => m.Id,
               new MembershipTypes()
               {
                   Id = 1,
                   Name = "For one day",
                   DurationInMonth = 0,
                   SignUpFee = 0,
                   DiscountRate = 0
               },
                new MembershipTypes()
                {
                    Id = 2,
                    Name = "For one month",
                    DurationInMonth = 1,
                    SignUpFee = 30,
                    DiscountRate = 5
                },
                new MembershipTypes()
                {
                    Id = 3,
                    Name = "For three months",
                    DurationInMonth = 3,
                    SignUpFee = 120,
                    DiscountRate = 10
                },
                new MembershipTypes()
                {
                    Id = 4,
                    Name = "For one year",
                    DurationInMonth = 12,
                    SignUpFee = 300,
                    DiscountRate = 15
                });



            context.CustomerSet.AddOrUpdate(c => c.Id,
                new Customers() { Id = 1, Name = "Khang", IsSubscribeToLetter = true, MembershipTypesId = 1, BirthDate = Convert.ToDateTime("1995/2/11")},
                new Customers() { Id = 2, Name = "An", IsSubscribeToLetter = false, MembershipTypesId = 2, BirthDate = Convert.ToDateTime("1995/2/11") },
                new Customers() { Id = 3, Name = "ABC", IsSubscribeToLetter = true, MembershipTypesId = 3, BirthDate = Convert.ToDateTime("1995/2/11") },
                new Customers() { Id = 4, Name = "XYZ", IsSubscribeToLetter = true, MembershipTypesId = 4, BirthDate = Convert.ToDateTime("1995/2/11") });






            context.MovieSet.AddOrUpdate(m => m.Id,
                new Movies() { Id = 1, Name = "Deadpool", GenreId = 1, ReleasedDate = Convert.ToDateTime("2019/2/11"), AddedDate = DateTime.Now, Stock = 5 },
                new Movies() { Id = 2, Name = "Avengers", GenreId = 1, ReleasedDate = Convert.ToDateTime("2020/2/21"), AddedDate = DateTime.Now, Stock = 4 },
                new Movies() { Id = 3, Name = "Die Hard", GenreId = 1, ReleasedDate = Convert.ToDateTime("2019/4/22"), AddedDate = DateTime.Now, Stock = 2 },
                new Movies() { Id = 4, Name = "The Terminator", GenreId = 1, ReleasedDate = Convert.ToDateTime("2030/5/11"), AddedDate = DateTime.Now, Stock = 6 },
                new Movies() { Id = 5, Name = "Toy Story", GenreId = 2, ReleasedDate = Convert.ToDateTime("2060/5/11"), AddedDate = DateTime.Now, Stock = 10 }
            );

            context.GenreSet.AddOrUpdate(g => g.Id,
                new Genre() { Id = 1, Name = "Action" },
                new Genre() { Id = 2, Name = "Family" },
                new Genre() { Id = 3, Name = "Sci-fiction" },
                new Genre() { Id = 4, Name = "Horror" }
                );
        }
    }
}

