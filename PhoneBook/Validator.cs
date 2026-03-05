using Microsoft.IdentityModel.Tokens;
using Spectre.Console;
using System.Net.Mail;
using static PhoneBook.Models.Enums;

namespace PhoneBook;

internal class Validator
{
    internal static UserCategories ChooseCategory()
    {
        var category = AnsiConsole.Prompt(new SelectionPrompt<UserCategories>()
            .Title("Choose the category: ")
            .AddChoices(Enum.GetValues<UserCategories>()));

        return category;
    }

    internal static string GetEmailInput()
    {
        var email = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your [green]email[/]: ")
            .Validate(input =>
            MailAddress.TryCreate(input, out _)
            ? ValidationResult.Success()
            : ValidationResult.Error("Please enter a valid [red]email[/]")));
            
        return email;
    }

    internal static string GetPhoneNumber()
    {
        var phoneNumber = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your [blue]phone number[/]: ")
            .Validate(input =>
            input.All(c => char.IsDigit(c) || c == '+')
            ? ValidationResult.Success()
            : ValidationResult.Error("Please enter a valid [red]number[/]")));

        return phoneNumber;
    }

    internal static string GetStringInput(string msg)
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>(msg)
            .Validate(x =>
            x.IsNullOrEmpty()
            ? ValidationResult.Error("Enter a valid string input")
            : ValidationResult.Success()));

        return input;
    }
}
