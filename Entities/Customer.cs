using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string? First_Name { get; set; }
        [Display(Name = "Last Name")]
        public string? Last_Name { get; set; }
        [Display(Name = "Gender")]
        public string? gender { get; set; }
        [Display(Name = "Age")]
        public string? Age { get; set; }
        [Display(Name = "Contact")]
        public string? contact { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        public int? IsDelete{ get; set; }


       
    }
}