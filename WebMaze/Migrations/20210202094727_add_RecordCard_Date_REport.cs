using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class add_RecordCard_Date_REport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterCardForMorgue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BodyDamage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingsFromBody = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterCardForMorgue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterCardForMorgue_CitizenUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatesOfIdentificationForPolice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfIdentification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDateSet = table.Column<bool>(type: "bit", nullable: false),
                    PoliceOfficerId = table.Column<long>(type: "bigint", nullable: true),
                    IdentifyingPersonId = table.Column<long>(type: "bigint", nullable: true),
                    IsIdentified = table.Column<bool>(type: "bit", nullable: false),
                    CorpseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesOfIdentificationForPolice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatesOfIdentificationForPolice_CitizenUser_IdentifyingPersonId",
                        column: x => x.IdentifyingPersonId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DatesOfIdentificationForPolice_CitizenUser_PoliceOfficerId",
                        column: x => x.PoliceOfficerId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DatesOfIdentificationForPolice_RegisterCardForMorgue_CorpseId",
                        column: x => x.CorpseId,
                        principalTable: "RegisterCardForMorgue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForensicReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfForensic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PathologistId = table.Column<long>(type: "bigint", nullable: true),
                    IsReportRecorded = table.Column<bool>(type: "bit", nullable: false),
                    CorpseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForensicReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForensicReport_CitizenUser_PathologistId",
                        column: x => x.PathologistId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForensicReport_RegisterCardForMorgue_CorpseId",
                        column: x => x.CorpseId,
                        principalTable: "RegisterCardForMorgue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatesOfIdentificationForPolice_CorpseId",
                table: "DatesOfIdentificationForPolice",
                column: "CorpseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatesOfIdentificationForPolice_IdentifyingPersonId",
                table: "DatesOfIdentificationForPolice",
                column: "IdentifyingPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DatesOfIdentificationForPolice_PoliceOfficerId",
                table: "DatesOfIdentificationForPolice",
                column: "PoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ForensicReport_CorpseId",
                table: "ForensicReport",
                column: "CorpseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForensicReport_PathologistId",
                table: "ForensicReport",
                column: "PathologistId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCardForMorgue_UserId",
                table: "RegisterCardForMorgue",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatesOfIdentificationForPolice");

            migrationBuilder.DropTable(
                name: "ForensicReport");

            migrationBuilder.DropTable(
                name: "RegisterCardForMorgue");
        }
    }
}
