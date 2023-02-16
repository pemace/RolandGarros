using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class Match : Entity
    {
        public Joueur? Joueur1 { get; set; }
        public Joueur? Joueur2 { get; set; }
        [Required] public Arbitre Arbitre { get; set; } = null!;
        [Required] public Court Court { get; set; } = null!;
        [Required] public DateTime Date { get; set; }
        public SousTournoi? SousTournoi { get; set; }
    }
}
