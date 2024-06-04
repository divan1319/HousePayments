using System.ComponentModel.DataAnnotations;

namespace HousePayments.Dto.ResidentesDto
{
    public class ResidenteDto
    {
        public int ResidenteId { get; set; }


        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }


        [RegularExpression(@"^[67]\d{7}$", ErrorMessage = "Numero de telefono invalido")]
        public int Telefono { get; set; }


        [StringLength(500)]
        public string Password { get; set; }
    }
}
