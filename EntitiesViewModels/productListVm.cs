using System.ComponentModel.DataAnnotations;

namespace EntitiesViewModels
{
    public class productListVm
    {
        public int ProductId { get; set; }
        public string? Category_Name { get; set; }
        public string? Product_Name { get; set; }
    }
}