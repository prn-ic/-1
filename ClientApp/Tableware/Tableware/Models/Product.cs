using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware.Models
{
    public class Product
    {
        [Key]
        public string? ProductArticleNumber { get; set; }
        public string? ProductName { get; set; }
        public string? ProductUnit { get; set; }
        public int ProductCost { get; set; }
        public int ProductMaxDiscount { get; set; }
        public string? ProductProvider { get; set; }
        public string? ProductManufacturer { get; set; }
        public string? ProductCategory { get; set; }
        public int ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductPhoto { get; set; }
    }
}
