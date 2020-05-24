using Microsoft.EntityFrameworkCore.Migrations;

namespace FilterLists.Infrastructure.Migrations
{
    public partial class AddWaybackUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "WaybackUrl",
                "snapshots",
                "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "WaybackUrl",
                "snapshots");
        }
    }
}