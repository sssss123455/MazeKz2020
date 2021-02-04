using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class addBodyIdentificationReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatesOfIdentificationForPolice_CitizenUser_IdentifyingPersonId",
                table: "DatesOfIdentificationForPolice");

            migrationBuilder.DropForeignKey(
                name: "FK_DatesOfIdentificationForPolice_CitizenUser_PoliceOfficerId",
                table: "DatesOfIdentificationForPolice");

            migrationBuilder.DropForeignKey(
                name: "FK_DatesOfIdentificationForPolice_RegisterCardForMorgue_CorpseId",
                table: "DatesOfIdentificationForPolice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatesOfIdentificationForPolice",
                table: "DatesOfIdentificationForPolice");

            migrationBuilder.RenameTable(
                name: "DatesOfIdentificationForPolice",
                newName: "BodyIdentificationReport");

            migrationBuilder.RenameIndex(
                name: "IX_DatesOfIdentificationForPolice_PoliceOfficerId",
                table: "BodyIdentificationReport",
                newName: "IX_BodyIdentificationReport_PoliceOfficerId");

            migrationBuilder.RenameIndex(
                name: "IX_DatesOfIdentificationForPolice_IdentifyingPersonId",
                table: "BodyIdentificationReport",
                newName: "IX_BodyIdentificationReport_IdentifyingPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_DatesOfIdentificationForPolice_CorpseId",
                table: "BodyIdentificationReport",
                newName: "IX_BodyIdentificationReport_CorpseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BodyIdentificationReport",
                table: "BodyIdentificationReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyIdentificationReport_CitizenUser_IdentifyingPersonId",
                table: "BodyIdentificationReport",
                column: "IdentifyingPersonId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyIdentificationReport_CitizenUser_PoliceOfficerId",
                table: "BodyIdentificationReport",
                column: "PoliceOfficerId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyIdentificationReport_RegisterCardForMorgue_CorpseId",
                table: "BodyIdentificationReport",
                column: "CorpseId",
                principalTable: "RegisterCardForMorgue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyIdentificationReport_CitizenUser_IdentifyingPersonId",
                table: "BodyIdentificationReport");

            migrationBuilder.DropForeignKey(
                name: "FK_BodyIdentificationReport_CitizenUser_PoliceOfficerId",
                table: "BodyIdentificationReport");

            migrationBuilder.DropForeignKey(
                name: "FK_BodyIdentificationReport_RegisterCardForMorgue_CorpseId",
                table: "BodyIdentificationReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BodyIdentificationReport",
                table: "BodyIdentificationReport");

            migrationBuilder.RenameTable(
                name: "BodyIdentificationReport",
                newName: "DatesOfIdentificationForPolice");

            migrationBuilder.RenameIndex(
                name: "IX_BodyIdentificationReport_PoliceOfficerId",
                table: "DatesOfIdentificationForPolice",
                newName: "IX_DatesOfIdentificationForPolice_PoliceOfficerId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyIdentificationReport_IdentifyingPersonId",
                table: "DatesOfIdentificationForPolice",
                newName: "IX_DatesOfIdentificationForPolice_IdentifyingPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyIdentificationReport_CorpseId",
                table: "DatesOfIdentificationForPolice",
                newName: "IX_DatesOfIdentificationForPolice_CorpseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatesOfIdentificationForPolice",
                table: "DatesOfIdentificationForPolice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatesOfIdentificationForPolice_CitizenUser_IdentifyingPersonId",
                table: "DatesOfIdentificationForPolice",
                column: "IdentifyingPersonId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DatesOfIdentificationForPolice_CitizenUser_PoliceOfficerId",
                table: "DatesOfIdentificationForPolice",
                column: "PoliceOfficerId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DatesOfIdentificationForPolice_RegisterCardForMorgue_CorpseId",
                table: "DatesOfIdentificationForPolice",
                column: "CorpseId",
                principalTable: "RegisterCardForMorgue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
