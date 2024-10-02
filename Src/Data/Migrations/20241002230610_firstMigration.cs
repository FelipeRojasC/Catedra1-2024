using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catedra1_api.src.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rut = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    correo = table.Column<string>(type: "TEXT", nullable: false),
                    fechaNachimiento = table.Column<int>(type: "INTEGER", nullable: false),
                    generoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Generos_generoId",
                        column: x => x.generoId,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_generoId",
                table: "Usuarios",
                column: "generoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
