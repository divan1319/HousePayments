using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePayments.Migrations
{
    /// <inheritdoc />
    public partial class nuevo_campo_tbl_residente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Residentes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Residentes");
        }
    }
}
