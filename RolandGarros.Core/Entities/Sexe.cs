using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public enum Sexe
    {
        [Display(Name = "Homme")]
        Homme,

        [Display(Name = "Femme")]
        Femme
    }
}