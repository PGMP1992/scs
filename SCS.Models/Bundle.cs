using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SCS.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models;

public class Bundle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required]
    [Range(1, 100000)]
    public double Price { get; set; }

    [Required]
    //[NoProductRepeat(ErrorMessage = "Wrong")]
    public int? ProductId1 { get; set; }
    
    [ValidateNever]
    [NotMapped]
    public Product Product1 { get; set; }

    [Required]
    //[NoProductRepeat(ErrorMessage = "Wrong")]
    public int? ProductId2 { get; set; }

    [ValidateNever]
    [NotMapped]
    public Product Product2 { get; set; }

    //[NoProductRepeat(ErrorMessage = "Wrong")]
    public int? ProductId3 { get; set; }

    [ValidateNever]
    [NotMapped]
    public Product Product3 { get; set; }
}
