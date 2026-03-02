using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook.Views;

internal class TableVisualisation
{
    internal static void PrintUsersList(List<User> list)
    {
        var table = new Table();
        table.AddColumns("Name", "Email", "Phone number", "Address");

        foreach (var user in list)
        {
            table.AddRow(user.Name, user.Email, user.PhoneNumber, user.Address ?? "-");
        }

        AnsiConsole.Write(table);
    }
}
