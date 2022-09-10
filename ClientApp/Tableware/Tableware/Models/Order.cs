using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string? OrderComposition { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }
        public PickupPoint? OrderPickupPoint { get; set; }
        public string? ClientName { get; set; }
        public int OrderCode { get; set; }
        public string? OrderStatus { get; set; }
        
    }


}
