using Domains.Entities.Base;
using Domains.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.Entities
{
    public class TbSalesInvoice : BaseEntity
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? Notes { get; set; }
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public List<TbSalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<TbSalesInvoiceItem>();
    }
}
