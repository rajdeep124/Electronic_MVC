using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic_MVC.Migrations
{
    public partial class Electronic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand_Branch_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delivery_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brand_DetailId = table.Column<int>(type: "int", nullable: false),
                    Category_DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Brand_Detail_Brand_DetailId",
                        column: x => x.Brand_DetailId,
                        principalTable: "Brand_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Category_Detail_Category_DetailId",
                        column: x => x.Category_DetailId,
                        principalTable: "Category_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Customer_DetailId = table.Column<int>(type: "int", nullable: false),
                    Product_DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Detail_Customer_Detail_Customer_DetailId",
                        column: x => x.Customer_DetailId,
                        principalTable: "Customer_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Detail_Product_Detail_Product_DetailId",
                        column: x => x.Product_DetailId,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Customer_DetailId",
                table: "Order_Detail",
                column: "Customer_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Product_DetailId",
                table: "Order_Detail",
                column: "Product_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Brand_DetailId",
                table: "Product_Detail",
                column: "Brand_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Category_DetailId",
                table: "Product_Detail",
                column: "Category_DetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Detail");

            migrationBuilder.DropTable(
                name: "Customer_Detail");

            migrationBuilder.DropTable(
                name: "Product_Detail");

            migrationBuilder.DropTable(
                name: "Brand_Detail");

            migrationBuilder.DropTable(
                name: "Category_Detail");
        }
    }
}
