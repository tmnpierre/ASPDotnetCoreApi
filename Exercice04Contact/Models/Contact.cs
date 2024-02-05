namespace Exercice04Contact.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DateOfBirth { get; set; }
        public int Age { get; set; }
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }
    }

    public enum Gender { Homme, Femme, Autres}
}
