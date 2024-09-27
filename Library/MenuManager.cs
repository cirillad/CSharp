using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class MenuManager
    {
        private readonly UserService _userService;
        private readonly BookstoreDbContext _context;

        private bool _isLoggedIn = false; 

        public MenuManager(UserService userService, BookstoreDbContext context) // Оновіть конструктор
        {
            _userService = userService;
            _context = context;
        }

        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                if (!_isLoggedIn)
                {
                    ShowLoginMenu(); // Вивести тільки реєстрацію і логін
                }
                else
                {
                    ShowFullMenu(); // Вивести повне меню після логіну
                }

                var choice = Console.ReadLine();

                if (!_isLoggedIn)
                {
                    switch (choice)
                    {
                        case "1":
                            RegisterUser();
                            break;

                        case "2":
                            LoginUser();
                            break;

                        case "3":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    switch (choice)
                    {
                        case "1":
                            AddBook();
                            break;

                        case "2":
                            EditBook();
                            break;

                        case "3":
                            DeleteBook();
                            break;

                        case "4":
                            SellBook();
                            break;

                        case "5":
                            ReserveBook();
                            break;

                        case "6":
                            MarkBookOutOfStock();
                            break;

                        case "7":
                            PutBookOnDiscount();
                            break;

                        case "8":
                            ShowingMenu();
                            break;

                        case "9":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }



        private void ShowingMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Search Books by Title");
            Console.WriteLine("2. Search Books by Author");
            Console.WriteLine("3. Search Books by Genre");
            Console.WriteLine("4. View New Releases");
            Console.WriteLine("5. View Most Popular Books");
            Console.WriteLine("6. View Most Popular Authors");
            Console.WriteLine("7. Back to Main Menu");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter title of the book : ");
                    string title = Console.ReadLine();
                    _userService.SearchBooksByTitle(title);
                    break;

                case "2":
                    Console.WriteLine("Enter author of the book : ");
                    string author = Console.ReadLine();
                    _userService.SearchBooksByAuthor(author);
                    break;

                case "3":
                    Console.WriteLine("Enter genre of the book : ");
                    string genre = Console.ReadLine();
                    _userService.SearchBooksByGenre(genre);
                    break;

                case "4":
                    _userService.ViewNewReleases();
                    break;

                case "5":
                    _userService.ViewMostPopularBooks();
                    break;

                case "6":
                    _userService.ViewMostPopularAuthors();
                    break;

                case "7":
                    // Go back to the main menu
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void ShowLoginMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
        }

        private void ShowFullMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Edit Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. Sell Book");
            Console.WriteLine("5. Reserve Book");
            Console.WriteLine("6. Mark Book as Out of Stock");
            Console.WriteLine("7. Put Book on Discount");
            Console.WriteLine("8. Showing menu");
            Console.WriteLine("9. Exit");
        }

        private void RegisterUser()
        {
            Console.Write("Enter username: ");
            var regUsername = Console.ReadLine();

            Console.Write("Enter password: ");
            var regPassword = Console.ReadLine();

            Console.Write("Confirm password: ");
            var regPasswordConfirm = Console.ReadLine();

            if (regPassword != regPasswordConfirm)
            {
                Console.WriteLine("Passwords do not match. Please try again.");
            }
            else
            {
                _userService.RegisterUser(regUsername, regPassword);
            }
        }

        private void LoginUser()
        {
            Console.Write("Enter username: ");
            var loginUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            var loginPassword = Console.ReadLine();
            var user = _userService.LoginUser(loginUsername, loginPassword);
            if (user != null)
            {
                _isLoggedIn = true;
            }
            else
            {
                Console.WriteLine("Login failed. Please try again.");
            }
        }

        private void AddBook()
        {
            Console.Write("Enter book title: ");
            var title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string authorName = Console.ReadLine();
            var author = _context.Authors
                .SingleOrDefault(a => a.FullName.ToLower() == authorName.ToLower());

            Console.Write("Enter publisher name: ");
            string publisherName = Console.ReadLine();
            var publisher = _context.Publishers
                .SingleOrDefault(p => p.Name.ToLower() == publisherName.ToLower());

            Console.Write("Enter genre name: ");
            string genreName = Console.ReadLine();
            var genre = _context.Genres
                .SingleOrDefault(g => g.Name.ToLower() == genreName.ToLower());

            if (author == null || publisher == null || genre == null)
            {
                Console.WriteLine("Author, publisher, or genre not found. Please check your input.");
                return;
            }

            // Нові запити для кількості сторінок, року видання та вартість
            Console.Write("Enter page count: ");
            if (!int.TryParse(Console.ReadLine(), out int pageCount))
            {
                Console.WriteLine("Invalid input for page count. Please enter a valid number.");
                return;
            }

            Console.Write("Enter publication year: ");
            if (!int.TryParse(Console.ReadLine(), out int publicationYear))
            {
                Console.WriteLine("Invalid input for publication year. Please enter a valid year.");
                return;
            }

            Console.Write("Enter cost price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal costPrice))
            {
                Console.WriteLine("Invalid input for cost price. Please enter a valid price.");
                return;
            }

            Console.Write("Enter rating from 0 to 10 : ");

            if (!float.TryParse(Console.ReadLine(), out float popularity))
            {
                Console.WriteLine("Invalid input for cost price. Please enter a valid price.");
                return;
            }

            var book = new Book
            {
                Title = title,
                AuthorId = author.Id,
                PublisherId = publisher.Id,
                GenreId = genre.Id,
                PageCount = pageCount, 
                PublicationYear = publicationYear, 
                CostPrice = costPrice, 
                SalePrice = costPrice,
                IsOutOfStock = false, 
                DiscountPercentage = 0,
                ReservedFor = null 
            };

            _userService.AddBook(book); 
        }

        private void EditBook()
        {
            Console.Write("Enter the ID of the book you want to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid input. Please enter a valid book ID.");
                return;
            }

            var book = _context.Books.Include(b => b.Author)
                                      .Include(b => b.Publisher)
                                      .Include(b => b.Genre)
                                      .FirstOrDefault(b => b.Id == bookId); // Знайти книгу за ID
            if (book == null)
            {
                Console.WriteLine("Book not found. Please check the ID.");
                return;
            }

            // Запит на нові дані
            Console.Write($"Current title: {book.Title}. Enter new title (or press Enter to keep it unchanged): ");
            var newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                book.Title = newTitle; // Оновлення заголовка
            }

            // Виведення інформації про автора
            string authorInfo = book.Author?.FullName ?? "Author not assigned"; // Перевірка наявності автора
            Console.Write($"Current author: {authorInfo}. Enter new author name (or press Enter to keep it unchanged): ");
            var newAuthorName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthorName))
            {
                var newAuthor = _context.Authors.SingleOrDefault(a => a.FullName.ToLower() == newAuthorName.ToLower());
                if (newAuthor != null)
                {
                    book.AuthorId = newAuthor.Id; // Оновлення ID автора
                }
                else
                {
                    Console.WriteLine("Author not found. Keeping the current author.");
                }
            }

            // Виведення інформації про видавця
            string publisherInfo = book.Publisher?.Name ?? "Publisher not assigned"; // Перевірка наявності видавця
            Console.Write($"Current publisher: {publisherInfo}. Enter new publisher name (or press Enter to keep it unchanged): ");
            var newPublisherName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPublisherName))
            {
                var newPublisher = _context.Publishers.SingleOrDefault(p => p.Name.ToLower() == newPublisherName.ToLower());
                if (newPublisher != null)
                {
                    book.PublisherId = newPublisher.Id; // Оновлення ID видавця
                }
                else
                {
                    Console.WriteLine("Publisher not found. Keeping the current publisher.");
                }
            }

            // Виведення інформації про жанр
            string genreInfo = book.Genre?.Name ?? "Genre not assigned"; // Перевірка наявності жанру
            Console.Write($"Current genre: {genreInfo}. Enter new genre name (or press Enter to keep it unchanged): ");
            var newGenreName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newGenreName))
            {
                var newGenre = _context.Genres.SingleOrDefault(g => g.Name.ToLower() == newGenreName.ToLower());
                if (newGenre != null)
                {
                    book.GenreId = newGenre.Id; // Оновлення ID жанру
                }
                else
                {
                    Console.WriteLine("Genre not found. Keeping the current genre.");
                }
            }

            // Запити на редагування нових полів
            Console.Write($"Current page count: {book.PageCount}. Enter new page count (or press Enter to keep it unchanged): ");
            var newPageCountInput = Console.ReadLine();
            if (int.TryParse(newPageCountInput, out int newPageCount))
            {
                book.PageCount = newPageCount; // Оновлення кількості сторінок
            }

            Console.Write($"Current publication year: {book.PublicationYear}. Enter new publication year (or press Enter to keep it unchanged): ");
            var newPublicationYearInput = Console.ReadLine();
            if (int.TryParse(newPublicationYearInput, out int newPublicationYear))
            {
                book.PublicationYear = newPublicationYear; // Оновлення року видання
            }

            Console.Write($"Current cost price: {book.CostPrice:C}. Enter new cost price (or press Enter to keep it unchanged): ");
            var newCostPriceInput = Console.ReadLine();
            if (decimal.TryParse(newCostPriceInput, out decimal newCostPrice))
            {
                book.CostPrice = newCostPrice; // Оновлення вартості
                book.SalePrice = newCostPrice; // Оновлюємо SalePrice, щоб він залишався таким же
            }

            // Зберегти зміни в базі даних
            _context.SaveChanges();
            Console.WriteLine("Book updated successfully.");
        }

        private void DeleteBook()
        {
            Console.Write("Enter book ID to delete: ");
            var bookId = int.Parse(Console.ReadLine());
            _userService.DeleteBook(bookId);
        }

        private void SellBook()
        {
            Console.Write("Enter book ID to sell: ");
            var bookId = int.Parse(Console.ReadLine());
            _userService.SellBook(bookId);
            _userService.DeleteBook(bookId);
        }

        private void ReserveBook()
        {
            Console.Write("Enter book ID to reserve: ");
            var bookId = int.Parse(Console.ReadLine());

            Console.Write("Enter customer username: ");
            var customerUsername = Console.ReadLine();

            _userService.ReserveBookForCustomer(bookId, customerUsername);
        }

        private void MarkBookOutOfStock()
        {
            Console.Write("Enter book ID to mark as out of stock: ");
            var bookId = int.Parse(Console.ReadLine());
            _userService.MarkBookOutOfStock(bookId);
        }

        private void PutBookOnDiscount()
        {
            Console.Write("Enter book ID to put on discount: ");
            var bookId = int.Parse(Console.ReadLine());

            Console.Write("Enter discount percentage: ");
            var discountPercentage = double.Parse(Console.ReadLine());

            _userService.PutBookOnDiscount(bookId, discountPercentage);
        }
    }
}
