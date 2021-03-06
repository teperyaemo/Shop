// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data;

namespace Shop.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20220307150729_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Data.Models.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Shop.Data.Models.Charecs", b =>
                {
                    b.Property<int>("charecsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("charecsName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("charecsId");

                    b.ToTable("Charecs");
                });

            modelBuilder.Entity("Shop.Data.Models.Detail", b =>
                {
                    b.Property<int>("detailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detailName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("drawingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("visible")
                        .HasColumnType("bit");

                    b.HasKey("detailId");

                    b.HasIndex("categoryId");

                    b.ToTable("Detail");
                });

            modelBuilder.Entity("Shop.Data.Models.DetailCharacteristics", b =>
                {
                    b.Property<int>("detailCharacteristicsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("charecsId")
                        .HasColumnType("int");

                    b.Property<int?>("detailId")
                        .HasColumnType("int");

                    b.Property<string>("measure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("value")
                        .HasColumnType("real");

                    b.HasKey("detailCharacteristicsId");

                    b.HasIndex("charecsId");

                    b.HasIndex("detailId");

                    b.ToTable("DetailCharacteristics");
                });

            modelBuilder.Entity("Shop.Data.Models.Images", b =>
                {
                    b.Property<int>("imagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("detailId")
                        .HasColumnType("int");

                    b.Property<string>("imageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imagesId");

                    b.HasIndex("detailId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Shop.Data.Models.Detail", b =>
                {
                    b.HasOne("Shop.Data.Models.Category", "Category")
                        .WithMany("details")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Data.Models.DetailCharacteristics", b =>
                {
                    b.HasOne("Shop.Data.Models.Charecs", "Charecs")
                        .WithMany("detailCharacteristics")
                        .HasForeignKey("charecsId");

                    b.HasOne("Shop.Data.Models.Detail", "Detail")
                        .WithMany("detailCharacteristics")
                        .HasForeignKey("detailId");

                    b.Navigation("Charecs");

                    b.Navigation("Detail");
                });

            modelBuilder.Entity("Shop.Data.Models.Images", b =>
                {
                    b.HasOne("Shop.Data.Models.Detail", "Detail")
                        .WithMany("images")
                        .HasForeignKey("detailId");

                    b.Navigation("Detail");
                });

            modelBuilder.Entity("Shop.Data.Models.Category", b =>
                {
                    b.Navigation("details");
                });

            modelBuilder.Entity("Shop.Data.Models.Charecs", b =>
                {
                    b.Navigation("detailCharacteristics");
                });

            modelBuilder.Entity("Shop.Data.Models.Detail", b =>
                {
                    b.Navigation("detailCharacteristics");

                    b.Navigation("images");
                });
#pragma warning restore 612, 618
        }
    }
}
