using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLEI.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Provinces_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    VilleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomVille = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.VilleId);
                    table.ForeignKey(
                        name: "FK_Villes_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK_Villes_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    NbreStudio = table.Column<int>(type: "int", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logements", x => x.LogementId);
                    table.ForeignKey(
                        name: "FK_Logements_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "VilleId",
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
                name: "RDVs",
                columns: table => new
                {
                    RDVId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_RDVs_Appartements_RDVId",
                        column: x => x.RDVId,
                        principalTable: "Appartements",
                        principalColumn: "AppartementId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Logements_VilleId",
                table: "Logements",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ImageId",
                table: "Provinces",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RDVs_StudioId",
                table: "RDVs",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Studios_LogementId",
                table: "Studios",
                column: "LogementId");

            migrationBuilder.CreateIndex(
                name: "IX_Villes_ImageId",
                table: "Villes",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Villes_ProvinceId",
                table: "Villes",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartements_Logements_LogementId",
                table: "Appartements",
                column: "LogementId",
                principalTable: "Logements",
                principalColumn: "LogementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Logements_LogementId",
                table: "Images",
                column: "LogementId",
                principalTable: "Logements",
                principalColumn: "LogementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Studios_StudioId",
                table: "Images",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartements_Logements_LogementId",
                table: "Appartements");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Logements_LogementId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Studios_Logements_LogementId",
                table: "Studios");

            migrationBuilder.DropTable(
                name: "RDVs");

            migrationBuilder.DropTable(
                name: "Logements");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Appartements");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
