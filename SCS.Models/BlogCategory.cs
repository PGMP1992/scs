
using System.ComponentModel.DataAnnotations;

namespace SCS.Models;

    public class BlogCategory
{
	public int Id { get; set; }
	[Required, MaxLength(50)]
	public string Name { get; set; }
	[MaxLength(75)]
	public string Slug { get; set; }
	public bool ShowOnNavbar { get; set; }
	public BlogCategory Clone() => (MemberwiseClone() as BlogCategory)!;
	
}