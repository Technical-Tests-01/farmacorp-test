using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.access.Migrations
{
    public partial class Add_Tables_ErpModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarCodes",
                columns: table => new
                {
                    barCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uniqueCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    productExpressId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCodes", x => x.barCodeId);
                    table.ForeignKey(
                        name: "FK_BarCodes_ProductExpresses_productExpressId",
                        column: x => x.productExpressId,
                        principalTable: "ProductExpresses",
                        principalColumn: "productExpressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProducstErp",
                columns: table => new
                {
                    productExpressId = table.Column<int>(type: "int", nullable: false),
                    cost = table.Column<double>(type: "float", nullable: false),
                    uniqueCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducstErp", x => x.productExpressId);
                    table.ForeignKey(
                        name: "FK_ProducstErp_ProductExpresses_productExpressId",
                        column: x => x.productExpressId,
                        principalTable: "ProductExpresses",
                        principalColumn: "productExpressId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarCodes_productExpressId",
                table: "BarCodes",
                column: "productExpressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarCodes");

            migrationBuilder.DropTable(
                name: "ProducstErp");
        }
    }
}
