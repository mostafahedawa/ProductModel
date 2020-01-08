using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Infrastructure.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietaryFlags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryFlags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    PhotoName = table.Column<string>(nullable: true),
                    DietaryID = table.Column<int>(nullable: false),
                    NumberOfViews = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_DietaryFlags_DietaryID",
                        column: x => x.DietaryID,
                        principalTable: "DietaryFlags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DietaryFlags",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "vegan" },
                    { 2, "lactose-free" }
                });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Vendor1" },
                    { 2, "Vendor2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "DietaryID", "NumberOfViews", "PhotoName", "Price", "Title", "VendorID" },
                values: new object[] { 1, "This is a description for product1", 1, 2, null, 20.0, "Product1", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "DietaryID", "NumberOfViews", "PhotoName", "Price", "Title", "VendorID" },
                values: new object[] { 2, "This is a description for product2", 2, 0, null, 40.0, "Product2", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DietaryID",
                table: "Products",
                column: "DietaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorID",
                table: "Products",
                column: "VendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "DietaryFlags");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
