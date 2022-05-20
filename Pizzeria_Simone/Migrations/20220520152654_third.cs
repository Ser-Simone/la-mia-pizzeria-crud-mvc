using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzeria_Simone.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Pizzaset",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzaset_CategoryId",
                table: "Pizzaset",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzaset_Category_CategoryId",
                table: "Pizzaset",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzaset_Category_CategoryId",
                table: "Pizzaset");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Pizzaset_CategoryId",
                table: "Pizzaset");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Pizzaset");
        }
    }
}
