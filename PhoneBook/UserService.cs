using PhoneBook.Controllers;
using PhoneBook.Models;

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
}
