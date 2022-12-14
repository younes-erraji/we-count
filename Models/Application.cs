using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCount.Models
{
    public partial class Application
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(25, MinimumLength = 1)]
        [Display(Name = "Prénom")]
        [RegularExpression("^[a-zA-Z0-9 ]+$")]
        public string FirstName { get; set; }
        [Required, StringLength(25, MinimumLength = 1)]
        [Display(Name = "Nom")]
        [RegularExpression("^[a-zA-Z0-9 ]+$")]
        public string LastName { get; set; }

        public string Slag { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Téléphone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Niveau D'etude")]
        public string StudyLevel { get; set; }

        [Range(1, 100)]
        [Display(Name = "Nombre d’années d’expérience")]
        public int YearsOfExperinces { get; set; }
        [Required]
        [Display(Name = "Dernier employeur")]
        public string LastJob { get; set; }

        [Display(Name = "CV")]
        public string Resume { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public partial class Application
    {
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public string GetExtension()
        {
            string extension = Resume.Substring(Resume.LastIndexOf("."));
            return extension;
        }
    }
}
