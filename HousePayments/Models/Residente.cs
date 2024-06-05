using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HousePayments.Models
{
    public class Residente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResidenteId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[67]\d{7}$", ErrorMessage = "Numero de telefono invalido")]
        public int Telefono { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Estado { get; set; } = true;
    }
}
