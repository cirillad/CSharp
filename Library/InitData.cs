using Library.Entities;
using System;
using System.Linq;

namespace Library
{
    public class InitData
    {
        public static void SeedData(BookstoreDbContext context)
        {
            if (!context.Authors.Any())
            {
                var authors = new[]
                {
                    new Author { FullName = "Author One", Popularity = 1 },
                    new Author { FullName = "Author Two", Popularity = 2 }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();
            }

            if (!context.Publishers.Any())
            {
                var publishers = new[]
                {
                    new Publisher { Name = "Publisher One" },
                    new Publisher { Name = "Publisher Two" }
                };
                context.Publishers.AddRange(publishers);
                context.SaveChanges(); 
            }

            if (!context.Genres.Any())
            {
                var genres = new[]
                {
                    new Genre { Name = "Fiction" },
                    new Genre { Name = "Non-Fiction" },
                    new Genre { Name = "Science" }
                };
                context.Genres.AddRange(genres);
                context.SaveChanges(); 
            }

            if (!context.Books.Any())
            {
                var authors = context.Authors.ToList();
                var publishers = context.Publishers.ToList();
                var genres = context.Genres.ToList();

                var books = new[]
                {
                    new Book
                    {
                        Title = "Book One",
                        AuthorId = authors[0].Id,
                        PublisherId = publishers[0].Id,
                        GenreId = genres[0].Id,
                        PageCount = 300,
                        PublicationYear = 2021,
                        CostPrice = 15.00m,
                        SalePrice = 12.00m,
                        Popularity = 5,
                        ReleaseDate = new DateTime(2021, 5, 1),
                        IsOutOfStock = false,
                        DiscountPercentage = 10.0
                    },
                    new Book
                    {
                        Title = "Book Two",
                        AuthorId = authors[1].Id,
                        PublisherId = publishers[1].Id,
                        GenreId = genres[1].Id,
                        PageCount = 250,
                        PublicationYear = 2020,
                        CostPrice = 20.00m,
                        SalePrice = 18.00m,
                        Popularity = 3,
                        ReleaseDate = new DateTime(2020, 8, 15),
                        IsOutOfStock = true, 
                        DiscountPercentage = 0.0 
                    }
                };
                context.Books.AddRange(books);
                context.SaveChanges(); 
            }
        }
    }
}
