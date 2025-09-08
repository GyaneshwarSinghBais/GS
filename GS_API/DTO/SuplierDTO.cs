using System.ComponentModel.DataAnnotations;

namespace GS_API.DTO
{
    public class SuplierDTO
    {
        
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public int? PonoId { get; set; }
        public string? Pono { get; set; }
        public DateTime? PoDate { get; set; }
        public decimal? PipelinePoQty { get; set; }
        public string? WarehouseName { get; set; }
        public int? WarehouseId { get; set; }

        public int? SupplierID { get; set; }

        
    }
}
