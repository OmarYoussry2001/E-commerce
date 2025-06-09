using Resources;
using Resources.Enumerations;
using Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO.Views
{
    public class VwItemDto : BaseDto
    {
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }
        public string Title
        => ResourceManager.CurrentLanguage == Language.Arabic ? TitleAr : TitleEn;
        public string? SerialNo { get; set; }
        public string? ImagePathBackGround { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal Price { get; set; }

        public string? TypeTitleAr { get; set; }
        public string? TypeTitleEn { get; set; }

        public string TypeTitle
      => ResourceManager.CurrentLanguage == Language.Arabic ? TypeTitleAr : TypeTitleEn;
        public string? Size { get; set; }
        public string? ColorAr { get; set; }
        public string? ColorEn { get; set; }
        public string Color
       => ResourceManager.CurrentLanguage == Language.Arabic ? ColorAr : ColorEn;
        public string? BenefitDescriptionAr { get; set; }
        public string? BenefitDescriptionEn { get; set; }
        public string BenefitDescription
  => ResourceManager.CurrentLanguage == Language.Arabic ? BenefitDescriptionAr : BenefitDescriptionEn;
        public string? QualityAr { get; set; }
        public string? QualityEn { get; set; }
        public string Quality
   => ResourceManager.CurrentLanguage == Language.Arabic ? QualityAr : QualityEn;
        public int? Quantity { get; set; }
    }
}
