using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class Resultat : Entity
    {
        [Required] public TimeSpan Duree;

        [Required] public DateTime Date;

        [Required] public int setsGagnesPourGagnant;
        [Required] public int setsGagnesPourPerdant;


        public Joueur Gagnant { get; set; } = null!;

        public Match? Match { get; set; }
    }
}
