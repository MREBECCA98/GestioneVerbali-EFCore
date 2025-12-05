using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_S5_L5.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    IdAnagrafica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cap = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.IdAnagrafica);
                });

            migrationBuilder.CreateTable(
                name: "TipiViolazione",
                columns: table => new
                {
                    IdViolazione = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiViolazione", x => x.IdViolazione);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    IdVerbale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateOnly>(type: "date", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateOnly>(type: "date", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    IdAnagraficaFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdViolazioneFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.IdVerbale);
                    table.ForeignKey(
                        name: "FK_Verbali_Anagrafiche_IdAnagraficaFk",
                        column: x => x.IdAnagraficaFk,
                        principalTable: "Anagrafiche",
                        principalColumn: "IdAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbali_TipiViolazione_IdViolazioneFk",
                        column: x => x.IdViolazioneFk,
                        principalTable: "TipiViolazione",
                        principalColumn: "IdViolazione",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdAnagraficaFk",
                table: "Verbali",
                column: "IdAnagraficaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdViolazioneFk",
                table: "Verbali",
                column: "IdViolazioneFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Anagrafiche");

            migrationBuilder.DropTable(
                name: "TipiViolazione");
        }
    }
}
