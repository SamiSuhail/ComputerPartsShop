using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerPartsShop.Data.Migrations
{
    public partial class AddedRamValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "RandomAccessMemories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "RandomAccessMemories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RandomAccessMemories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_RandomAccessMemories_Model",
                table: "RandomAccessMemories",
                column: "Model",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RandomAccessMemories_Model",
                table: "RandomAccessMemories");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "RandomAccessMemories");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "RandomAccessMemories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RandomAccessMemories");
        }
    }
}
