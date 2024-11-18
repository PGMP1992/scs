using System.ComponentModel.DataAnnotations;

namespace SCS.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [MaxLength(450)]
        public string AppUserId { get; set; } = string.Empty;

        public AppUser AppUser { get; set; }  

        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        public string VoucherKey { get; set; } = string.Empty;
    }

}
