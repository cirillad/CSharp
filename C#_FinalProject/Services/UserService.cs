using System.Text.Json;

public class UserService
{
    private const string FilePath = "users.json";
    private List<User> _users;

    public UserService()
    {
        _users = LoadUsersFromFile();
    }

    public bool Register(User user)
    {
        if (_users.Exists(u => u.Login == user.Login))
        {
            return false;
        }

        _users.Add(user);
        SaveUsersToFile();
        return true;
    }

    public User Login(string login, string password)
    {
        return _users.Find(u => u.Login == login && u.Password == password);
    }

    public void UpdateUser(User user)
    {
        var existingUser = _users.Find(u => u.Login == user.Login);
        if (existingUser != null)
        {
            _users.Remove(existingUser);
            _users.Add(user);
            SaveUsersToFile();
        }
    }

    public List<User> GetTop20Players()
    {
        return _users
            .OrderByDescending(u => u.GetAveragePercentage())
            .Take(20)
            .ToList();
    }

    private List<User> LoadUsersFromFile()
    {
        if (!File.Exists(FilePath))
        {
            return new List<User>();
        }

        var jsonData = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
    }

    private void SaveUsersToFile()
    {
        var jsonData = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, jsonData);
    }
}
