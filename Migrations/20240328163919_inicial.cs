using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api6969.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    chassi = table.Column<string>(type: "text", nullable: false),
                    marca = table.Column<string>(type: "text", nullable: true),
                    modelo = table.Column<string>(type: "text", nullable: true),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    combustivel = table.Column<string>(type: "text", nullable: true),
                    cor = table.Column<string>(type: "text", nullable: true),
                    motor = table.Column<string>(type: "text", nullable: true),
                    cambio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.chassi);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
