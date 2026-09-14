using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinariaMoe.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteCitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreVeterinario",
                table: "Citas");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MascotaId",
                table: "Citas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_VeterinarioId",
                table: "Citas",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Mascotas_MascotaId",
                table: "Citas",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Veterinarios_VeterinarioId",
                table: "Citas",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Mascotas_MascotaId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Veterinarios_VeterinarioId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_MascotaId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_VeterinarioId",
                table: "Citas");

            migrationBuilder.AddColumn<string>(
                name: "NombreVeterinario",
                table: "Citas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
