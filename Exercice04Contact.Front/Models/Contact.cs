using System.ComponentModel.DataAnnotations;

namespace Exercice04Contact.Front.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom de famille ne doit pas dépasser 50 caractères.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Url(ErrorMessage = "L'URL de l'avatar doit être une URL valide.")]
        public string Avatar { get; set; } = "https://www.betonlandschaften.de/wp-content/uploads/2020/03/avatar_neutral.png";

        public string FullName => $"{FirstName} {LastName}";
    }

    public enum Gender { Homme, Femme, Autres }
}
