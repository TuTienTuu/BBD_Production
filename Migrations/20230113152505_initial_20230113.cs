using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBD_Production_New.Migrations
{
    public partial class initial_20230113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionPlans",
                columns: table => new
                {
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
                    ProductionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    KnifeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KnifeContent = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductContent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Border = table.Column<int>(type: "int", nullable: false),
                    PaperSupply = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalMetter = table.Column<int>(type: "int", nullable: false),
                    LayoutMainCode = table.Column<int>(type: "int", nullable: false),
                    DecalMaster = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FilmCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalProduct = table.Column<int>(type: "int", nullable: false),
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    ColorNumber = table.Column<int>(type: "int", nullable: false),
                    NumberTiningColor = table.Column<int>(type: "int", nullable: false),
                    NumberStackColor = table.Column<int>(type: "int", nullable: false),
                    NumberRootColor = table.Column<int>(type: "int", nullable: false),
                    Stage_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stage_1_Loss = table.Column<float>(type: "real", nullable: false),
                    Stage_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stage_2_Loss = table.Column<float>(type: "real", nullable: false),
                    Stage_3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stage_3_Loss = table.Column<float>(type: "real", nullable: false),
                    Stage_4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stage_4_Loss = table.Column<float>(type: "real", nullable: false),
                    Stage_5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stage_5_Loss = table.Column<float>(type: "real", nullable: false),
                    PrintSurfaceLoss = table.Column<float>(type: "real", nullable: false),
                    PrintSoleLoss = table.Column<float>(type: "real", nullable: false),
                    ChangeProductLoss = table.Column<float>(type: "real", nullable: false),
                    ChangeLaminationLoss = table.Column<int>(type: "int", nullable: false),
                    LossPercent = table.Column<int>(type: "int", nullable: false),
                    LossTotal = table.Column<int>(type: "int", nullable: false),
                    SplitLine = table.Column<int>(type: "int", nullable: false),
                    KnifeStep = table.Column<int>(type: "int", nullable: false),
                    StampPerStep = table.Column<int>(type: "int", nullable: false),
                    With = table.Column<int>(type: "int", nullable: false),
                    NumStampHorizontail = table.Column<int>(type: "int", nullable: false),
                    PrintStep = table.Column<int>(type: "int", nullable: false),
                    Core = table.Column<float>(type: "real", nullable: false),
                    CoreSpec = table.Column<float>(type: "real", nullable: false),
                    LayoutName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LayoutPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Time_1 = table.Column<float>(type: "real", nullable: false),
                    Time_2 = table.Column<float>(type: "real", nullable: false),
                    Time_3 = table.Column<float>(type: "real", nullable: false),
                    Time_4 = table.Column<float>(type: "real", nullable: false),
                    Time_5 = table.Column<float>(type: "real", nullable: false),
                    Middle = table.Column<float>(type: "real", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPlans", x => x.ProductionPlanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionPlans");
        }
    }
}
