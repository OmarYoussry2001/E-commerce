using Domains.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.Entities;

public  class TbImage : BaseEntity
{
    [Required]
    [StringLength(255)]
    public string ImagePath { get; set; } = null!;

    [Required]
    public Guid ItemId { get; set; }

    [ForeignKey("ItemId")]
    public TbItem Item { get; set; } 
}
