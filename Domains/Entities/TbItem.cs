using Domains.Entities.Base;
using Resources;
using Resources.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.Entities;

public  class TbItem : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string TitleAr { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string TitleEn { get; set; } = null!;
    [NotMapped]
    public string Title
   => ResourceManager.CurrentLanguage == Language.Arabic ? TitleAr : TitleEn;


    [Required]
    [MaxLength(100)]
    public string ImagePathBackGround { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string SerialNo { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    public int SoldCount { get; set; } = 0;

    public decimal? DiscountPercent { get; set; }
    [Required]
    public Guid TypeId { get; set; }

    [ForeignKey("TypeId")]
    public TbType Type { get; set; }

    public ICollection<TbImage> Images { get; set; } 

    public TbItem()
    {
        Images = new List<TbImage>();
    }
}
