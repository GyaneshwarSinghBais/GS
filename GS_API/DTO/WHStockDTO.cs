namespace GS_API.DTO
{
    public class WHStockDTO
    {
        public int? WAREHOUSEID { get; set; }
        public int? ITEMID { get; set; }
        public string? ITEMCODE { get; set; }
        public string? ITEMNAME { get; set; }
        public string? STRENGTH { get; set; }
        public string? SKU { get; set; }
        public string? CATEGORY { get; set; }
        public string? ITEMTYPE { get; set; }
        public decimal? CURRENTSTOCK { get; set; }
        public decimal? UNDERQC { get; set; }
    }
}
