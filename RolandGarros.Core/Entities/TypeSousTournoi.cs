using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RolandGarros.Entities
{
    public enum TypeSousTournoi
    {
        [Display(Name = "Simple messieurs")]
        SimpleMessieurs,
        [Display(Name = "Simple dames")]
        SimpleDames,
        [Display(Name = "Double messieurs")]
        DoubleMessieurs,
        [Display(Name = "Double dames")]
        DoubleDames,
        [Display(Name = "Double mixte")]
        DoubleMixte,

        [Display(Name = "Simple junior garçons et Filles")]
        SimpleJunior,
        [Display(Name = "Double junior garçons et Filles")]
        DoubleJunior
    }
}