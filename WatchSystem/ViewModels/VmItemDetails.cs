using BL.DTO.Entities;
using BL.DTO.Views;

namespace WatchSystem.ViewModels
{
    public class VmItemDetails
    {
        public VmItemDetails()
        {
            Item = new VwItemDto();
            Images = new List<ImageDto>();
            RelatedItems = new List<VwItemDto>();
        }

        public VwItemDto Item { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
        public IEnumerable<VwItemDto> RelatedItems { get; set; }
    }
}
