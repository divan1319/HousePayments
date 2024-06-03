using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HousePayments.Models
{
    public class SendaPoligono
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SendaPoligonoId { get; set; }

        public int SendaId { get; set; }

        public int PoligonoId { get; set; }

        [ForeignKey("SendaId")]
        public virtual Senda Senda { get; set; }

        [ForeignKey("PoligonoId")]
        public virtual Poligono Poligono{ get; set; }

    }
}
