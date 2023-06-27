using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ShoppingOrder
    {

        [Key]
        public int Order_id { get; set; }
        public int? Customer_id { get; set; }
        public DateTime Date { get; set; }
    }
}
