using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace obligDiagnoseVerktøyy.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "symptom",
                columns: table => new
                {
                    symptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptom", x => x.symptomId);
                });

            migrationBuilder.CreateTable(
                name: "symptomGruppe",
                columns: table => new
                {
                    diagnoseGruppeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptomGruppe", x => x.diagnoseGruppeId);
                });

            migrationBuilder.CreateTable(
                name: "diagnose",
                columns: table => new
                {
                    diagnoseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diagnoseGruppeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnose", x => x.diagnoseId);
                    table.ForeignKey(
                        name: "FK_diagnose_symptomGruppe_diagnoseGruppeId",
                        column: x => x.diagnoseGruppeId,
                        principalTable: "symptomGruppe",
                        principalColumn: "diagnoseGruppeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "symptomBilde",
                columns: table => new
                {
                    symptomBildeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnoseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptomBilde", x => x.symptomBildeId);
                    table.ForeignKey(
                        name: "FK_symptomBilde_diagnose_diagnoseId",
                        column: x => x.diagnoseId,
                        principalTable: "diagnose",
                        principalColumn: "diagnoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "symptomSymptomBilde",
                columns: table => new
                {
                    symptomId = table.Column<int>(type: "int", nullable: false),
                    symptomBildeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptomSymptomBilde", x => new { x.symptomId, x.symptomBildeId });
                    table.ForeignKey(
                        name: "FK_symptomSymptomBilde_symptom_symptomId",
                        column: x => x.symptomId,
                        principalTable: "symptom",
                        principalColumn: "symptomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_symptomSymptomBilde_symptomBilde_symptomBildeId",
                        column: x => x.symptomBildeId,
                        principalTable: "symptomBilde",
                        principalColumn: "symptomBildeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_diagnose_diagnoseGruppeId",
                table: "diagnose",
                column: "diagnoseGruppeId");

            migrationBuilder.CreateIndex(
                name: "IX_symptomBilde_diagnoseId",
                table: "symptomBilde",
                column: "diagnoseId");

            migrationBuilder.CreateIndex(
                name: "IX_symptomSymptomBilde_symptomBildeId",
                table: "symptomSymptomBilde",
                column: "symptomBildeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "symptomSymptomBilde");

            migrationBuilder.DropTable(
                name: "symptom");

            migrationBuilder.DropTable(
                name: "symptomBilde");

            migrationBuilder.DropTable(
                name: "diagnose");

            migrationBuilder.DropTable(
                name: "symptomGruppe");
        }
    }
}
