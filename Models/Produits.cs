using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RicckyStore.Models
{
    public class Produits
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string nom { get; set; } = "";

        [MaxLength(100)]
        public string marque { get; set; } = "";

        [MaxLength(100)]
        public string categorie { get; set; } = "";

        [Precision(16, 2)]
        public decimal prix {  get; set; }

        public string description { get; set; } = "";

        [MaxLength(100)]
        public string imageFichierNom { get; set; } = "";

        public DateTime dateAjout { get; set; }
    }
}
