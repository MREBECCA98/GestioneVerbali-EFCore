using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_S5_L5.Models.Entities
{
    public class Anagrafica
    {
        [Key]
        public Guid IdAnagrafica { get; set; }
        [Required]
        [MaxLength(50)]
        public string Cognome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Indirizzo { get; set; }

        [Required]
        [MaxLength(20)]
        public string Citta { get; set; }

        [Required]
        [MaxLength(5)]
        public string Cap { get; set; }

        [Required]
        [MaxLength(16)]
        public string CodiceFiscale { get; set; }


        [InverseProperty(nameof(Verbale.Anagrafica))]
        public List<Verbale> Verbali { get; set; }
    }
}
