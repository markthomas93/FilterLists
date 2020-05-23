using Microsoft.EntityFrameworkCore.Migrations;

namespace FilterLists.Infrastructure.Migrations
{
    public partial class AddMd5Checksum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                "Md5Checksum",
                "snapshots",
                "BINARY(16)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Md5Checksum",
                "snapshots");
        }
    }
}