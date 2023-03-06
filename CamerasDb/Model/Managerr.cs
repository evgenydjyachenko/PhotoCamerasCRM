using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class Managerr: IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public ICollection<Worker> Workers { get; set;  } = new List<Worker>(); 
        public override string ToString()
        {
            return $"Id: {Id} {Name} {SureName}";
        }
    }
}
