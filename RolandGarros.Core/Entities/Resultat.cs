using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class Resultat : Entity
    {
        [Required] public TimeSpan Duree { get; set; }

        [Required] public DateTime Date { get; set; }

        [Required] public int setsGagnesPourGagnant { get; set; }
        [Required] public int setsGagnesPourPerdant { get; set; }


        public Joueur Gagnant { get; set; } = null!;

        public Match? Match { get; set; }
    }
}
