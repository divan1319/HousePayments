using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HousePayments.Models
{
    public class Casa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CasaId { get; set; }

        public string Nombre { get; set; }

        public int ResidenteId { get; set; }

        [AllowNull]
        public int? SendaId { get; set; }

        [AllowNull]
        public int? PoligonoId { get; set; }

        [ForeignKey("ResidenteId")]
        public virtual Residente Residente { get; set; }

        [ForeignKey("SendaId")]
        public virtual Senda Senda { get; set; }

        [ForeignKey("PoligonoId")]
        public virtual Poligono Poligono { get; set; }

    }
}
