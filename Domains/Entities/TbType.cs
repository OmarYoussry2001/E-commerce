using Domains.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Entities;

public  class TbType : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string TitleAr { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string TitleEn { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string ImagePath { get; set; } = null!;
    public  ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}
