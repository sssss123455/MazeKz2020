using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class addRitualService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RitualServiceId",
                table: "RegisterCardForMorgue",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RitualService",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RitualService", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCardForMorgue_RitualService_RitualServiceId",
                table: "RegisterCardForMorgue");

            migrationBuilder.DropTable(
                name: "RitualService");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCardForMorgue_RitualServiceId",
                table: "RegisterCardForMorgue");

            migrationBuilder.DropColumn(
                name: "RitualServiceId",
                table: "RegisterCardForMorgue");
        }
    }
}
