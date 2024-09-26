using System.ComponentModel.DataAnnotations;

namespace SCS.Models
{
	public class Provider
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(50)]
		[Display(Name = "Contact Name")]
		public string? ContactName { get; set; }

		[MaxLength(50)]
		[EmailAddress]
		[Display(Name = "Contact Email")]
		public string? ContactEmail { get; set; }

		[MaxLength(20)]
		[Display(Name = "Contact Phone")]
		public string? ContactPhone { get; set; }
	}
}
