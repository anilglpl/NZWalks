using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_walkDifficulties_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_walkDifficulties",
                table: "walkDifficulties");

            migrationBuilder.RenameTable(
                name: "walkDifficulties",
                newName: "WalkDifficulties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalkDifficulties",
                table: "WalkDifficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "WalkDifficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulties_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalkDifficulties",
                table: "WalkDifficulties");

            migrationBuilder.RenameTable(
                name: "WalkDifficulties",
                newName: "walkDifficulties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_walkDifficulties",
                table: "walkDifficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_walkDifficulties_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "walkDifficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
