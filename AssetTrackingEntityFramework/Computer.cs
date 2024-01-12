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
        //public string Brand { get; set; }
        //public string Model { get; set; }
        //public DateTime PurchaseDate { get; set; }
        //public int Price { get; set; }
        //public DateTime EndOfLife { get; set; }

        public Computer() { }
        public Computer (string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = DateTime.Now;
            Price = price;
            EndOfLife = DateTime.Now.AddYears(3);
        }

        public override string ToString()
        {
            return $"{Brand.PadRight(15)} {Model.PadRight(15)} {Price.ToString().PadRight(15)} {PurchaseDate.ToShortDateString().PadRight(15)} {EndOfLife.ToShortDateString().PadRight(15)} {this.GetType().Name}";
        }
    }
}
