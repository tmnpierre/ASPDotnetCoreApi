using System.ComponentModel.DataAnnotations;

namespace Exercice04Contact.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int Age => DateTime.Today.Year - DateOfBirth.Year - (DateTime.Today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);

        public Gender Gender { get; set; }

        [Url]
        public string? Avatar { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    public enum Gender { Homme, Femme, Autres }
}

