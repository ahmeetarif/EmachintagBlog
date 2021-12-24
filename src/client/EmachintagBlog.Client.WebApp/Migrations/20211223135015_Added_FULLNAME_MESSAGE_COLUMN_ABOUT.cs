using Microsoft.EntityFrameworkCore.Migrations;

namespace EmachintagBlog.Client.WebApp.Migrations
{
    public partial class Added_FULLNAME_MESSAGE_COLUMN_ABOUT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Abouts");
        }
    }
}
