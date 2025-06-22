using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLEI.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logements",
                columns: table => new
                {
                    LogementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomLogement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbreAppartement = table.Column<int>(type: "int", nullable: false),
                    NbreStudio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logements", x => x.LogementId);
                });

            migrationBuilder.CreateTable(
                name: "Appartements",
                columns: table => new
                {
                    AppartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbreDePieces = table.Column<int>(type: "int", nullable: false),
                    Loyer = table.Column<float>(type: "real", nullable: false),
                    LogementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appartements", x => x.AppartementId);
                    table.ForeignKey(
                        name: "FK_Appartements_Logements_LogementId",
                        column: x => x.LogementId,
                        principalTable: "Logements",
                        principalColumn: "LogementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loyer = table.Column<float>(type: "real", nullable: false),
                    LogementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioId);
                    table.ForeignKey(
                        name: "FK_Studios_Logements_LogementId",
                        column: x => x.LogementId,
                        principalTable: "Logements",
                        principalColumn: "LogementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogementId = table.Column<int>(type: "int", nullable: true),
                    AppartementId = table.Column<int>(type: "int", nullable: true),
                    StudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Appartements_AppartementId",
                        column: x => x.AppartementId,
                        principalTable: "Appartements",
                        principalColumn: "AppartementId");
                    table.ForeignKey(
                        name: "FK_Images_Logements_LogementId",
                        column: x => x.LogementId,
                        principalTable: "Logements",
                        principalColumn: "LogementId");
                    table.ForeignKey(
                        name: "FK_Images_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioId");
                });

            migrationBuilder.CreateTable(
                name: "RDVs",
                columns: table => new
                {
                    RDVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Heure = table.Column<TimeOnly>(type: "time", nullable: false),
                    AppartementId = table.Column<int>(type: "int", nullable: true),
                    StudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RDVs", x => x.RDVId);
                    table.ForeignKey(
                        name: "FK_RDVs_Appartements_AppartementId",
                        column: x => x.AppartementId,
                        principalTable: "Appartements",
                        principalColumn: "AppartementId");
                    table.ForeignKey(
                        name: "FK_RDVs_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appartements_LogementId",
                table: "Appartements",
                column: "LogementId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AppartementId",
                table: "Images",
                column: "AppartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LogementId",
                table: "Images",
                column: "LogementId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudioId",
                table: "Images",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_RDVs_AppartementId",
                table: "RDVs",
                column: "AppartementId");

            migrationBuilder.CreateIndex(
                name: "IX_RDVs_StudioId",
                table: "RDVs",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Studios_LogementId",
                table: "Studios",
                column: "LogementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "RDVs");

            migrationBuilder.DropTable(
                name: "Appartements");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Logements");
        }
    }
}
