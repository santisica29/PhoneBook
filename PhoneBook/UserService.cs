using PhoneBook.Controllers;
using PhoneBook.Models;
using PhoneBook.Views;

namespace PhoneBook;

internal class UserService
{
    private UserController userController = new UserController(); 
    internal void AddUser()
    {
        var name = Validator.GetStringInput();
        var email = Validator.GetEmailInput();
        var phoneNumber = Validator.GetPhoneNumber();
        var address = Validator.GetStringInput();

        var newUser = new User() 
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address,
        };

        userController.Add(newUser);
    }

    internal void GetAll()
    {
        var list = userController.GetAll();
        TableVisualisation.PrintUsersList(list);
    }

    internal User? GetUserById(int id)
    {
        using var db = new PhoneBookContext();
        User? user = db.Users.SingleOrDefault(x => x.Id == id);

        return user;
    }
    internal void RemoveUser()
    {

    }
}
