using CamerasDb.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class Production: IObject
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Worker Worker { get; set; }
    }
}
