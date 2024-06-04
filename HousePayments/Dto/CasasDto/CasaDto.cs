
using System.Diagnostics.CodeAnalysis;

namespace HousePayments.Dto.CasasDto
{
    public class CasaDto
    {

        public int CasaId { get; set; }

        public string Nombre { get; set; }

        public int ResidenteId { get; set; }

        public int? SendaId { get; set; }

        public int? PoligonoId { get; set; }
    }
}
