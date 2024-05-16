using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    public partial class Hamdi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratoire",
                columns: table => new
                {
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratoire", x => x.LaboratoireId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    CodePatient = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.CodePatient);
                });

            migrationBuilder.CreateTable(
                name: "Infirmier",
                columns: table => new
                {
                    InfrimierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialite = table.Column<int>(type: "int", nullable: false),
                    LaboratoireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infirmier", x => x.InfrimierId);
                    table.ForeignKey(
                        name: "FK_Infirmier_Laboratoire_LaboratoireId",
                        column: x => x.LaboratoireId,
                        principalTable: "Laboratoire",
                        principalColumn: "LaboratoireId");
                });

            migrationBuilder.CreateTable(
                name: "Bilan",
                columns: table => new
                {
                    DatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    CodePatient = table.Column<int>(type: "int", nullable: false),
                    EmailMedecin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paye = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilan", x => new { x.CodeInfirmier, x.CodePatient, x.DatePrelevement });
                    table.ForeignKey(
                        name: "FK_Bilan_Infirmier_CodeInfirmier",
                        column: x => x.CodeInfirmier,
                        principalTable: "Infirmier",
                        principalColumn: "InfrimierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilan_Patient_CodePatient",
                        column: x => x.CodePatient,
                        principalTable: "Patient",
                        principalColumn: "CodePatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analyse",
                columns: table => new
                {
                    AnalyseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateResultat = table.Column<int>(type: "int", nullable: false),
                    PrixAnalyse = table.Column<double>(type: "float", nullable: false),
                    TypeAnalyse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValeurAnalyse = table.Column<float>(type: "real", nullable: false),
                    ValeurMax = table.Column<float>(type: "real", nullable: false),
                    ValeurMin = table.Column<float>(type: "real", nullable: false),
                    BilanCodeInfirmier = table.Column<int>(type: "int", nullable: true),
                    BilanCodePatient = table.Column<int>(type: "int", nullable: true),
                    BilanDatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BilanFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyse", x => x.AnalyseId);
                    table.ForeignKey(
                        name: "FK_Analyse_Bilan_BilanCodeInfirmier_BilanCodePatient_BilanDatePrelevement",
                        columns: x => new { x.BilanCodeInfirmier, x.BilanCodePatient, x.BilanDatePrelevement },
                        principalTable: "Bilan",
                        principalColumns: new[] { "CodeInfirmier", "CodePatient", "DatePrelevement" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyse_BilanCodeInfirmier_BilanCodePatient_BilanDatePrelevement",
                table: "Analyse",
                columns: new[] { "BilanCodeInfirmier", "BilanCodePatient", "BilanDatePrelevement" });

            migrationBuilder.CreateIndex(
                name: "IX_Bilan_CodePatient",
                table: "Bilan",
                column: "CodePatient");

            migrationBuilder.CreateIndex(
                name: "IX_Infirmier_LaboratoireId",
                table: "Infirmier",
                column: "LaboratoireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyse");

            migrationBuilder.DropTable(
                name: "Bilan");

            migrationBuilder.DropTable(
                name: "Infirmier");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Laboratoire");
        }
    }
}
