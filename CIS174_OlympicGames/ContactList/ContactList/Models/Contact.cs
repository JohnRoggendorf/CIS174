using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ContactList.Models
{
    public class Contact
    {
        // EF Core will configure the database to generate this value
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a number.")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "Phone number shouldbe between 7 and 10 digits.")]
        public string Number { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an Address.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a note.")]
        public string Note { get; set; } = string.Empty;

        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Number?.ToString();
    }
}
