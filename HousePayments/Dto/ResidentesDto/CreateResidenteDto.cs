using System.ComponentModel.DataAnnotations;

namespace HousePayments.Dto.ResidentesDto
{
    public class CreateResidenteDto
    {
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Correo es obligatorio")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",ErrorMessage = "Correo invalido dto")]
        public string Email { get; set; }

        [RegularExpression(@"^[67]\d{7}$", ErrorMessage = "Numero de telefono invalido desde dto")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "La contrasena es obligatoria")]
        [MinLength(5,ErrorMessage ="Contrasena muy corta")]
        public string Password { get; set; }

        public bool Estado { get; set; } = true;
    }
}
