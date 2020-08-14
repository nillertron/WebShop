using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAcces.Migrations
{
    public partial class updates1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "WS_Vare",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WS_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WS_Vare_CategoryId",
                table: "WS_Vare",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WS_Vare_WS_Category_CategoryId",
                table: "WS_Vare",
                column: "CategoryId",
                principalTable: "WS_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WS_Vare_WS_Category_CategoryId",
                table: "WS_Vare");

            migrationBuilder.DropTable(
                name: "WS_Category");

            migrationBuilder.DropIndex(
                name: "IX_WS_Vare_CategoryId",
                table: "WS_Vare");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WS_Vare");
        }
    }
}
