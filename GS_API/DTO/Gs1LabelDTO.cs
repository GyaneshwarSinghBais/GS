namespace GS_API.DTO
{
    public class Gs1LabelDTO
    {
        public long? labelID { get; set; }
        public long? PONOID { get; set; }
        public long? SupplierID { get; set; }
        public long? WareHouseID { get; set; }
        public string? GTIN { get; set; }
        public string? Itemcode { get; set; }
        public string? SSCCNumber { get; set; }
        public string? Batchno { get; set; }
        public DateTime? MFGDate { get; set; }
        public DateTime? EXPDate { get; set; }
        public decimal? BATCHNBOXQTY { get; set; }
        public DateTime? LabelCreatedate { get; set; }
       // public DateTime? entrydate { get; set; }
        public DateTime? CANCELLATIONDATE { get; set; }
        public string? ISCANCEL { get; set; }
    }
}
