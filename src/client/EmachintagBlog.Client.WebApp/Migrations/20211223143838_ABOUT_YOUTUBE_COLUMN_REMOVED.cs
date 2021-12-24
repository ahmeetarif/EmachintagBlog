using Microsoft.EntityFrameworkCore.Migrations;

namespace EmachintagBlog.Client.WebApp.Migrations
{
    public partial class ABOUT_YOUTUBE_COLUMN_REMOVED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
