using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class SousTournoi : Entity
    {
        [StringLength(30)]
        public string Nom { get; set; } = null!;
        [Required] public DateTime DateDebut { get; set; }
        [Required] public DateTime DateFin { get; set; }
        [Required] public TypeSousTournoi TypeSousTournoi;

        public Joueur? Gagnant { get; set; }
    }
}
