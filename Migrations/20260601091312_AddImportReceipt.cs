using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddImportReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportReceipts",
                columns: table => new
                {
                    ImportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceipts", x => x.ImportId);
                    table.ForeignKey(
                        name: "FK_ImportReceipts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportDetails",
                columns: table => new
                {
                    ImportDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImportReceiptImportId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImportPrice = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDetails", x => x.ImportDetailId);
                    table.ForeignKey(
                        name: "FK_ImportDetails_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportDetails_ImportReceipts_ImportReceiptImportId",
                        column: x => x.ImportReceiptImportId,
                        principalTable: "ImportReceipts",
                        principalColumn: "ImportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_DeviceId",
                table: "ImportDetails",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_ImportReceiptImportId",
                table: "ImportDetails",
                column: "ImportReceiptImportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipts_SupplierId",
                table: "ImportReceipts",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportDetails");

            migrationBuilder.DropTable(
                name: "ImportReceipts");
        }
    }
}
