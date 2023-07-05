using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        
        [Key]
        public int Category_id { get; set; }
        public string? Category_Name  { get; set; }
        public string? Category_Type { get; set; }
        public int? IsDelete { get; set; }
       
    }
}
