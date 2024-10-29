using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCS.Models;

public class ProductImage
{
    public int Id { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
    
    public bool StartImage { get; set; } = true;
    
    public int ProductId { get; set; }
    
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    
}
