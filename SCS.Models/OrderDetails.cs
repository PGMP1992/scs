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

    public string? VoucherKey { get; set; }

    public int? BookCount {  get; set; }
    
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
    
    [Display(Name = "Total")]
    public int Count { get; set; }
    
    [Display(Name = "Price")]
    public double Price { get; set; }
}

