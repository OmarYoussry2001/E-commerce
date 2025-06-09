using Resources;
using Resources.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Views
{
    public class VwItemWithTypeName
    {
        public Guid Id { get; set; }

        public string TitleAr { get; set; } = null!;

        [NotMapped]
        public string Title
      => ResourceManager.CurrentLanguage == Language.Arabic ? TitleAr : TitleEn;
        public string TitleEn { get; set; } = null!;

        public string ImagePathBackGround { get; set; } = null!;

        public string SerialNo { get; set; } = null!;

        public decimal Price { get; set; }

        public int? SoldCount { get; set; }

        public decimal? DiscountPercent { get; set; }

  
        public string TypeTitleAr { get; set; } = null!;

        public string TypeTitleEn { get; set; } = null!;
    }
}
