using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Context;
using my_books.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitilizer
    {
        public static void SeedData(IApplicationBuilder builder)
        {
            using (var servicescope = builder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<LibraryContext>();

                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(
                        new Publisher() { Name = "Simon & Schuster, Inc." },
                        new Publisher() { Name = "John Wiley & Sons, Inc." },
                        new Publisher() { Name = "Nature America" });

                    context.SaveChanges();
                }
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st book title",
                        Description = "1st Book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-2),
                        Rate = 3,
                        Genre = "Biography",
                        CoverURL = "https.......",
                        DateAdded = DateTime.Now.AddDays(-10),
                        PublisherId = 2
                    }, new Book()
                    {
                        Title = "2nd book title",
                        Description = "2nd Book description",
                        IsRead = false,
                        Genre = "Auto Biography",
                        CoverURL = "https.......",
                        DateAdded = DateTime.Now.AddDays(-8),
                        PublisherId = 1
                    },
                     new Book()
                     {
                         Title = "3rd book title",
                         Description = "3rd Book description",
                         IsRead = false,
                         Genre = "Auto Biography",
                         CoverURL = "https.......",
                         DateAdded = DateTime.Now.AddDays(-6),
                         PublisherId = 3
                     });
                    context.SaveChanges();
                }
            }

        }
    }
}
