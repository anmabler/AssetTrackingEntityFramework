using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public DateTime EndOfLife { get; set; }

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
            return $"{Brand} {Model} {Price} {PurchaseDate} {EndOfLife} {this.GetType().Name}";
        }
    }
}
