using System.ComponentModel.DataAnnotations;

namespace SCS.Models.ViewModels
{
    public class ContactVM
    {
      
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(250)]
        public string Message { get; set; } = string.Empty;
    }
}
