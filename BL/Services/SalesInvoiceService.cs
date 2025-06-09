using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.DTO.Views;
using DAL.Contracts.Repositories;
using DAL.Contracts.UnitOfWork;
using DAL.UnitOfWork;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SalesInvoiceService : BaseService<TbSalesInvoice, SalesInvoiceDto >, ISalesInvoiceService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IImageProcessingService _imageProcessingService;
        private readonly IItemService _itemService;
        
        public SalesInvoiceService( IUnitOfWork unitOfWork, IFileUploadService fileUploadService, IImageProcessingService imageProcessingService, IItemService itemService, IBaseMapper mapper) : base(unitOfWork.TableRepository<TbSalesInvoice>(), mapper)
        {
            _unitOfWork = unitOfWork; 
             _fileUploadService = fileUploadService;
            _imageProcessingService = imageProcessingService;
            _mapper = mapper;
            _itemService = itemService;
        }
       async Task<bool> ISalesInvoiceService.Save(SalesInvoiceDto dto, Guid userId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty", nameof(userId));

            try
            {

                var entitySalesInvoice = _mapper.MapModel<SalesInvoiceDto, TbSalesInvoice>(dto);
                var SalesInvoiceItemServiceEntities = _mapper.MapList<SalesInvoiceItemDto, TbSalesInvoiceItem>(dto.SalesInvoiceItems);
                entitySalesInvoice.SalesInvoiceItems = new List<TbSalesInvoiceItem>();

                await _unitOfWork.BeginTransactionAsync();

                // Save Sales Invoice
                if (!_unitOfWork.TableRepository<TbSalesInvoice>().Save(entitySalesInvoice, userId, out Guid salesInvoiceID))
                    throw new Exception("Failed to save Sales Invoice");

                // Save Sales Invoice Items
                foreach (var Item in SalesInvoiceItemServiceEntities)
                    Item.SalesInvoiceID = salesInvoiceID;

                if (SalesInvoiceItemServiceEntities.Any())
                    _unitOfWork.TableRepository<TbSalesInvoiceItem>().AddRange(SalesInvoiceItemServiceEntities, userId);

                var commitResult = await _unitOfWork.Commit();
                if( commitResult == 0)
                {
                    IEnumerable<SoldItemDto> soldItem = SalesInvoiceItemServiceEntities.Select(x => new SoldItemDto { Id = x.ItemID, Qty = x.Qty });
                    _itemService.IncrementSoldCount(soldItem , userId);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error saving Sales Invoice", ex);
            }
        }
    }
}
