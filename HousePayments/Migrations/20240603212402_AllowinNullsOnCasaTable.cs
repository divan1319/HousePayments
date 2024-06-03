using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePayments.Migrations
{
    /// <inheritdoc />
    public partial class AllowinNullsOnCasaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Poligonos_PoligonoId",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Sendas_SendaId",
                table: "Casas");

            migrationBuilder.AlterColumn<int>(
                name: "SendaId",
                table: "Casas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PoligonoId",
                table: "Casas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Poligonos_PoligonoId",
                table: "Casas",
                column: "PoligonoId",
                principalTable: "Poligonos",
                principalColumn: "PoligonoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Sendas_SendaId",
                table: "Casas",
                column: "SendaId",
                principalTable: "Sendas",
                principalColumn: "SendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Poligonos_PoligonoId",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Sendas_SendaId",
                table: "Casas");

            migrationBuilder.AlterColumn<int>(
                name: "SendaId",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoligonoId",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Poligonos_PoligonoId",
                table: "Casas",
                column: "PoligonoId",
                principalTable: "Poligonos",
                principalColumn: "PoligonoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Sendas_SendaId",
                table: "Casas",
                column: "SendaId",
                principalTable: "Sendas",
                principalColumn: "SendaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
