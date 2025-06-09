using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SetSoldCountDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE TbItem SET SoldCount = 0 WHERE SoldCount IS NULL");

            migrationBuilder.AlterColumn<int>(
                name: "SoldCount",
                table: "TbItem",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoldCount",
                table: "TbItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
