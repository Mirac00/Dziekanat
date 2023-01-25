using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dziekanat.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; } = "mgr";

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; } = string.Empty;
    }
}
