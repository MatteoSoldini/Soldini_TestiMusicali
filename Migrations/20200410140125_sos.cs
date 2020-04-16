using Microsoft.EntityFrameworkCore.Migrations;

namespace Soldini_TestiMusicali.Migrations
{
    public partial class sos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "owner_id",
                table: "Lyric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "Lyric");
        }
    }
}
