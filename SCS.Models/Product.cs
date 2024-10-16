using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SCS.Utility;

namespace SCS.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    [Required]
    public string? Description { get; set; }

    [Range(1, 100000, ErrorMessage = "Please enter a value between 1 and 100,000.00")]
    [DisplayFormat()]
    [DataType(DataType.Currency)]
    public double Price { get; set; }
    
    public string Status { get; set; } = SD.ProductStatusRegistrated;
    public int CategoryId { get; set; }
    
    [ForeignKey(nameof(CategoryId))]
    [ValidateNever]
    public Category Category { get; set; }

    public int? ProviderId { get; set; }
    
    [ForeignKey(nameof(ProviderId))]
    [ValidateNever]
    public Provider Provider { get; set; }

    public int? BundleId { get; set; }
    
    [ForeignKey(nameof(BundleId))]
    [ValidateNever]
    public Bundle Bundle { get; set; }

    public int? CertSlotId { get; set; }

    [ForeignKey(nameof(CertSlotId))]
    [ValidateNever]
    public CertificationSlot CertificationSlot { get; set; }
    
    //public string? VoucherKey { get; set; } - Does not need that as Order creates VoucherKey

    [ValidateNever]
    public List<ProductImage> ProductImages { get; set; }
}