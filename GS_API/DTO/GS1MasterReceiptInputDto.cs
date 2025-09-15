namespace GS_API.DTO
{
    public class GS1MasterReceiptInputDto
    {
        public long gsrid { get; set; }         // will be 0 from client
        public long ponoid { get; set; }
        public string? itemcode { get; set; }
        public long supplierid { get; set; }
        public string? batchno { get; set; }
        public string? mfgdate { get; set; }     // string in JSON
        public string? expdate { get; set; }     // string in JSON
        public long batchqty { get; set; }
        public long warehouseid { get; set; }
        public string? entrydate { get; set; }   // string in JSON
        public string? sscc { get; set; }
    }
}
