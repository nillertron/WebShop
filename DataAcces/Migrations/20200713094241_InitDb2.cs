using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAcces.Migrations
{
    public partial class InitDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WS_Distributør",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    CVR = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Distributør", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WS_Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Distrikt = table.Column<string>(nullable: true),
                    PostNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WS_Rank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WS_Vare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    Pris = table.Column<double>(nullable: false),
                    AntalLager = table.Column<int>(nullable: false),
                    IndkøbsPris = table.Column<double>(nullable: false),
                    DistributørId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Vare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WS_Vare_WS_Distributør_DistributørId",
                        column: x => x.DistributørId,
                        principalTable: "WS_Distributør",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WS_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    PostNrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WS_User_WS_Post_PostNrId",
                        column: x => x.PostNrId,
                        principalTable: "WS_Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WS_Ordre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Bestilt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_Ordre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WS_Ordre_WS_User_UserId",
                        column: x => x.UserId,
                        principalTable: "WS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WS_UserRank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RankId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_UserRank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WS_UserRank_WS_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "WS_Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WS_UserRank_WS_User_UserId",
                        column: x => x.UserId,
                        principalTable: "WS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WS_OrdreLinje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VareId = table.Column<int>(nullable: true),
                    OrdreId = table.Column<int>(nullable: true),
                    Antal = table.Column<int>(nullable: false),
                    EnhedsPris = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WS_OrdreLinje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WS_OrdreLinje_WS_Ordre_OrdreId",
                        column: x => x.OrdreId,
                        principalTable: "WS_Ordre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WS_OrdreLinje_WS_Vare_VareId",
                        column: x => x.VareId,
                        principalTable: "WS_Vare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WS_Ordre_UserId",
                table: "WS_Ordre",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WS_OrdreLinje_OrdreId",
                table: "WS_OrdreLinje",
                column: "OrdreId");

            migrationBuilder.CreateIndex(
                name: "IX_WS_OrdreLinje_VareId",
                table: "WS_OrdreLinje",
                column: "VareId");

            migrationBuilder.CreateIndex(
                name: "IX_WS_User_PostNrId",
                table: "WS_User",
                column: "PostNrId");

            migrationBuilder.CreateIndex(
                name: "IX_WS_UserRank_RankId",
                table: "WS_UserRank",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_WS_UserRank_UserId",
                table: "WS_UserRank",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WS_Vare_DistributørId",
                table: "WS_Vare",
                column: "DistributørId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WS_OrdreLinje");

            migrationBuilder.DropTable(
                name: "WS_UserRank");

            migrationBuilder.DropTable(
                name: "WS_Ordre");

            migrationBuilder.DropTable(
                name: "WS_Vare");

            migrationBuilder.DropTable(
                name: "WS_Rank");

            migrationBuilder.DropTable(
                name: "WS_User");

            migrationBuilder.DropTable(
                name: "WS_Distributør");

            migrationBuilder.DropTable(
                name: "WS_Post");
        }
    }
}
