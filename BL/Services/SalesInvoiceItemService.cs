using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.DTO.Views;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SalesInvoiceItemService : BaseService<TbSalesInvoiceItem, SalesInvoiceItemDto>, ISalesInvoiceItemService  
    {
        private readonly ITableRepository<TbSalesInvoiceItem> _baseTableRepository;
        private readonly IBaseMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IImageProcessingService _imageProcessingService;
      
        public SalesInvoiceItemService(ITableRepository<TbSalesInvoiceItem> baseTableRepository, IFileUploadService fileUploadService, IImageProcessingService imageProcessingService, IBaseMapper mapper) : base(baseTableRepository, mapper)
        {
            _baseTableRepository = baseTableRepository;
            _fileUploadService = fileUploadService;
            _imageProcessingService = imageProcessingService;
            _mapper = mapper;
        }

    }
}
