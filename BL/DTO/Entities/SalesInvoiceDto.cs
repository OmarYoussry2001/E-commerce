using Domains.Entities;
using Domains.Identity;
using Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO.Entities
{
    public class SalesInvoiceDto : BaseDto
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? Notes { get; set; }
        public string ApplicationUserId { get; set; } = null!;
        public IEnumerable<SalesInvoiceItemDto> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItemDto>();
    }
}
