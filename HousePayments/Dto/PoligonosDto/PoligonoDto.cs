using System.ComponentModel.DataAnnotations;

namespace HousePayments.Dto.PoligonosDto
{
    public class PoligonoDto
    {
        [Required]
        public int PoligonoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido, poligono dto")]
        public string Nombre { get; set; }
    }
}
