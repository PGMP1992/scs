using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace SCS.Models;

public class Bundle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Range(1, 100000, ErrorMessage = "Please enter a value between 1 and 100,000.00")]
    [DisplayFormat()]
    [DataType(DataType.Currency)]
    public double Price { get; set; }
    
    public int? ProductId1 { get; set; }

    [ValidateNever]
    [NotMapped]
    public Product Product1 { get; set; }
    
    public int? ProductId2 { get; set; }

    [ValidateNever]
    [NotMapped]
    public Product Product2 { get; set; }
    
    public int? ProductId3 { get; set; }

    [ValidateNever]
    [NotMapped]
    public Product Product3 { get; set; }


}
