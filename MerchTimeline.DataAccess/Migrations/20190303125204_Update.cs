using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchTimeline.DataAccess.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchItem_AppUser_OwnerId",
                table: "MerchItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchSlot_AppUser_OwnerId",
                table: "MerchSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "Users");

            migrationBuilder.AddColumn<long>(
                name: "MerchSlotId",
                table: "MerchItemUsagePeriod",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MerchItemUsagePeriod_MerchSlotId",
                table: "MerchItemUsagePeriod",
                column: "MerchSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchItem_Users_OwnerId",
                table: "MerchItem",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchItemUsagePeriod_MerchSlot_MerchSlotId",
                table: "MerchItemUsagePeriod",
                column: "MerchSlotId",
                principalTable: "MerchSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchSlot_Users_OwnerId",
                table: "MerchSlot",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchItem_Users_OwnerId",
                table: "MerchItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchItemUsagePeriod_MerchSlot_MerchSlotId",
                table: "MerchItemUsagePeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchSlot_Users_OwnerId",
                table: "MerchSlot");

            migrationBuilder.DropIndex(
                name: "IX_MerchItemUsagePeriod_MerchSlotId",
                table: "MerchItemUsagePeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MerchSlotId",
                table: "MerchItemUsagePeriod");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchItem_AppUser_OwnerId",
                table: "MerchItem",
                column: "OwnerId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchSlot_AppUser_OwnerId",
                table: "MerchSlot",
                column: "OwnerId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
