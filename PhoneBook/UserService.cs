using PhoneBook.Controllers;
using PhoneBook.Models;
using PhoneBook.Views;
using Spectre.Console;

namespace PhoneBook;

internal class UserService
{
    private static UserController userController = new UserController(); 
    internal static void AddUser()
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

    internal static void GetAll()
    {
        var list = userController.GetAll();
        TableVisualisation.PrintUsersList(list);
    }

    internal static void GetUser()
    {
        var list = userController.GetAll();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<User>()
            .Title("Choose your user: ")
            .UseConverter(u => u.Name)
            .AddChoices(list));

        var user = list.Single(x => x.Id == choice.Id);
        
        TableVisualisation.ShowUser(user);
    }
    internal static void RemoveUser()
    {

    }

    internal static void UpdateUser()
    {
        throw new NotImplementedException();
    }
}
