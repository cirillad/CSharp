using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shops.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Shops
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ShopAppDbContext>(options =>
                    options.UseSqlServer(@"Server=DESKTOP-G3MR3PH\SQLEXPRESS;Database=Shops;Integrated Security=True;TrustServerCertificate=True;",
                        sqlOptions => sqlOptions.EnableRetryOnFailure()))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<ShopAppDbContext>())
            {
                //context.Database.EnsureCreated();
                // Виведення інформації
                SeedData.Initialize(serviceProvider);

                DisplayData(context);
            }
        }

        private static void DisplayData(ShopAppDbContext context)
        {
            try
            {
                var countries = context.Countries.ToList();
                var cities = context.Cities.Include(c => c.Country).ToList(); // Завантаження країни
                var shops = context.Shops.Include(s => s.City).ToList(); // Завантаження міста
                var workers = context.Workers.Include(w => w.Position).Include(w => w.Shop).ToList(); // Завантаження позицій та магазинів
                var positions = context.Positions.ToList();
                var categories = context.Categories.ToList();
                var products = context.Products.Include(p => p.Category).ToList(); // Завантаження категорій

                // Виводимо дані
                Console.WriteLine("Країни:");
                foreach (var country in countries)
                {
                    Console.WriteLine($"- {country.Name}");
                }

                Console.WriteLine("\nМіста:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"- {city.Name}, Країна: {city.Country.Name}");
                }

                Console.WriteLine("\nМагазини:");
                foreach (var shop in shops)
                {
                    Console.WriteLine($"- {shop.Name}, Адреса: {shop.Address}, Місто: {shop.City.Name}");
                }

                Console.WriteLine("\nПрацівники:");
                foreach (var worker in workers)
                {
                    Console.WriteLine($"- {worker.Name} {worker.Surname}, Посада: {worker.Position.Name}, Магазин: {worker.Shop.Name}");
                }

                Console.WriteLine("\nПосади:");
                foreach (var position in positions)
                {
                    Console.WriteLine($"- {position.Name}");
                }

                Console.WriteLine("\nКатегорії:");
                foreach (var category in categories)
                {
                    Console.WriteLine($"- {category.Name}");
                }

                Console.WriteLine("\nПродукти:");
                foreach (var product in products)
                {
                    Console.WriteLine($"- {product.Name}, Ціна: {product.Price}, Категорія: {product.Category.Name}, В наявності: {product.IsInStock}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка: {ex.Message}");
            }
        }

    }
}
