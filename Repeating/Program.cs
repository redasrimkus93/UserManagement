// See https://aka.ms/new-console-template for more information
using Repeating;
using Repeating.Service;

var context = new ManagementContext();
var userService = new UserService(context);
var recordService = new RecordService(context);

User user = null;
while (true)
{
    Console.WriteLine("Įveskite vardą ir slaptažodį");

    var userName = Console.ReadLine();
    var password = Console.ReadLine();

    user = userService.FindUserByNameAndPassword(userName, password);
    if (user != null)
    {
        break;
    }
}

Console.WriteLine("Įveskite ką norite daryti toliau");
Console.WriteLine("Jei norite pamatyti savo įrašus spauskite - R, jei norite pridėti įrašą - P");
Console.WriteLine();
var choice = Console.ReadLine();

switch (choice)
{
    case "R":
        var records = userService.GetUserRecords(user);
        foreach (var item in records)
        {
            Console.WriteLine(item.Title + " " + item.Content);
        }
        break;
    case "P":
        Console.WriteLine("Įveskite įrašo pavadinimą");
        var title = Console.ReadLine();
        Console.WriteLine("Įveskite įrašą");
        var content = Console.ReadLine();
        recordService.CreateRecord(title, content, user.Id);
        break;
    default:
        break;
}







