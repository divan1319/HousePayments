using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HousePayments.Models
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreUsuario { get; set; }

        [Required]
        [RegularExpression(@"^[67]\d{7}$",ErrorMessage = "Numero de telefono invalido")]
        public int Telefono { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }


    }
}
