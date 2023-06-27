using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Deliveries
    {
        [Key]
        public int Deliveries_id { get; set; }
        public int? Customer_id { get; set; }
        public DateTime Date { get; set; }
    }
}
