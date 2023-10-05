
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }

    public class TempOrderTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Food")]
        public int FoodId { get; set; }

        public int Qty { get; set; }

        [Precision(18, 2)]
        public decimal SubTotalPrice { get; set; }
    }

    public class OrderTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Food")]
        public int FoodId{ get; set; }

        public int Qty { get; set; }

        [Precision(18, 2)]
        public decimal SubTotalPrice { get; set; }
    }
}
