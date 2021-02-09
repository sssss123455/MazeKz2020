using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class addFuneral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCardForMorgue_RitualService_RitualServiceId",
                table: "RegisterCardForMorgue");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCardForMorgue_RitualServiceId",
                table: "RegisterCardForMorgue");

            migrationBuilder.DropColumn(
                name: "RitualServiceId",
                table: "RegisterCardForMorgue");

            migrationBuilder.CreateTable(
                name: "Funeral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfFuneral = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RitualServiceId = table.Column<long>(type: "bigint", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorpseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funeral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funeral_RegisterCardForMorgue_CorpseId",
                        column: x => x.CorpseId,
                        principalTable: "RegisterCardForMorgue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funeral_RitualService_RitualServiceId",
                        column: x => x.RitualServiceId,
                        principalTable: "RitualService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funeral_CorpseId",
                table: "Funeral",
                column: "CorpseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funeral_RitualServiceId",
                table: "Funeral",
                column: "RitualServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funeral");

            migrationBuilder.AddColumn<long>(
                name: "RitualServiceId",
                table: "RegisterCardForMorgue",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCardForMorgue_RitualServiceId",
                table: "RegisterCardForMorgue",
                column: "RitualServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCardForMorgue_RitualService_RitualServiceId",
                table: "RegisterCardForMorgue",
                column: "RitualServiceId",
                principalTable: "RitualService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
