// See https://aka.ms/new-console-template for more information
using AssetTrackingEntityFramework;

Console.WriteLine("Hello, World!");

MyDbContext db = new MyDbContext();

var offices = Office.getOfficesFromDb();
foreach (var office in offices)
{
    Console.WriteLine(office.Country);
}
Menu menu = new Menu();
menu.mainMenu();