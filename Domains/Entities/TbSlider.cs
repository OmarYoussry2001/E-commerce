using Domains.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class TbSlider : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string TitleAr { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string TitleEn { get; set; } = null!;
        [Required]
        [Range(1, 10)]
        public int DisplayOrder { get; set; } 

        [Required]
        [MaxLength(1000)]
        public string DescriptionAr { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string DescriptionEn { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string ImagePath { get; set; } = null!;
    }
}
