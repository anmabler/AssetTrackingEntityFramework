using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal class Phone: Asset
    {
        public int Id { get; set; }

        public Phone () { }

        public Phone(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
            PurchaseDate = DateTime.Now;
            EndOfLife = DateTime.Now.AddYears(3);
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

            var assetFromDb = db.Phones.FirstOrDefault(x => x.Id == Id);

            var brand = brandInput.Length < 1 ? Brand : brandInput;

            var model = modelInput.Length < 1 ? Model : modelInput;

            int.TryParse(priceInput, out var price);

            assetFromDb.Brand = brand;
            assetFromDb.Model = model;
            assetFromDb.Price = price;

            db.Phones.Update(assetFromDb);
            db.SaveChanges();
        }
    }
}
