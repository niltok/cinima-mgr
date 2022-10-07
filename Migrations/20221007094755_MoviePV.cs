using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class MoviePV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTickets_Order_UsedInId",
                table: "DiscountTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserName",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Order_OrderId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserName",
                table: "Orders",
                newName: "IX_Orders_UserName");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Preview",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TriggerTime",
                table: "Events",
                column: "TriggerTime");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountTickets_Orders_UsedInId",
                table: "DiscountTickets",
                column: "UsedInId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserName",
                table: "Orders",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTickets_Orders_UsedInId",
                table: "DiscountTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserName",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Events_TriggerTime",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserName",
                table: "Order",
                newName: "IX_Order_UserName");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Tickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Preview",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountTickets_Order_UsedInId",
                table: "DiscountTickets",
                column: "UsedInId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserName",
                table: "Order",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Order_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
