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
                new SelectionPrompt<Enums.MenuOption>()
                .Title("Choose your option")
                .AddChoices(Enum.GetValues<Enums.MenuOption>()));

            switch (choice)
            {
                case Enums.MenuOption.AddUser:
                    UserService.AddUser();
                    break;
            }
        }
    }
}
