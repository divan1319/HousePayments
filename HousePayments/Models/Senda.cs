using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HousePayments.Models
{
    public class Senda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SendaId { get; set; }
        public string Nombre { get; set; }


        public ICollection<SendaPoligono> SendaPoligonos { get; set; }
    }
}
