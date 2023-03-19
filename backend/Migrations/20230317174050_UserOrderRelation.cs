using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UserOrderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "users",
                type: "integer",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_orders_order_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_order_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "users");
        }
    }
}
