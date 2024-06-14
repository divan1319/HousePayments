using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePayments.Migrations
{
    /// <inheritdoc />
    public partial class AddingCasaIdtoSendaPoligonoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CasaId",
                table: "SendaPoligonos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SendaPoligonos_CasaId",
                table: "SendaPoligonos",
                column: "CasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SendaPoligonos_Casas_CasaId",
                table: "SendaPoligonos",
                column: "CasaId",
                principalTable: "Casas",
                principalColumn: "CasaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SendaPoligonos_Casas_CasaId",
                table: "SendaPoligonos");

            migrationBuilder.DropIndex(
                name: "IX_SendaPoligonos_CasaId",
                table: "SendaPoligonos");

            migrationBuilder.DropColumn(
                name: "CasaId",
                table: "SendaPoligonos");
        }
    }
}
