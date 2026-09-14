using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinariaMoe.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteMascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_PropietarioId",
                table: "Mascotas",
                column: "PropietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Propietarios_PropietarioId",
                table: "Mascotas",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Propietarios_PropietarioId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_PropietarioId",
                table: "Mascotas");
        }
    }
}
