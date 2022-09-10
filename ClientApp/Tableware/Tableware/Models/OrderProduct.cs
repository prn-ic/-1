using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderID { get; set; }
        public Product? ProductArticleNumber { get; set; }
    }
}
