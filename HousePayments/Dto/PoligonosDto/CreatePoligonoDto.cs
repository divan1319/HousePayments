using System.ComponentModel.DataAnnotations;

namespace HousePayments.Dto.PoligonosDto
{
    public class CreatePoligonoDto
    {

        [Required(ErrorMessage = "El nombre es requerido, create poligono dto")]
        [MinLength(5, ErrorMessage = "El nombre es muy corto, min 5")]
        public string Nombre { get; set; }
    }
}
