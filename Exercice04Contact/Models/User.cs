using System.ComponentModel.DataAnnotations;

namespace Exercice04Contact.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Prénom")] 
        [Required(ErrorMessage = "Prénom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le prénom doit être compris entre 3 et 30 caractères.")]
        public string? FirstName { get; set; }

        [Display(Name = "Nom")] 
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        public string? LastName { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Date de naissance manquante")]
        [DataType(DataType.Date, ErrorMessage = "Format de date invalide (dd-mm-yyyy)")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")] 
        [Required(ErrorMessage = "Email Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "L'Email doit avoir le format classique d'un email")]
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Email Invalide !")]
        public string? Email { get; set; }

        [Display(Name = "Mot de passe")] 
        [Required(ErrorMessage = "Mot de passe Manquant")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Le mot de passe doit être compris entre 8 et 30 caractères.")]
        [RegularExpression(@"^(?=.*[a-z].*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*[\W_].*[\W_].*[\W_]).{8,}$", ErrorMessage = "Le mot de passe doit contenir au moins deux minuscules, deux majuscules, deux chiffres et trois caractères spéciaux.")]
        public string? Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
