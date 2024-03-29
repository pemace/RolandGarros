﻿using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public abstract class Personne : Entity
    {
        [StringLength(30)] public string Nom { get; set; } = null!;
        [StringLength(30)] public string Prenom { get; set; } = null!;
        [Required] public Pays Nationalite { get; set; } = null!;
        public int NationaliteId { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
