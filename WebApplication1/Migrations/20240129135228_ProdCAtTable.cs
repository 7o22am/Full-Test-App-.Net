using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ProdCAtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "ProCategorysId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProCategorys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProCategorysId",
                table: "Products",
                column: "ProCategorysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProCategorys_ProCategorysId",
                table: "Products",
                column: "ProCategorysId",
                principalTable: "ProCategorys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProCategorys_ProCategorysId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProCategorysId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProCategorysId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Select Category" },
                    { 2, "Computers" },
                    { 3, "Mobiles" },
                    { 4, "Electric machines" },
                    { 5, "Mobile & Electric machines" },
                    { 6, "Mobile & Computers" },
                    { 7, "Mobile & Computers & Electric machines2" }
                });
        }
    }
}
