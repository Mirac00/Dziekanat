using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dziekanat.Models
{
    public class Course
    {
        internal object Students;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(120)]
        public string Name { get; set; }
        [MaxLength(600)]
        public string? Description { get; set; } = string.Empty;
        [Range(1, 8, ErrorMessage = "Wartość dla pola {0} musi być większa od {1} lub mniejsza od {2}.")]
        public decimal ECTSPoints { get; set; }
        [Required]
        public int Hours { get; set; }
        /* do uzupełnienia */
        public ICollection<Enrollment> Enrollements { get; set; }
    }
}
