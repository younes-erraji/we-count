using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCount.Models
{
    public partial class Application
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required."), StringLength(25, MinimumLength = 1)]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required."), StringLength(25, MinimumLength = 1)]
        [Display(Name = "Nom")]
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
    }
}
