using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook.Views;
internal class UserInterface
{
    internal void MainMenu()
    {
        bool isAppRunning = true;

        while (isAppRunning)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MenuOptions>()
                .Title("Choose your option")
                .AddChoices(Enum.GetValues<Enums.MenuOptions>()));

            switch (choice)
            {
                case Enums.MenuOptions.AddUser:
                    UserService.AddUser();
                    break;
            }
        }
    }
}
