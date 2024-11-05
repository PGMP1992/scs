using System.ComponentModel.DataAnnotations;

namespace SCS.Models
{
	public class Provider
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Contact Name")]
		public string? ContactName { get; set; }

		[MaxLength(50)]
		[EmailAddress]
		[Display(Name = "Email")]
		public string? ContactEmail { get; set; }

		[MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
		public string? ContactPhone { get; set; }
	}
}
