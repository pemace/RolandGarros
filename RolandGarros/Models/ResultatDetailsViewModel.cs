using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Models
{
    public class ResultatDetailsViewModel
    {
           public int Id { get; init; }
           [Required]
        [Display(
            Name = "LabelResultatDuree",
            Prompt = "LabelResultatDureePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public TimeSpan Duree { get; init; }

            [Required]
        [Display(
            Name = "LabelMatchDate",
            Prompt = "LabelMatchDatePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public DateTime Date { get; init; }

            [Required]
        [Display(
            Name = "LabelResultatGagnant",
            Prompt = "LabelResultatGagnantPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public int setsGagnesPourGagnant { get; init; }
            [Required]
        [Display(
            Name = "LabelResultatSetsPerdants",
            Prompt = "LabelResultatSetsPerdantsPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public int setsGagnesPourPerdant { get; init; }


           public Joueur Gagnant { get; init; } = null!;

           public Match? Match { get; init; }

    }
}

