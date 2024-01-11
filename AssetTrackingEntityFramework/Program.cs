// See https://aka.ms/new-console-template for more information
using AssetTrackingEntityFramework;

Console.WriteLine("Hello, World!");

MyDbContext db = new MyDbContext();

Menu menu = new Menu();
menu.mainMenu();