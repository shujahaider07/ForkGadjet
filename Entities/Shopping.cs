using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Shopping
    {

        [Key]
        public int Order_id { get; set; }

        [Display(Name = "Customer Name")]
        public int? Customer_Id { get; set; }
        public DateTime date { get; set; }

    }
}
