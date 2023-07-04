using Entities;
using System.ComponentModel.DataAnnotations;

namespace EntitiesViewModels
{
    public class CustomerVM
    {
        
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
        public bool? IsDelete{ get; set; }


        public Customer vmToEntity(CustomerVM customer)
        {
            return new Customer
            {
                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                Age = customer.Age,
                contact = customer.contact,
                gender = customer.gender,
                Email = customer.Email, 
                 
            };

        }


        

    }
}
