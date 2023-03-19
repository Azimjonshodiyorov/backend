using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_orders_order_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_order_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "order_name",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "order_status",
                table: "orders",
                newName: "order_owner");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "ix_orders_user_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "order_owner",
                table: "orders",
                newName: "order_status");

            migrationBuilder.AddColumn<string>(
                name: "order_name",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_users_order_id",
                table: "users",
                column: "order_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_orders_order_id",
                table: "users",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
