using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MerchTimeline.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: true),
                    AuthToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MerchType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Kind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MerchSlot",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchSlot_AppUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<long>(nullable: false),
                    ItemTypeId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchItem_MerchType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "MerchType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchItem_AppUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchItemSlot",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MerchSlotId = table.Column<long>(nullable: true),
                    MerchItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchItemSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchItemSlot_MerchItem_MerchItemId",
                        column: x => x.MerchItemId,
                        principalTable: "MerchItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MerchItemSlot_MerchSlot_MerchSlotId",
                        column: x => x.MerchSlotId,
                        principalTable: "MerchSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MerchItemUsagePeriod",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MerchItemId = table.Column<long>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchItemUsagePeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchItemUsagePeriod_MerchItem_MerchItemId",
                        column: x => x.MerchItemId,
                        principalTable: "MerchItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchItem_ItemTypeId",
                table: "MerchItem",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchItem_OwnerId",
                table: "MerchItem",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchItemSlot_MerchItemId",
                table: "MerchItemSlot",
                column: "MerchItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchItemSlot_MerchSlotId",
                table: "MerchItemSlot",
                column: "MerchSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchItemUsagePeriod_MerchItemId",
                table: "MerchItemUsagePeriod",
                column: "MerchItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchSlot_OwnerId",
                table: "MerchSlot",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchItemSlot");

            migrationBuilder.DropTable(
                name: "MerchItemUsagePeriod");

            migrationBuilder.DropTable(
                name: "MerchSlot");

            migrationBuilder.DropTable(
                name: "MerchItem");

            migrationBuilder.DropTable(
                name: "MerchType");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
