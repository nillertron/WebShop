using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcces.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WS_Rank");

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "WS_Vare",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Beskrivelse",
                table: "WS_Vare",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "WS_User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "WS_User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "WS_Rank",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "WS_User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "WS_User");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "WS_Rank");

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "WS_Vare",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Beskrivelse",
                table: "WS_Vare",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WS_Rank",
                type: "text",
                nullable: true);
        }
    }
}
