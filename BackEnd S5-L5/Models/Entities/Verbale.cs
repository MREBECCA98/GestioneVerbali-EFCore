using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_S5_L5.Models.Entities
{
    public class Verbale
    {
        [Key]
        public Guid IdVerbale { get; set; }

        [Required]
        public DateTime DataViolazione { get; set; }

        [Required]
        [MaxLength(100)]
        public string IndirizzoViolazione { get; set; }

        [Required]
        [MaxLength(100)]
        public string NominativoAgente { get; set; }

        [Required]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [Required]
        public decimal Importo { get; set; }

        [Required]
        [Range(0, 20)]
        public int DecurtamentoPunti { get; set; }

        [Required]
        public Guid IdAnagraficaFk { get; set; }

        [Required]
        public Guid IdViolazioneFk { get; set; }


        [ForeignKey(nameof(IdViolazioneFk))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public TipoViolazione TipoViolazione { get; set; }

        [ForeignKey(nameof(IdAnagraficaFk))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Anagrafica Anagrafica { get; set; }
    }
}
