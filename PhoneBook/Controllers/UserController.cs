using PhoneBook.Models;

namespace PhoneBook.Controllers;
internal class UserController
{
    internal void Add(User user)
    {
        using var db = new PhoneBookContext();

        db.Add(user);
        // INSERT INTO Users (Id, Name, Email, PhoneNumber, Address)
        // VALUES (@Id, @Name, @Email, @PhoneNumber, @Address);

        db.SaveChanges();
    }

    internal void Remove(User user)
    {
        using var db = new PhoneBookContext();
        db.Remove(user);
        // DELETE FROM Users
        // WHERE Id = user.Id
        db.SaveChanges();
    }

    internal List<User> GetAll()
    {
        using var db = new PhoneBookContext();
        List<User> list = db.Users.ToList();
        //SELECT * FROM Users
        return list;
    }

    internal User? GetUserById(int id)
    {
        using var db = new PhoneBookContext();
        User? user = db.Users.SingleOrDefault(x => x.Id == id);
        //SELECT FROM Users 
        // WHERE Id = id
        return user;
    }

    internal void Update(User user)
    {
        using var db = new PhoneBookContext();
        db.Update(user);
        db.SaveChanges();
    }
}
