using CamerasDb.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class SparePart: IObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Product Product { get; set; }
        //public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
