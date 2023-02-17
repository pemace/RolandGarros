using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Models
{
    public class MatchsListViewModel
    {
        public int Id { get; set; }
        [Required]
        public Joueur Joueur1 { get; set; } = null!;

        [Required]
        public Joueur Joueur2 { get; set; } = null!;

        [Required]
        public Arbitre Arbitre { get; set; } = null!;

        [Required]
        public Court Court { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public SousTournoi SousTournoi { get; set; } = null!;


        public TimeSpan? Duree;
        public int? SetsGagnesPourJoueur1;
        public int? SetsGagnesPourJoueur2;
        public Joueur? Gagnant { get; set; } = null!;

    }
}
