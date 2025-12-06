using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_S5_L5.Migrations
{
    /// <inheritdoc />
    public partial class modifynamedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbali_TipiViolazione_IdViolazioneFk",
                table: "Verbali");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipiViolazione",
                table: "TipiViolazione");

            migrationBuilder.RenameTable(
                name: "TipiViolazione",
                newName: "TipoViolazioni");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoViolazioni",
                table: "TipoViolazioni",
                column: "IdViolazione");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbali_TipoViolazioni_IdViolazioneFk",
                table: "Verbali",
                column: "IdViolazioneFk",
                principalTable: "TipoViolazioni",
                principalColumn: "IdViolazione",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbali_TipoViolazioni_IdViolazioneFk",
                table: "Verbali");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoViolazioni",
                table: "TipoViolazioni");

            migrationBuilder.RenameTable(
                name: "TipoViolazioni",
                newName: "TipiViolazione");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipiViolazione",
                table: "TipiViolazione",
                column: "IdViolazione");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbali_TipiViolazione_IdViolazioneFk",
                table: "Verbali",
                column: "IdViolazioneFk",
                principalTable: "TipiViolazione",
                principalColumn: "IdViolazione",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
