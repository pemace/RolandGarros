using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace RolandGarros.Models
{
    public class MatchEditViewModel
    {
        public int Id { get; set; }
        [Required]

        [Display(
            Name = "LabelMatchJoueur1",
            Prompt = "LabelMatchJoueur1Prompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Joueur Joueur1 { get; set; } = null!;

        [Required]
        [Display(
            Name = "LabelMatchJoueur2",
            Prompt = "LabelMatchJoueur2Prompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Joueur Joueur2 { get; set; } = null!;

        [Required]
        [Display(
            Name = "LabelMatchArbitre",
            Prompt = "LabelMatchArbitrePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Arbitre Arbitre { get; set; } = null!;

        [Required]
        [Display(
            Name = "LabelMatchCourt",
            Prompt = "LabelMatchCourtPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Court Court { get; set; } = null!;

        [Required]
        [Display(
            Name = "LabelMatchDate",
            Prompt = "LabelMatchDatePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public DateTime Date { get; set; }

        [Required]
        [Display(
            Name = "LabelMatchSousTournoi",
            Prompt = "LabelMatchSousTournoiPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public SousTournoi SousTournoi { get; set; } = null!;

        [Display(
            Name = "LabelResultatDuree",
            Prompt = "LabelResultatDureePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public TimeSpan? Duree { get; set; }

        [Display(
            Name = "LabelResultatSetsGagnesJoueur1",
            Prompt = "LabelResultatSetsGagnesJoueur1Prompt",
        ResourceType = typeof(Properties.Resources)
            )]
        public int? SetsGagnesPourJoueur1 { get; set; }

        [Display(
            Name = "LabelResultatSetsGagnesJoueur2",
            Prompt = "LabelResultatSetsGagnesJoueur2Prompt",
        ResourceType = typeof(Properties.Resources)
            )]
        public int? SetsGagnesPourJoueur2 { get; set; }

        [Display(
            Name = "LabelResultatGagnant",
            Prompt = "LabelResultatGagnantPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Joueur? Gagnant { get; set; } = null!;
    }
}
