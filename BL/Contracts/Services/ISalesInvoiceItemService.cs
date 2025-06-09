using BL.DTO.Entities;
using BL.Services;
using DAL.Models;
using Domains.Entities;

using Shared.GeneralModels.SearchCriteriaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts.Services
{
    public interface ISalesInvoiceItemService : IBaseService<TbSalesInvoiceItem, SalesInvoiceItemDto>
    {
        //public new Task<bool> Save(SalesInvoiceDto dto, Guid userId);
    }
}
