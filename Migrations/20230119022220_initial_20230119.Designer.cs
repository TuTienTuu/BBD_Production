﻿// <auto-generated />
using System;
using BBD_Production_New.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BBD_Production_New.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230119022220_initial_20230119")]
    partial class initial_20230119
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BBD_Production_New.Models.ImportHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImportFileName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("ImportHistorys");
                });

            modelBuilder.Entity("BBD_Production_New.Models.ProductionOrder", b =>
                {
                    b.Property<Guid>("ProductionOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CorePerSheet")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasMaxLength(150)
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KnifeSpec")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LaminatingFilm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LaminatingSize")
                        .HasColumnType("int");

                    b.Property<string>("LayoutCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Machine")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("MetterPerOrder")
                        .HasColumnType("int");

                    b.Property<int>("MetterPerRoll")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("NumberOfCode")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStage")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("POCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PaperCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PaperSize")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ProductedMetter")
                        .HasColumnType("int");

                    b.Property<string>("ProductionCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ProductionPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StampPerRoll")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductionOrderId");

                    b.ToTable("ProductionOrders");
                });

            modelBuilder.Entity("BBD_Production_New.Models.ProductionPlan", b =>
                {
                    b.Property<Guid>("ProductionPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Border")
                        .HasColumnType("int");

                    b.Property<int>("ChangeLaminationLoss")
                        .HasColumnType("int");

                    b.Property<float>("ChangeProductLoss")
                        .HasColumnType("real");

                    b.Property<int>("ColorNumber")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<float>("Core")
                        .HasColumnType("real");

                    b.Property<int>("CorePerSheet")
                        .HasColumnType("int");

                    b.Property<float>("CoreSpec")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DecalMaster")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilmCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KnifeCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("KnifeContent")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("KnifeSpec")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("KnifeStep")
                        .HasColumnType("int");

                    b.Property<string>("LaminatingFilm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LaminatingSize")
                        .HasColumnType("int");

                    b.Property<string>("LayoutCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("LayoutMainCode")
                        .HasColumnType("int");

                    b.Property<string>("LayoutName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LayoutPosition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LossPercent")
                        .HasColumnType("int");

                    b.Property<int>("LossTotal")
                        .HasColumnType("int");

                    b.Property<string>("Machine")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("MetterPerOrder")
                        .HasColumnType("int");

                    b.Property<int>("MetterPerRoll")
                        .HasColumnType("int");

                    b.Property<float>("Middle")
                        .HasColumnType("real");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("NumStampHorizontail")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCode")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStage")
                        .HasColumnType("int");

                    b.Property<int>("NumberRootColor")
                        .HasColumnType("int");

                    b.Property<int>("NumberStackColor")
                        .HasColumnType("int");

                    b.Property<int>("NumberTiningColor")
                        .HasColumnType("int");

                    b.Property<string>("OrderBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("POCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PaperCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PaperSize")
                        .HasColumnType("int");

                    b.Property<string>("PaperSupply")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<float>("PrintSoleLoss")
                        .HasColumnType("real");

                    b.Property<int>("PrintStep")
                        .HasColumnType("int");

                    b.Property<float>("PrintSurfaceLoss")
                        .HasColumnType("real");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("ProductContent")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProductNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ProductedMetter")
                        .HasColumnType("int");

                    b.Property<string>("ProductionCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int>("SplitLine")
                        .HasColumnType("int");

                    b.Property<string>("Stage_1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Stage_1_Loss")
                        .HasColumnType("real");

                    b.Property<string>("Stage_2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Stage_2_Loss")
                        .HasColumnType("real");

                    b.Property<string>("Stage_3")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Stage_3_Loss")
                        .HasColumnType("real");

                    b.Property<string>("Stage_4")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Stage_4_Loss")
                        .HasColumnType("real");

                    b.Property<string>("Stage_5")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Stage_5_Loss")
                        .HasColumnType("real");

                    b.Property<int>("StampPerRoll")
                        .HasColumnType("int");

                    b.Property<int>("StampPerStep")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Time_1")
                        .HasColumnType("real");

                    b.Property<float>("Time_2")
                        .HasColumnType("real");

                    b.Property<float>("Time_3")
                        .HasColumnType("real");

                    b.Property<float>("Time_4")
                        .HasColumnType("real");

                    b.Property<float>("Time_5")
                        .HasColumnType("real");

                    b.Property<int>("TotalMetter")
                        .HasColumnType("int");

                    b.Property<int>("TotalProduct")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("With")
                        .HasColumnType("int");

                    b.HasKey("ProductionPlanId");

                    b.ToTable("ProductionPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
