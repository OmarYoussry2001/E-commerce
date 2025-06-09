using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AlterTbSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPanner",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "MiddlePanner",
                table: "TbSettings");

            migrationBuilder.DropColumn(
                name: "WebsiteDescription",
                table: "TbSettings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastPanner",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddlePanner",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteDescription",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
