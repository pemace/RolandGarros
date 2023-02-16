using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{

    public class Joueur : Personne
    {
        [Required] public Sexe Sexe { get; set; }
        [Required] public DateTime DateNaissance { get; set; }
        public int? Classement { get; set; }
    }
}
