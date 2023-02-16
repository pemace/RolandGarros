using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class Court : Entity
    {
        [StringLength(30)] public string Nom { get; set; } = null!;
        [Required] public int Numero { get; set; }

    }
}
