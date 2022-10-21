using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace obligDiagnoseVerktøyy.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnose_symptomGruppe_diagnoseGruppeId",
                table: "diagnose");

            migrationBuilder.DropPrimaryKey(
                name: "PK_symptomGruppe",
                table: "symptomGruppe");

            migrationBuilder.RenameTable(
                name: "symptomGruppe",
                newName: "diagnoseGruppe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_diagnoseGruppe",
                table: "diagnoseGruppe",
                column: "diagnoseGruppeId");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnose_diagnoseGruppe_diagnoseGruppeId",
                table: "diagnose",
                column: "diagnoseGruppeId",
                principalTable: "diagnoseGruppe",
                principalColumn: "diagnoseGruppeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnose_diagnoseGruppe_diagnoseGruppeId",
                table: "diagnose");

            migrationBuilder.DropPrimaryKey(
                name: "PK_diagnoseGruppe",
                table: "diagnoseGruppe");

            migrationBuilder.RenameTable(
                name: "diagnoseGruppe",
                newName: "symptomGruppe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_symptomGruppe",
                table: "symptomGruppe",
                column: "diagnoseGruppeId");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnose_symptomGruppe_diagnoseGruppeId",
                table: "diagnose",
                column: "diagnoseGruppeId",
                principalTable: "symptomGruppe",
                principalColumn: "diagnoseGruppeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
