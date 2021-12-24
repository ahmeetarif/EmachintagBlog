using Microsoft.EntityFrameworkCore.Migrations;

namespace EmachintagBlog.Client.WebApp.Migrations
{
    public partial class Added_IMAGEPATH_Column_ABOUT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Abouts");
        }
    }
}
