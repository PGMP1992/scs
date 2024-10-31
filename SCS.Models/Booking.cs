using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }

        [MaxLength(450)]
        public AppUser AppUser { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        public string VoucherKey { get; set; }

        //public Product Product { get; set; }
        //[ForeignKey(nameof(Product))]
        //public int ProductId { get; set; }
    }

}
