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
        var name = Validator.GetStringInput("Enter your name: ");
        var email = Validator.GetEmailInput();
        var phoneNumber = Validator.GetPhoneNumber();
        var address = Validator.GetStringInput("Enter your address: ");

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
        var user = SelectUser();

        if (user == null)
        {
            AnsiConsole.MarkupLine("[red]No users found[/]");
            Console.ReadKey();
            return;
        }

        TableVisualisation.ShowUser(user);
    }
    internal static void RemoveUser()
    {
        var user = SelectUser();

        if (user == null)
        {
            AnsiConsole.MarkupLine("[red]No users found[/]");
            Console.ReadKey();
            return;
        }

        userController.Remove(user);
    }

    internal static void UpdateUser()
    {
        var user = SelectUser();

        if (user is null)
        {
            AnsiConsole.MarkupLine("[red]No users found[/]");
            Console.ReadKey();
            return;
        }

        user.Name = AnsiConsole.Confirm("Update user name? ")
            ? Validator.GetStringInput("Enter your new name: ")
            : user.Name;

        user.Email = AnsiConsole.Confirm("Update user email? ")
            ? Validator.GetEmailInput()
            : user.Email;

        user.PhoneNumber = AnsiConsole.Confirm("Update user's phone number? ")
            ? Validator.GetPhoneNumber()
            : user.PhoneNumber;

        user.Address = AnsiConsole.Confirm("Update user's address? ")
            ? Validator.GetStringInput("Enter your new address: ")
            : user.Address;

        userController.Update(user);
    }

    internal static User? SelectUser()
    {
        var list = userController.GetAll();

        if (!list.Any())
        {
            return null;
        }

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<User>()
            .Title("Choose your user: ")
            .UseConverter(u => u.Name)
            .AddChoices(list));

        var user = list.Single(x => x.Id == choice.Id);

        return user;
    }
}
