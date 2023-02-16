using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Entities
{
    public class Pays : Entity
    {
        public int Code { get; set; }
        public string Alpha2 { get; set; } = null!;
        public string Alpha3 { get; set; } = null!;
        public string NomEnGb { get; set; } = null!;
        public string NomFrFr { get; set; } = null!;
    }
}
