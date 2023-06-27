using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public int? category_id { get; set; }
        public DateTime Date{ get; set; }
    }
}
