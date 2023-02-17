using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Models
{
    public class JoueurCreateViewModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(30)]
        [Display(
            Name ="LabelJoueurNom",
            Prompt ="LabelJoueurNomPrompt",
            ResourceType =typeof(Properties.Resources)
            )]
        public string Nom { get; init; } = null!;

        [Required]
        [StringLength(30)]
        [Display(
            Name = "LabelJoueurPrenom",
            Prompt = "LabelJoueurPrenomPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public string Prenom { get; init; } = null!;

        [Required]
        [Display(
            Name = "LabelJoueurNationalite",
            Prompt = "LabelJoueurNationalitePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public int NationaliteId { get; init; }

        [Required]
        [Display(
            Name = "LabelJoueurSexe",
            Prompt = "LabelJoueurSexePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public Sexe Sexe { get; init; }

        [Required]
        [Display(
            Name = "LabelJoueurDateNaissance",
            Prompt = "LabelJoueurDateNaissancePrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public DateTime DateNaissance { get; init; }

        [Display(
            Name = "LabelJoueurClassement",
            Prompt = "LabelJoueurClassementPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public int? Classement { get; init; }

        [DataType(DataType.Upload)]
        [Display(
            Name = "LabelJoueurPhoto", 
            Prompt = "LabelJoueurPhotoPrompt",
            ResourceType = typeof(Properties.Resources)
            )]
        public IFormFile Photo { get; init; } = null!;

        public JoueurCreateViewModel()
        {
            DateNaissance = DateTime.Now;
        }
    }
}
