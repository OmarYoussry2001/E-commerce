using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Base
{
    public class BaseSeoDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "TitleArRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "TitleArLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string SEOTitleAR { get; set; } = null!;
        [Required(ErrorMessageResourceName = "TitleEnRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "TitleEnLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string SEOTitleEN { get; set; } = null!;
        [Required(ErrorMessageResourceName = "DescriptionArRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(1000, MinimumLength = 10, ErrorMessageResourceName = "DescriptionArLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string SEODescriptionAR { get; set; } = null!;
        [Required(ErrorMessageResourceName = "DescriptionEnRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(1000, MinimumLength = 10, ErrorMessageResourceName = "DescriptionEnLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string SEODescriptionEN { get; set; } = null!;
        public string SEOMetaTags { get; set; } = null!;
    }
}
