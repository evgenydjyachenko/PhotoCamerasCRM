using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; } = DateTime.Now.Date;
        public DateTime CloseDate { get; set; }
        public string Status { get; set; }  
        public Worker Worker { get; set; }
        public override string ToString()
        {
            return $"Id заказа {OrderId} \nТип заказа: {Name} \nДата открытия: {OpenDate.ToShortDateString()}\n Дата выполнения: {CloseDate.ToShortDateString()}\n ";
        }
    }
}
