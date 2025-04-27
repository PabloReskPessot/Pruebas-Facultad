using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class VeterinariaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dueños",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueños", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raza = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    id_raza = table.Column<int>(type: "int", nullable: false),
                    id_dueño = table.Column<int>(type: "int", nullable: false),
                    Razaid = table.Column<int>(type: "int", nullable: true),
                    Dueñoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Dueños_Dueñoid",
                        column: x => x.Dueñoid,
                        principalTable: "Dueños",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Mascotas_Razas_Razaid",
                        column: x => x.Razaid,
                        principalTable: "Razas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_Dueñoid",
                table: "Mascotas",
                column: "Dueñoid");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_Razaid",
                table: "Mascotas",
                column: "Razaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Dueños");

            migrationBuilder.DropTable(
                name: "Razas");
        }
    }
}
