using System.ComponentModel.DataAnnotations;

namespace SCS.Models.ViewModels
{
    public class ContactVM
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string From { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(250)]
        public string Subject { get; set; }
    }
}
