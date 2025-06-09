using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateVwItemWithTypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view VwItemWithTypeName
As
SELECT        dbo.TbItem.Id, dbo.TbItem.TitleAr, dbo.TbItem.TitleEn, dbo.TbItem.ImagePathBackGround, dbo.TbItem.SerialNo, dbo.TbItem.Price,
dbo.TbItem.DiscountPercent, dbo.TbItem.SoldCount, dbo.TbType.TitleAr AS TypeTitleAr, 
                         dbo.TbType.TitleEn AS TypeTitleEn
FROM            dbo.TbItem INNER JOIN
                         dbo.TbType ON dbo.TbItem.TypeId = dbo.TbType.Id
						 where dbo.TbItem.CurrentState =1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
