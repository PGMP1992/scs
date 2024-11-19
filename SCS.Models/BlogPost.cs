
using System.ComponentModel.DataAnnotations;

namespace SCS.Models
{
	public  class BlogPost
	{
		public int Id { get; set; }
		[Required, MaxLength(100)]
		public string? Title { get; set; }
		[MaxLength(150)]
		public string? Slug { get; set; }
		[MaxLength(100)]
		public string? Image { get; set; }
		[Required, MaxLength(500)]
		public string? Introduction { get; set; }
		public string? Content { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Please select a valid category")]
		public int BlogCategoryId { get; set; }
		public string? UserId { get; set; }
		public bool IsPublished { get; set; }
		public int ViewCount { get; set; }
		public bool IsFeatured { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? PublishedAt { get; set; }

		public virtual BlogCategory BlogCategory { get; set; }
		public virtual AppUser User { get; set; }
	}
}
