using System.ComponentModel.DataAnnotations;

namespace GS_API.DTO
{
    public class SupplierMasterDTO
    {
        [Key]
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
    }
}
