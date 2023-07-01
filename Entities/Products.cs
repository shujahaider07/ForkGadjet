using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int? Category_Id { get; set; }
        public string? Product_Name{ get; set; }
        public int? IsDelete{ get; set; }
    


    }
}
