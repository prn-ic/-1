using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware.Models
{
    public class PickupPoint
    {
        [Key]
        public int PickupPointID { get; set; }
        public string? PickupPointIndex { get; set; }
        public string? PickupPointCity { get; set; }
        public string? PickupPointStreet { get; set; }
    }
}
