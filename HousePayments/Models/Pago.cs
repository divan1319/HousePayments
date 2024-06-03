using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HousePayments.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }

        public int CasaId { get; set; }

        public DateTime FechaPago { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Cuota { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Mora { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [ForeignKey("CasaId")]
        public virtual Casa Casa { get; set; }

    }
}
