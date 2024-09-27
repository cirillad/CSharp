using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shops.Entities;

namespace Shops
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopAppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ShopAppDbContext>>()))
            {
                if (context.Countries.Any() || context.Cities.Any() || context.Shops.Any() || context.Workers.Any() || context.Positions.Any() || context.Categories.Any() || context.Products.Any())
                {
                    return;
                }

                var countries = new List<Country>
            {
                new Country { Name = "Україна" },
                new Country { Name = "Польща" }
            };
                context.Countries.AddRange(countries);
                context.SaveChanges();

                var cities = new List<City>
            {
                new City { Name = "Київ", CountryId = countries.First(c => c.Name == "Україна").Id },
                new City { Name = "Львів", CountryId = countries.First(c => c.Name == "Україна").Id },
                new City { Name = "Варшава", CountryId = countries.First(c => c.Name == "Польща").Id }
            };
                context.Cities.AddRange(cities);
                context.SaveChanges();

                var shops = new List<Shop>
            {
                new Shop { Name = "Магазин Київ", Address = "Вулиця Київська, 1", CityId = cities.First(c => c.Name == "Київ").Id, ParkingArea = 50 },
                new Shop { Name = "Магазин Львів", Address = "Вулиця Левицького, 5", CityId = cities.First(c => c.Name == "Львів").Id, ParkingArea = 30 },
                new Shop { Name = "Магазин Варшава", Address = "Уліца Польська, 10", CityId = cities.First(c => c.Name == "Варшава").Id, ParkingArea = 60 }
            };
                context.Shops.AddRange(shops);
                context.SaveChanges();

                var positions = new List<Position>
            {
                new Position { Name = "Продавець" },
                new Position { Name = "Менеджер" },
                new Position { Name = "Охоронець" }
            };
                context.Positions.AddRange(positions);
                context.SaveChanges();

                var workers = new List<Worker>
            {
                new Worker { Name = "Іван", Surname = "Іванов", Salary = 10000m, Email = "ivan@example.com", PhoneNumber = "+380123456789", PositionId = positions.First(p => p.Name == "Продавець").Id, ShopId = shops.First(s => s.Name == "Магазин Київ").Id },
                new Worker { Name = "Петро", Surname = "Петров", Salary = 12000m, Email = "petro@example.com", PhoneNumber = "+380987654321", PositionId = positions.First(p => p.Name == "Менеджер").Id, ShopId = shops.First(s => s.Name == "Магазин Львів").Id },
                new Worker { Name = "Анджей", Surname = "Ковальський", Salary = 15000m, Email = "andrzej@example.com", PhoneNumber = "+48123456789", PositionId = positions.First(p => p.Name == "Охоронець").Id, ShopId = shops.First(s => s.Name == "Магазин Варшава").Id }
            };
                context.Workers.AddRange(workers);
                context.SaveChanges();

                var categories = new List<Category>
            {
                new Category { Name = "Електроніка" },
                new Category { Name = "Одяг" },
                new Category { Name = "Продукти харчування" }
            };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                var products = new List<Product>
            {
                new Product { Name = "Телефон", Price = 15000m, Discount = 0.1f, CategoryId = categories.First(c => c.Name == "Електроніка").Id, IsInStock = true },
                new Product { Name = "Футболка", Price = 500m, Discount = 0.05f, CategoryId = categories.First(c => c.Name == "Одяг").Id, IsInStock = true },
                new Product { Name = "Хліб", Price = 30m, Discount = 0f, CategoryId = categories.First(c => c.Name == "Продукти харчування").Id, IsInStock = true }
            };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
