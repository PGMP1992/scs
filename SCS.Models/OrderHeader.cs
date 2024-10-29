using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models;

public class OrderHeader
{
    public int Id { get; set; }

    public string AppUserId { get; set; }

    [ForeignKey("AppUserId")]
    [ValidateNever]
    public AppUser AppUser { get; set; }

    public DateTime OrderDate { get; set; }
    public double OrderTotal { get; set; }
    public string? OrderStatus { get; set; }

    public string? PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }

    // Needed for Stripe 
    public string? SessionId { get; set; }
    public string? PaymentIntentId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
