using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace obligDiagnoseVerktøyy.Migrations
{
    public partial class tst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "symptom",
                newName: "beskrivelse");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "diagnoseGruppe",
                newName: "beskrivelse");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "diagnose",
                newName: "beskrivelse");

            migrationBuilder.AddColumn<string>(
                name: "beskrivelse",
                table: "symptomBilde",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "navn",
                table: "symptomBilde",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beskrivelse",
                table: "symptomBilde");

            migrationBuilder.DropColumn(
                name: "navn",
                table: "symptomBilde");

            migrationBuilder.RenameColumn(
                name: "beskrivelse",
                table: "symptom",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "beskrivelse",
                table: "diagnoseGruppe",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "beskrivelse",
                table: "diagnose",
                newName: "description");
        }
    }
}
