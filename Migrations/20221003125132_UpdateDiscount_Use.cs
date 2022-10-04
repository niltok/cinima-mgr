using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class UpdateDiscount_Use : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTickets_Order_OrderId",
                table: "DiscountTickets");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "DiscountTickets",
                newName: "UsedInId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountTickets_OrderId",
                table: "DiscountTickets",
                newName: "IX_DiscountTickets_UsedInId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountTickets_Order_UsedInId",
                table: "DiscountTickets",
                column: "UsedInId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTickets_Order_UsedInId",
                table: "DiscountTickets");

            migrationBuilder.RenameColumn(
                name: "UsedInId",
                table: "DiscountTickets",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountTickets_UsedInId",
                table: "DiscountTickets",
                newName: "IX_DiscountTickets_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountTickets_Order_OrderId",
                table: "DiscountTickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
