using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models;

public class OrderHeader
{
    public int Id { get; set; }

    [MaxLength(450)]
    public string AppUserId { get; set; }

    [ForeignKey("AppUserId")]
    [ValidateNever]
    public AppUser AppUser { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }

    [DataType(DataType.Currency)]
    public double OrderTotal { get; set; }

    [MaxLength(50)]
    public string? OrderStatus { get; set; }
    
    [MaxLength(50)]
    public string? PaymentStatus { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime PaymentDate { get; set; }

    // Needed for Stripe 
    public string? SessionId { get; set; }
    public string? PaymentIntentId { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
