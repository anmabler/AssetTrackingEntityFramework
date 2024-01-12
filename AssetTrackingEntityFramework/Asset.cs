using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal abstract class Asset
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public DateTime EndOfLife { get; set; }

        public abstract void EditItem();
        public abstract void DeleteItem();
        
    }
}
