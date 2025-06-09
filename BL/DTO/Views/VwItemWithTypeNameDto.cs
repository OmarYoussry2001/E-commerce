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
    public class VwItemWithTypeNameDto : BaseDto
    {

        public string TitleAr { get; set; } = null!;

        public string TitleEn { get; set; } = null!;

        public string Title
        => ResourceManager.CurrentLanguage == Language.Arabic ? TitleAr : TitleEn;

        public string ImagePathBackGround { get; set; } = null!;

        public string SerialNo { get; set; } = null!;

        public decimal Price { get; set; }

        public int? SoldCount { get; set; }

        public decimal? DiscountPercent { get; set; }


        public string TypeTitleAr { get; set; } = null!;

        public string TypeTitleEn { get; set; } = null!;
        public string TypeTitle
     => ResourceManager.CurrentLanguage == Language.Arabic ? TypeTitleAr : TypeTitleEn;
    }
}
