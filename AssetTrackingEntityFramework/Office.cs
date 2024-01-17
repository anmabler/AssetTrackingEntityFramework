using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal class Office
    {
        public int Id { get; set; }
        public string Country {  get; set; }
        public string Currency {  get; set; }
        public float CurrencyRate { get; set; }
        public List<Phone> PhonesList { get; set; }
        public List<Computer> ComputersList { get; set; }

        public static List<Office> getOfficesFromDb()
        {
            MyDbContext db = new MyDbContext();
            var dbOffices = db.Offices.ToList();
            return dbOffices;
        }

    }
}
