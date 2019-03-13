using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MerchTimeline.DataAccess.Migrations
{
    public partial class OpenEndedPeriods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchItemSlot");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "MerchItemUsagePeriod",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "MerchItemUsagePeriod",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "MerchItemUsagePeriod");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "MerchItemUsagePeriod",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MerchItemSlot",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MerchItemId = table.Column<long>(nullable: true),
                    MerchSlotId = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_MerchItemSlot_MerchItemId",
                table: "MerchItemSlot",
                column: "MerchItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchItemSlot_MerchSlotId",
                table: "MerchItemSlot",
                column: "MerchSlotId");
        }
    }
}
