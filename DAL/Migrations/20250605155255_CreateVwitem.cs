using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateVwitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW VwItem AS
SELECT 
    dbo.TbItem.Id, 
    dbo.TbItem.TitleAr, 
    dbo.TbItem.TitleEn, 
    dbo.TbItem.SerialNo, 
    dbo.TbType.TitleAr AS TypeTitleAr, 
    dbo.TbType.TitleEn AS TypeTitleEn, 
    dbo.TbItem.ImagePathBackGround, 
    dbo.TbItem.DiscountPercent, 
    dbo.TbItem.Price, 
    dbo.TbItem.CreatedDateUtc,
    dbo.TbDescription.Size, 
    dbo.TbDescription.ColorAr, 
    dbo.TbDescription.ColorEn, 
    dbo.TbDescription.BenefitDescriptionAr, 
    dbo.TbDescription.BenefitDescriptionEn, 
    dbo.TbDescription.QualityAr, 
    dbo.TbDescription.QualityEn, 
    dbo.TbDescription.Quantity
FROM dbo.TbDescription
INNER JOIN dbo.TbItem ON dbo.TbDescription.ItemId = dbo.TbItem.Id
INNER JOIN dbo.TbType ON dbo.TbItem.TypeId = dbo.TbType.Id
where  dbo.TbItem.CurrentState =1");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
