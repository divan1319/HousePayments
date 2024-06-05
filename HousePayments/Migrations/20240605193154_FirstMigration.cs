using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HousePayments.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administradors",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradors", x => x.AdminId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Poligonos",
                columns: table => new
                {
                    PoligonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poligonos", x => x.PoligonoId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    ResidenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false,defaultValue:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentes", x => x.ResidenteId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sendas",
                columns: table => new
                {
                    SendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sendas", x => x.SendaId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Casas",
                columns: table => new
                {
                    CasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    ResidenteId = table.Column<int>(type: "int", nullable: false),
                    SendaId = table.Column<int>(type: "int", nullable: true),
                    PoligonoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.CasaId);
                    table.ForeignKey(
                        name: "FK_Casas_Poligonos_PoligonoId",
                        column: x => x.PoligonoId,
                        principalTable: "Poligonos",
                        principalColumn: "PoligonoId");
                    table.ForeignKey(
                        name: "FK_Casas_Residentes_ResidenteId",
                        column: x => x.ResidenteId,
                        principalTable: "Residentes",
                        principalColumn: "ResidenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casas_Sendas_SendaId",
                        column: x => x.SendaId,
                        principalTable: "Sendas",
                        principalColumn: "SendaId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SendaPoligonos",
                columns: table => new
                {
                    SendaPoligonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SendaId = table.Column<int>(type: "int", nullable: false),
                    PoligonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendaPoligonos", x => x.SendaPoligonoId);
                    table.ForeignKey(
                        name: "FK_SendaPoligonos_Poligonos_PoligonoId",
                        column: x => x.PoligonoId,
                        principalTable: "Poligonos",
                        principalColumn: "PoligonoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendaPoligonos_Sendas_SendaId",
                        column: x => x.SendaId,
                        principalTable: "Sendas",
                        principalColumn: "SendaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CasaId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cuota = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Mora = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Casas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Casas",
                        principalColumn: "CasaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_PoligonoId",
                table: "Casas",
                column: "PoligonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_ResidenteId",
                table: "Casas",
                column: "ResidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_SendaId",
                table: "Casas",
                column: "SendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_CasaId",
                table: "Pagos",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_SendaPoligonos_PoligonoId",
                table: "SendaPoligonos",
                column: "PoligonoId");

            migrationBuilder.CreateIndex(
                name: "IX_SendaPoligonos_SendaId",
                table: "SendaPoligonos",
                column: "SendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "SendaPoligonos");

            migrationBuilder.DropTable(
                name: "Casas");

            migrationBuilder.DropTable(
                name: "Poligonos");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "Sendas");
        }
    }
}
