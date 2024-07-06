using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RicckyStore.Models
{
    public class ProduitDto
    {
        [Required, MaxLength(100)]
        public string nom { get; set; } = "";

        [Required, MaxLength(100)]
        public string marque { get; set; } = "";

        [Required, MaxLength(100)]
        public string categorie { get; set; } = "";

        [Required]
        public decimal prix { get; set; }

        [Required]
        public string description { get; set; } = "";

        public IFormFile? imageFichierNom { get; set; }

    }
}
