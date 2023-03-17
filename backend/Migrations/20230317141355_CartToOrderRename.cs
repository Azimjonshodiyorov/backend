using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CartToOrderRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_products");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ordername = table.Column<string>(name: "order_name", type: "text", nullable: false),
                    orderstatus = table.Column<string>(name: "order_status", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_products",
                columns: table => new
                {
                    orderid = table.Column<int>(name: "order_id", type: "integer", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_products", x => new { x.orderid, x.productid });
                    table.ForeignKey(
                        name: "fk_order_products_orders_order_id",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_products_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_products_product_id",
                table: "order_products",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_products");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cartname = table.Column<string>(name: "cart_name", type: "text", nullable: false),
                    cartstatus = table.Column<string>(name: "cart_status", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp without time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cart_products",
                columns: table => new
                {
                    cartid = table.Column<int>(name: "cart_id", type: "integer", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart_products", x => new { x.cartid, x.productid });
                    table.ForeignKey(
                        name: "fk_cart_products_carts_cart_id",
                        column: x => x.cartid,
                        principalTable: "carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cart_products_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cart_products_product_id",
                table: "cart_products",
                column: "product_id");
        }
    }
}
