using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HousePayments.Models
{
    public class Poligono
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PoligonoId { get; set; }
        public string Nombre { get; set; }


       public ICollection<SendaPoligono> SendaPoligonos { get; set; }
    }
}
