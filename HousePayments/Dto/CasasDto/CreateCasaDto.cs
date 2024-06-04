

namespace HousePayments.Dto.CasasDto
{
    public class CreateCasaDto
    {
        public string Nombre { get; set; }

        public int ResidenteId { get; set; }

        public int? SendaId { get; set; }

        public int? PoligonoId { get; set; }
    }
}
