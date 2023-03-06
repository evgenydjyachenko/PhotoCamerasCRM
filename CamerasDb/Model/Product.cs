using CamerasDb.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class Product: IObject
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<Production> Productions { get; set; } = new List<Production>();
        public ICollection<SparePart> SpareParts { get; set; } = new List<SparePart>();

        public override string ToString()
        {
            return $"{ModelName} {Price}";
        }
    }
}
