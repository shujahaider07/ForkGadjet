using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesViewModels
{
    public class DeliveryVM
    {

        [Display(Name = "Delivery")]
        public int Deliveries_id { get; set; }
        [Display(Name = "Customer")]
        public string? Customer_Name { get; set; }
        public int? Customer_id { get; set; }
        public DateTime Date { get; set; }
    }
}
