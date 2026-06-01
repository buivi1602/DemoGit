using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddExportManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExportReceipts",
                columns: table => new
                {
                    ExportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportCode = table.Column<string>(type: "TEXT", nullable: false),
                    ExportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportReceipts", x => x.ExportId);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetails",
                columns: table => new
                {
                    ExportDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExportReceiptExportId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExportPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetails", x => x.ExportDetailId);
                    table.ForeignKey(
                        name: "FK_ExportDetails_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportDetails_ExportReceipts_ExportReceiptExportId",
                        column: x => x.ExportReceiptExportId,
                        principalTable: "ExportReceipts",
                        principalColumn: "ExportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_DeviceId",
                table: "ExportDetails",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_ExportReceiptExportId",
                table: "ExportDetails",
                column: "ExportReceiptExportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportDetails");

            migrationBuilder.DropTable(
                name: "ExportReceipts");
        }
    }
}
