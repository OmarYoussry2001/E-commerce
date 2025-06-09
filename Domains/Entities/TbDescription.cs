using Domains.Entities;
using Domains.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.Entities;

public class TbDescription : BaseEntity
{
    public string Size { get; set; } = null!;
    public string ColorAr { get; set; } = null!; 
    public string ColorEn { get; set; } = null!;
    public string BenefitDescriptionAr { get; set; } = null!;
    public string BenefitDescriptionEn { get; set; } = null!;
    public string QualityAr { get; set; } = null!;  
    public string QualityEn { get; set; } = null!;  
    public int Quantity { get; set; }           
    public Guid ItemId { get; set; }

    [ForeignKey("ItemId")]
    public TbItem TbItem { get; set; } 
}
