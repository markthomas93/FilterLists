using Microsoft.EntityFrameworkCore.Migrations;

namespace FilterLists.Infrastructure.Migrations
{
    public partial class addChatUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "ChatUrl",
                "filterlists",
                "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ChatUrl",
                "filterlists");
        }
    }
}