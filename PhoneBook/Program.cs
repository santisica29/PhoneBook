using PhoneBook;
using Spectre.Console;
using static PhoneBook.Models.Enums;

bool isAppRunning = true;

while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
        .Title("Choose your menu option: ")
        .AddChoices(Enum.GetValues<MenuOptions>()));

    switch (option)
    {
        case MenuOptions.AddUser:
            UserService.AddUser();
            break;
        case MenuOptions.RemoveUser:
            UserService.RemoveUser();
            break;
        case MenuOptions.UpdateUser:
            UserService.UpdateUser();
            break;
        case MenuOptions.GetUser:
            UserService.GetUser();
            break;
        case MenuOptions.GetAllUsers:
            UserService.GetAll();
            break;
        case MenuOptions.Exit:
            isAppRunning = false;
            break;
    }
}
