using Microsoft.EntityFrameworkCore.Migrations;

namespace lesson62.Migrations
{
    public partial class ChangeTopicComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TopicId",
                table: "Comments",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Topics_TopicId",
                table: "Comments",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Topics_TopicId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TopicId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Comments");
        }
    }
}
