using System.ComponentModel.DataAnnotations;

namespace HousePayments.Dto.ResidentesDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Correo es obligatorio")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Correo invalido dto login")]
        public string Email { get; set; }


        [Required(ErrorMessage = "La contrasena es obligatoria")]
        public string Password { get; set; }
    }
}
