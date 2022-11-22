using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.access.Migrations
{
    public partial class Add_Table_ProductExpress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idProductType",
                table: "ProductTypes",
                newName: "productTypeId");

            migrationBuilder.CreateTable(
                name: "ProductExpresses",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    expirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observations = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    productExpressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductExpresses", x => x.productExpressId);
                    table.ForeignKey(
                        name: "FK_ProductExpresses_ProductTypes_productTypeId",
                        column: x => x.productTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "productTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductExpresses_productTypeId",
                table: "ProductExpresses",
                column: "productTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductExpresses");

            migrationBuilder.RenameColumn(
                name: "productTypeId",
                table: "ProductTypes",
                newName: "idProductType");
        }
    }
}
