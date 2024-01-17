using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal class Computer : Asset
    {
        public int Id { get; set; }
        public Computer() { }
        public Computer (string brand, string model, int price, int officeId)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = DateTime.Now;
            Price = price;
            EndOfLife = DateTime.Now.AddYears(3);
            OfficeId = officeId;
        }

        public override string ToString()
        {
            return $"{Brand.PadRight(15)} {Model.PadRight(15)} {Price.ToString().PadRight(15)} {PurchaseDate.ToShortDateString().PadRight(15)} {EndOfLife.ToShortDateString().PadRight(15)} {this.GetType().Name}";
        }

        public override void EditItem()
        {
            MyDbContext db = new MyDbContext();

            Console.Write("Enter new brand: ");
            string brandInput = Console.ReadLine();

            Console.Write("Enter new model: ");
            string modelInput = Console.ReadLine();

            Console.Write("Enter new price: ");
            string priceInput = Console.ReadLine();

            var assetFromDb = db.Computers.FirstOrDefault(x => x.Id == Id);

            var brand = brandInput.Length < 1 ? Brand : brandInput;

            var model = modelInput.Length < 1 ? Model : modelInput;

            int.TryParse(priceInput, out var price);

            assetFromDb.Brand = brand;
            assetFromDb.Model = model;
            assetFromDb.Price = price;

            db.Computers.Update(assetFromDb);
            db.SaveChanges();
        }
        public override void DeleteItem()
        {
            MyDbContext ctx = new MyDbContext();
            Console.Write("Are you sure you want to delete (y/n)?");
            string input = Console.ReadLine();

            if (input.ToLower() == "n") return;

            else if( input.ToLower() == "y")
            {
                var computer = ctx.Computers.FirstOrDefault(c => c.Id == Id);
                ctx.Computers.Remove(computer);
                ctx.SaveChanges();
                Console.WriteLine("Asset deleted");
            }
            else {
                Console.WriteLine("Enter a valid value.");
            }
        }
    }
}
