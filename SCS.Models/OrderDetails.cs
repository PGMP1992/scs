using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCS.Models;

public class OrderDetails
{
    public int Id { get; set; }
    
    [Required]
    public int OrderHeaderId { get; set; }
    
    [ForeignKey("OrderHeaderId")]
    [ValidateNever]
    public OrderHeader OrderHeader { get; set; }
    
    [Required]
    public int ProductId { get; set; }

    [MaxLength(30)]
    public string? VoucherKey { get; set; }

    public int? BookCount {  get; set; }
    
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
    
    [Display(Name = "Qty")]
    public int Count { get; set; }
    
    [Display(Name = "Price")]
    [DataType(DataType.Currency)]
    public double Price { get; set; }
}

