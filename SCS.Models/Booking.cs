using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
        
        public DateOnly Date { get; set; }

        public string VoucherKey { get; set; }
    }

}
