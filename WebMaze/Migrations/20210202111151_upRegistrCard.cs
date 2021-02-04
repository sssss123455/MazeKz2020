using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class upRegistrCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCardForMorgue_CitizenUser_UserId",
                table: "RegisterCardForMorgue");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RegisterCardForMorgue",
                newName: "CorpseId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisterCardForMorgue_UserId",
                table: "RegisterCardForMorgue",
                newName: "IX_RegisterCardForMorgue_CorpseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCardForMorgue_CitizenUser_CorpseId",
                table: "RegisterCardForMorgue",
                column: "CorpseId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCardForMorgue_CitizenUser_CorpseId",
                table: "RegisterCardForMorgue");

            migrationBuilder.RenameColumn(
                name: "CorpseId",
                table: "RegisterCardForMorgue",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisterCardForMorgue_CorpseId",
                table: "RegisterCardForMorgue",
                newName: "IX_RegisterCardForMorgue_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCardForMorgue_CitizenUser_UserId",
                table: "RegisterCardForMorgue",
                column: "UserId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
