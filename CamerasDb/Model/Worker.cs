using CamerasDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class Worker: IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        // public Access Access { get; set; }
        public virtual Managerr Manager { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<Production> Productions { get; set; } = new List<Production>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"Id: {Id} {Name} {SureName}";
        }
    }
}

