using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAcces.Migrations
{
    public partial class mibbern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beskrivelse",
                table: "WS_Vare",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "WS_Vare",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Oprettet",
                table: "WS_Vare",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Oprettet",
                table: "WS_User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "WS_Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    WS_VareId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WS_Pictures_WS_Vare_WS_VareId",
                        column: x => x.WS_VareId,
                        principalTable: "WS_Vare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WS_Pictures_WS_VareId",
                table: "WS_Pictures",
                column: "WS_VareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WS_Pictures");

            migrationBuilder.DropColumn(
                name: "Beskrivelse",
                table: "WS_Vare");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "WS_Vare");

            migrationBuilder.DropColumn(
                name: "Oprettet",
                table: "WS_Vare");

            migrationBuilder.DropColumn(
                name: "Oprettet",
                table: "WS_User");
        }
    }
}
