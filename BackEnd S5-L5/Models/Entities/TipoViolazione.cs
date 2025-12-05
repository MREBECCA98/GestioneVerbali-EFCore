using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_S5_L5.Models.Entities
{
    public class TipoViolazione
    {
        [Key]
        public Guid IdViolazione { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descrizione { get; set; }


        [InverseProperty(nameof(Verbale.TipoViolazione))]
        public List<Verbale> Verbali { get; set; }
    }
}
