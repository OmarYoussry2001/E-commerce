using AutoMapper;
using BL.DTO.Entities;
using BL.DTO.Views;
using Domains.Entities;
using Domains.Identity;
using Domains.Views;
 


namespace BL.Mapper
{
    // Main mapping profile file (MappingProfile.cs)
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureCategoryMappings();

        }
        private void ConfigureCategoryMappings()
        {
            
            CreateMap<TbType, TypeDto>().ReverseMap();
            CreateMap<TbSlider, SliderDto>().ReverseMap();
            CreateMap<TbDescription, DescriptionDto>().ReverseMap();
            CreateMap<TbImage, ImageDto>().ReverseMap();
            CreateMap<TbItem, ItemDto>().ReverseMap();
            CreateMap<TbSalesInvoice, SalesInvoiceDto>().ReverseMap();
            CreateMap<TbSalesInvoiceItem, SalesInvoiceItemDto>().ReverseMap();
            CreateMap<TbSettings, SettingsDto>().ReverseMap();


            CreateMap<VwItem, VwItemDto>().ReverseMap();
            CreateMap<VwItemWithTypeName, VwItemWithTypeNameDto>().ReverseMap();


        }
    }
}
