using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBD_Production_New.Migrations
{
    public partial class initial_20230116 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                columns: table => new
                {
                    ProductionOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Machine = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    POCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KnifeSpec = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NumberOfStage = table.Column<int>(type: "int", nullable: false),
                    NumberOfCode = table.Column<int>(type: "int", nullable: false),
                    LaminatingFilm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LaminatingSize = table.Column<int>(type: "int", nullable: false),
                    PaperCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaperSize = table.Column<int>(type: "int", nullable: false),
                    MetterPerRoll = table.Column<int>(type: "int", nullable: false),
                    StampPerRoll = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorePerSheet = table.Column<int>(type: "int", nullable: false),
                    MetterPerOrder = table.Column<int>(type: "int", nullable: false),
                    ProductedMetter = table.Column<int>(type: "int", nullable: false),
                    LayoutCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", maxLength: 150, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.ProductionOrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionOrders");
        }
    }
}
