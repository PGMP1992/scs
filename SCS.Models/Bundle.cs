using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace SCS.Models;

public class Bundle
{
    public int Id { get; set; }
    public string Name { get; set; }

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
