using Microsoft.IdentityModel.Tokens;
using Spectre.Console;
using System.Net.Mail;

namespace PhoneBook;

internal class Validator
{
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

    internal static string GetStringInput()
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your input: ")
            .Validate(x =>
            x.IsNullOrEmpty()
            ? ValidationResult.Success()
            : ValidationResult.Error("Enter a valid string input")));

        return input;
    }
}
