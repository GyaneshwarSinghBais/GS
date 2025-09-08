using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS_API.DTO
{
  


    [Table("GS1MASTERRECEIPT")]
    public class GS1MASTERRECEIPTModel
    {

        [Key]

        public Int64 GSRID { get; set; }


        public Int64 PONOID { get; set; }
        // public Int64 ITEMID { get; set; }

        public string? ITEMCODE { get; set; }
        public Int64 SUPPLIERID { get; set; }
        public string? BATCHNO { get; set; }


        public string? MFGDATE { get; set; }


        public string? EXPDATE { get; set; }


        public Int64 BATCHQTY { get; set; }


        public Int64 WAREHOUSEID { get; set; }


        public string? ENTRYDATE { get; set; }
        public string? SSCC { get; set; }
        


    }
}
