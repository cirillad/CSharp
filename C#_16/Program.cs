using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

public class User
{
    [Required(ErrorMessage = "Id is required.")]
    [Range(1000, 9999, ErrorMessage = "Id must be between 1000 and 9999.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Login is required.")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login can only contain alphanumeric characters.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression(@"^[a-zA-Z0-9]{8,}$", ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "E-mail is required.")]
    [EmailAddress(ErrorMessage = "Invalid E-mail format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "CreditCard is required.")]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "CreditCard must be 16 digits long.")]
    public string CreditCard { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    [RegularExpression(@"^\+38-0\d{2}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Invalid phone number format.")]
    public string Phone { get; set; }
}

class Program
{
    static Dictionary<int, User> users = new Dictionary<int, User>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. View Users");
            Console.WriteLine("5. Save Data");
            Console.WriteLine("6. Load Data");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        UpdateUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        ViewUsers();
                        break;
                    case 5:
                        SaveData();
                        break;
                    case 6:
                        LoadData();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    static void AddUser()
    {
        User user = new User();
        user.Id = GetUniqueId();

        Console.Write("Enter Login: ");
        user.Login = Console.ReadLine();

        Console.Write("Enter Password: ");
        user.Password = Console.ReadLine();

        Console.Write("Confirm Password: ");
        user.ConfirmPassword = Console.ReadLine();

        Console.Write("Enter E-mail: ");
        user.Email = Console.ReadLine();

        Console.Write("Enter CreditCard: ");
        user.CreditCard = Console.ReadLine();

        Console.Write("Enter Phone: ");
        user.Phone = Console.ReadLine();

        if (ValidateUser(user))
        {
            users.Add(user.Id, user);
            Console.WriteLine("User added successfully.");
        }
        else
        {
            Console.WriteLine("Please enter the data again.");
        }
    }

    static void UpdateUser()
    {
        Console.Write("Enter User Id to update: ");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) && users.ContainsKey(id))
        {
            User user = users[id];

            Console.Write("Update Login: ");
            user.Login = Console.ReadLine();

            Console.Write("Update Password: ");
            user.Password = Console.ReadLine();

            Console.Write("Confirm Password: ");
            user.ConfirmPassword = Console.ReadLine();

            Console.Write("Update E-mail: ");
            user.Email = Console.ReadLine();

            Console.Write("Update CreditCard: ");
            user.CreditCard = Console.ReadLine();

            Console.Write("Update Phone: ");
            user.Phone = Console.ReadLine();

            if (ValidateUser(user))
            {
                users[id] = user;
                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("Please enter the data again.");
            }
        }
        else
        {
            Console.WriteLine("User with this Id does not exist.");
        }
    }

    static void DeleteUser()
    {
        Console.Write("Enter User Id to delete: ");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) && users.ContainsKey(id))
        {
            users.Remove(id);
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User with this Id does not exist.");
        }
    }

    static void ViewUsers()
    {
        foreach (var user in users.Values)
        {
            Console.WriteLine($"Id: {user.Id}, Login: {user.Login}, Email: {user.Email}, CreditCard: {user.CreditCard}, Phone: {user.Phone}");
        }
    }

    static void SaveData()
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText("users.json", json);
        Console.WriteLine("Data saved.");
    }

    static void LoadData()
    {
        if (File.Exists("users.json"))
        {
            string json = File.ReadAllText("users.json");
            users = JsonSerializer.Deserialize<Dictionary<int, User>>(json) ?? new Dictionary<int, User>();
            Console.WriteLine("Data loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static int GetUniqueId()
    {
        int id;
        Random random = new Random();
        do
        {
            id = random.Next(1000, 10000);
        } while (users.ContainsKey(id));
        return id;
    }

    static bool ValidateUser(User user)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(user);
        if (!Validator.TryValidateObject(user, context, results, true))
        {
            foreach (var error in results)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }
        return true;
    }
}
