using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetContactsApp.Models
{
    //Contact Model
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(30, ErrorMessage = "Surname cannot be longer than 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(40, ErrorMessage = "Surname cannot be longer than 40 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DisplayName("Date of birth")]
        [DataType(DataType.Date)] // date, not a date-time
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone number format")]
        [MaxLength(12, ErrorMessage = "Phone number cannot be longer than 12 characters")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Category")]
        [RegularExpression("^(Buisness|Private|Other)$", ErrorMessage = "Invalid contact category")]
        public string contactCategory { get; set; } = "Private";

        [DisplayName("Subcategory")]
        [MaxLength(100, ErrorMessage = "Contact Subcategory cannot be longer than 100 characters")]
        public string? contactSubcategory { get; set; }
    }
}
