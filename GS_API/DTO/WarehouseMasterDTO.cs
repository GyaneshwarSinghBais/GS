using System.ComponentModel.DataAnnotations;

namespace GS_API.DTO
{
    public class WarehouseMasterDTO
    {
        [Key]
        public int? Warehouseid { get; set; }
        public string? Warehousename { get; set; }
    }
}
