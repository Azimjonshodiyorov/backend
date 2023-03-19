using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_id",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "order_owner",
                table: "orders",
                newName: "order_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order_name",
                table: "orders",
                newName: "order_owner");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "users",
                type: "integer",
                nullable: true);
        }
    }
}
