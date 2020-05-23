using Microsoft.EntityFrameworkCore.Migrations;

namespace FilterLists.Infrastructure.Migrations
{
    public partial class RenameDiscontinuedToUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "DiscontinuedDate",
                "filterlists",
                "UpdatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "UpdatedDate",
                "filterlists",
                "DiscontinuedDate");
        }
    }
}