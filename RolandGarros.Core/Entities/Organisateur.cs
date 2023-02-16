using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class Organisateur : Personne
    {
        [StringLength(30)] public string Identifiant { get; set; } = null!;
        [StringLength(30)] public string MotDePasse { get; set; } = null!;
    }
}
