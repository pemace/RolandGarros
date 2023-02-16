using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace RolandGarros.Models
{
    public class JoueurDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(
            Name = "LabelJoueurNom",
            Prompt = "LabelJoueurNomPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public string Nom { get; set; } = null!;

        [Required]
        [StringLength(30)]
        [Display(
            Name = "LabelJoueurPrenom",
            Prompt = "LabelJoueurPrenomPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public string Prenom { get; set; } = null!;

        [Required]
        [Display(
            Name = "LabelJoueurNationalite",
            Prompt = "LabelJoueurNationalitePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public string Nationalite { get; set; } = null!;

        [Required]
        [Display(
            Name = "LabelJoueurSexe",
            Prompt = "LabelJoueurSexePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Sexe Sexe { get; set; }

        [Required]
        [Display(
            Name = "LabelJoueurDateNaissance",
            Prompt = "LabelJoueurDateNaissancePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public DateTime DateNaissance { get; set; }

        [Display(
            Name = "LabelJoueurClassement",
            Prompt = "LabelJoueurClassementPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public int? Classement { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
