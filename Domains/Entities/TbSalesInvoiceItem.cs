using Domains.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domains.Entities
{
    public class TbSalesInvoiceItem : BaseEntity
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string? Notes { get; set; }
        public Guid ItemID { get; set; }
        public Guid SalesInvoiceID { get; set; }

        [ForeignKey("SalesInvoiceID")]
        public TbSalesInvoice SalesInvoice { get; set; } = null!;
        [ForeignKey("ItemID")]
        public virtual TbItem Item { get; set; } = null!;
    }
}
