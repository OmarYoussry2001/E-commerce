using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Views
{
    public class VwItem
    {
        public Guid Id { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }
        public string? SerialNo { get; set; }
        public string? ImagePathBackGround { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDateUtc { get; set; }
        public int? SoldCount { get; set; }


        public string? TypeTitleAr { get; set; }
        public string? TypeTitleEn { get; set; }
        public string? Size { get; set; }
        public string? ColorAr { get; set; }
        public string? ColorEn { get; set; }
        public string? BenefitDescriptionAr { get; set; }
        public string? BenefitDescriptionEn { get; set; }
        public string? QualityAr { get; set; }
        public string? QualityEn { get; set; }
        public int? Quantity { get; set; }
    }
}
