using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmachintagBlog.Client.WebApp.Migrations
{
    public partial class DatabaseRefactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.RenameColumn(
                name: "CreatetdAt",
                table: "Contacts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatetdAt",
                table: "Blogs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatetdAt",
                table: "BlogComments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatetdAt",
                table: "Abouts",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Contacts",
                newName: "CreatetdAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Blogs",
                newName: "CreatetdAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BlogComments",
                newName: "CreatetdAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Abouts",
                newName: "CreatetdAt");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    BlogsId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatetdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCover = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Blogs_BlogsId",
                        column: x => x.BlogsId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_BlogsId",
                table: "Images",
                column: "BlogsId");
        }
    }
}
