using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Console.WriteLine("3. Edit asset");
            Console.WriteLine("4. Delete asset");
            Console.WriteLine("5. Exit");

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
                case "3":
                    editAsset();
                    mainMenu();
                    break;
                case "4":
                    deleteAsset();
                    mainMenu();
                    break;
                case "5":
                    Console.WriteLine("Closing application...");
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

            Console.Write("Enter your selection: ");
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

            // get offices from db
            var offices = Office.getOfficesFromDb();
            Console.WriteLine("Choose an office to add device to: ");
            foreach (var office in offices)
            {
                Console.WriteLine($"{office.Id}. {office.Country}");
            }

            bool isOfficeInt = false;
            int officeId;

            do
            {
                Console.Write("Enter office id: ");
                var officeInput = Console.ReadLine();
                isOfficeInt = int.TryParse(officeInput, out officeId);


            } while(!isOfficeInt || !offices.Exists(o => o.Id == officeId));
    

            if (assetInput == "1")
            {
                Computer computer = new Computer(brandInput, modelInput, value, officeId);
                // Create computer in db.
                db.Computers.Add(computer);
                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Computer added.");
                Console.ResetColor();

            }
            else if (assetInput == "2")
            {
                Phone phone = new Phone(brandInput, modelInput, value, officeId);
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

        private List<Asset> getListFromDb()
        {
            MyDbContext db = new MyDbContext();

            // Reads from db.
            var computers = db.Computers.ToList();
            var phones = db.Phones.ToList();

            var offices = db.Offices.ToList();

            List<Asset> assets = [.. computers, .. phones];
            // Set office
            for (int i = 0; i < assets.Count; i++)
            {
                var office = offices.Find(o => o.Id == assets[i].OfficeId);
                assets[i].Office = office;
            }
            // ! Sort order: Type, purchase date. 
            assets = assets.OrderBy(x => x.GetType().Name).ThenBy(x => x.PurchaseDate).ToList();
            return assets;
        } 

        private string listHeading()
        {
            string listString = "Brand".PadRight(16) + "Model".PadRight(16) + "Price".PadRight(16) + "Purchase date".PadRight(16) + "End of life".PadRight(16) + "Type";
            return listString;
        }
        private void displayAssetList()
        {
            var assets = getListFromDb();

            Console.WriteLine(listHeading());
            foreach (var asset in assets )
            {
                TimeSpan timeSpan = asset.EndOfLife - DateTime.Now;
                // Marks items as red if timespan is less than or equal to 90 days
                if(timeSpan.Days <= 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{asset.ToString()}");
                    Console.ResetColor() ;
                }
                else
                {
                    Console.WriteLine($"{asset.ToString()}");
                }
            }
           
        }

        private void editAsset()
        {
            MyDbContext myDbContext = new MyDbContext();
            Console.WriteLine(listHeading());

            var assetList = getListFromDb();

            for (int i = 0; i < assetList.Count; i++)
            {
                Console.WriteLine($"{i} {assetList[i].ToString()}");
            }

            bool isInt = false;
            int value;
            do
            {
                Console.Write("Choose an item to edit:");
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out value);
                if (!isInt)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a valid number.");
                    Console.ResetColor();
                }

            } while (!isInt || value > assetList.Count -1);
            // The count is 7 but index 0-6

            // Item from list 
            var itemToEdit = assetList[value];

            Console.WriteLine("Editing: " + itemToEdit.ToString());
            Console.WriteLine("Enter a new value or keep the field empty to use the old value.");
            Console.WriteLine("-----------------");

            itemToEdit.EditItem();
            Console.WriteLine("Asset updated.");
        }

        private void deleteAsset()
        {
            MyDbContext myDbContext = new MyDbContext();
            Console.WriteLine(listHeading());

            var assetList = getListFromDb();

            for (int i = 0; i < assetList.Count; i++)
            {
                Console.WriteLine($"{i} {assetList[i].ToString()}");
            }

            bool isInt = false;
            int value;
            do
            {
                Console.Write("Choose an item to delete:");
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out value);
                if (!isInt)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a valid number.");
                    Console.ResetColor();
                }

            } while (!isInt || value > assetList.Count - 1);
            // The count is 7 but index 0-6

            // Item from list 
            var itemToEdit = assetList[value];

            Console.WriteLine("Item to delete: " + itemToEdit.ToString());
            itemToEdit.DeleteItem();
        }

    }
}
