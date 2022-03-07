using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Charecs",
                columns: table => new
                {
                    charecsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charecsName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charecs", x => x.charecsId);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    detailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    detailName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    drawingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.detailId);
                    table.ForeignKey(
                        name: "FK_Detail_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailCharacteristics",
                columns: table => new
                {
                    detailCharacteristicsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<float>(type: "real", nullable: false),
                    measure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailId = table.Column<int>(type: "int", nullable: true),
                    charecsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCharacteristics", x => x.detailCharacteristicsId);
                    table.ForeignKey(
                        name: "FK_DetailCharacteristics_Charecs_charecsId",
                        column: x => x.charecsId,
                        principalTable: "Charecs",
                        principalColumn: "charecsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailCharacteristics_Detail_detailId",
                        column: x => x.detailId,
                        principalTable: "Detail",
                        principalColumn: "detailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imagesId);
                    table.ForeignKey(
                        name: "FK_Images_Detail_detailId",
                        column: x => x.detailId,
                        principalTable: "Detail",
                        principalColumn: "detailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_categoryId",
                table: "Detail",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCharacteristics_charecsId",
                table: "DetailCharacteristics",
                column: "charecsId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCharacteristics_detailId",
                table: "DetailCharacteristics",
                column: "detailId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_detailId",
                table: "Images",
                column: "detailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCharacteristics");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Charecs");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
