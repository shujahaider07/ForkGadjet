using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Seller
    {
        [Key]
        public int Seller_id { get; set; }
        public int? Product_id { get; set; }
        public string? Name { get; set; }
    }
}
