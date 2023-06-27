using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntitiesViewModels
{
    public class ShoppingVm
    {
       
        public int Order_id { get; set; }

        [Display(Name = "Customer Name")]
        public string? First_Name { get; set; }
        public DateTime date { get; set; }
    }
}
