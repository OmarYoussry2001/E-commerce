using BL.DTO.Entities;
using BL.DTO.Views;
using Domains.Entities;
using System.Collections.Generic;

namespace WatchSystem.ViewModels
{
    public class VmHomePage
    {
        public VmHomePage()
        {
            //HomeCollection = new HomeCollectionViewModel();
            SpecialOffers = new List<VwItemDto>();
            NewItems = new List<VwItemDto>();
            AllItems = new List<VwItemDto>();
            RelatedItems = new List<VwItemDto>();
            FeaturedProducts = new List<VwItemDto>();
            BestSellers = new List<VwItemDto>();
            Categories = new List<VwItemDto>(); // TODO: replace VwItemDto with a dedicated Category type if available
            Sliders = new List<SliderDto>();
            ItemTypes = new List<TypeDto>();
        }
        public IEnumerable<VwItemDto> SpecialOffers { get; set; }
        public IEnumerable<VwItemDto> NewItems { get; set; }
        public IEnumerable<VwItemDto> AllItems { get; set; }
        public IEnumerable<VwItemDto> RelatedItems { get; set; }
        public IEnumerable<VwItemDto> FeaturedProducts { get; set; }
        public IEnumerable<VwItemDto> BestSellers { get; set; }
        public IEnumerable<VwItemDto> Categories { get; set; }

        public IEnumerable<SliderDto> Sliders { get; set; }
        public IEnumerable<TypeDto> ItemTypes { get; set; }
    }
}
