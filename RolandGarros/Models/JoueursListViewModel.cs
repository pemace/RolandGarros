using RolandGarros.Entities;
using System.ComponentModel.DataAnnotations;

namespace RolandGarros.Models
{
	public class JoueursListViewModel
	{
		public int Id { get; set; }

		[StringLength(30)] 
		public string Nom { get; set; } = null!;

		[StringLength(30)] 
		public string Prenom { get; set; } = null!;

		[Required] 
		public Pays Nationalite { get; set; } = null!;

		public int NationaliteId { get; set; }

		public string? PhotoUrl { get; set; }

		[Required] 
		public Sexe Sexe { get; set; }

		[Required] 
		public DateTime DateNaissance { get; set; }

		public int? Classement { get; set; }
	}
}
