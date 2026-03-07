# PhoneBook
Console app that allows you to keep your contact's info in a neat personal phone book.

Add users with it's contact info (name, email, phone number, address), separated them by categories and even sent them an email with your gmail account.

Build with C#/.NET, EF Core, SQL Server, Spectre.Console, Mailkit for the email service and nUnit framework for the unit testing.

# Given Requirements
- This is an application where you should record contacts with their phone numbers.

- Users should be able to Add, Delete, Update and Read from a database, using the console.

- You need to use Entity Framework. ADO.NET, Dapper and any other ORM aren't allowed.

- Your code should contain a base Contact class with at least name, email and phone number properties.

- You should validate e-mails and phone numbers and let the user know what formats are expected.

- Make sure you handle errors so the app doesn't crash unexpectedly in case EF or the database have problems.

- You should use Code-First Approach, which means EF will create the database schema for you.

- You should seed data using Entity Framework so the user has some contacts to start with.

# Features 
- SQL Server database connection
- EF Core Code-First Approach, first make the model and then use migrations with Package Manager Console to create the database.
- Console based UI powered with Spectre.Console
- CRUD DB Functions, Add, Delete, Update and Get Users.
- Filter Users by categories.
- Send an email with your gmail account to any user in your phone's book app (You need a gmail account).
- Unit tests for validation methods using nUnit framework.
