using Domains.Entities;
using Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO.Entities
{
    public class SalesInvoiceItemDto : BaseDto
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string? Notes { get; set; }
        public Guid ItemID { get; set; }
        public Guid SalesInvoiceID { get; set; }



        public SalesInvoiceDto SalesInvoice { get; set; } = null!;
        public  ItemDto Item { get; set; } = null!;
    }
}
