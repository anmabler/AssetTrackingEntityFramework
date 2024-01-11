﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal class Menu
    {
        public void mainMenu() {
            Console.WriteLine("-----------------");
            Console.WriteLine("Choose a number:");
            Console.WriteLine("1. Add new asset");
            Console.WriteLine("2. Show all assets");

            Console.Write("Enter your selection: ");
            string menuInput = Console.ReadLine();
            switch(menuInput)
            {
                case "1":
                    addNewAsset();
                    mainMenu();
                    break;
                case "2":
                    displayAssetList();
                    mainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    mainMenu();
                    break;
            }
        }

        private void addNewAsset()
        {
            //Instantiate db context
            MyDbContext db = new MyDbContext();

            Console.WriteLine("-----------------");
            Console.WriteLine("Add new asset");
            Console.WriteLine("1. Add computer");
            Console.WriteLine("2. Add phone");

            Console.Write("Enter your selection");
            string assetInput = Console.ReadLine();

            if (assetInput != "1" && assetInput != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                // Start over from beginning
                addNewAsset();
            }

            Console.Write("Enter brand: ");
            string brandInput = Console.ReadLine();

            Console.Write("Enter model: ");
            string modelInput = Console.ReadLine();

            Console.Write("Enter price: ");
            string priceInput = Console.ReadLine();
            bool isInt = int.TryParse(priceInput, out int value);
            if (!isInt) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                addNewAsset();
            }

            if (assetInput == "1" )
            {
               Computer computer = new Computer(brandInput, modelInput, value);
                // Create computer in db.
                db.Computers.Add(computer);
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Computer added.");
                Console.ResetColor();

            }
            else if ( assetInput == "2" )
            {
                Phone phone = new Phone(brandInput, modelInput, value);
                // Create phone in db.
                db.Phones.Add(phone);
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Phone added");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.");
                addNewAsset();
            }


        }
        private void displayAssetList()
        {
            MyDbContext db = new MyDbContext();
            Console.WriteLine("-----------------");

            // Using ArrayList as I want to display both computers and phones from the same list
            ArrayList assetList = new ArrayList();
            // Reads from db.
            var computers = db.Computers.ToList();
            var phones = db.Phones.ToList();
            assetList.AddRange(computers);
            assetList.AddRange(phones);

            foreach (var asset in assetList )
            {
                Console.WriteLine($"{asset.ToString()}");
            }
           
        }

    }
}
