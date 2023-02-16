using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Models
{
    public class JoueurCreateViewModel
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Nom { get; set; } = null!;

        [StringLength(30)]
        public string Prenom { get; set; } = null!;

        [Required]
        public int NationaliteId { get; set; }

        [Required]
        public Sexe Sexe { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public int? Classement { get; set; }

        public JoueurCreateViewModel()
        {
            DateNaissance = DateTime.Now;
        }
    }
}
