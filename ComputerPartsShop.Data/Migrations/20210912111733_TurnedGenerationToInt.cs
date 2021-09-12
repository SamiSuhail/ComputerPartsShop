using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerPartsShop.Data.Migrations
{
    public partial class TurnedGenerationToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandomAccessMemories_RamGenerations_GenerationId",
                table: "RandomAccessMemories");

            migrationBuilder.DropTable(
                name: "RamGenerations");

            migrationBuilder.DropIndex(
                name: "IX_RandomAccessMemories_GenerationId",
                table: "RandomAccessMemories");

            migrationBuilder.RenameColumn(
                name: "GenerationId",
                table: "RandomAccessMemories",
                newName: "Generation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Generation",
                table: "RandomAccessMemories",
                newName: "GenerationId");

            migrationBuilder.CreateTable(
                name: "RamGenerations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamGenerations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandomAccessMemories_GenerationId",
                table: "RandomAccessMemories",
                column: "GenerationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandomAccessMemories_RamGenerations_GenerationId",
                table: "RandomAccessMemories",
                column: "GenerationId",
                principalTable: "RamGenerations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
