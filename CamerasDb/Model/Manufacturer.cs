using CamerasDb.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class Manufacturer: IObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Production> Productions { get; set; } = new List<Production>();
        public ICollection<SparePart> SpareParts { get; set; } = new List<SparePart>();
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
