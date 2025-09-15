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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GSRID { get; set; }

        public long PONOID { get; set; }
        public string? ITEMCODE { get; set; }
        public long SUPPLIERID { get; set; }
        public string? BATCHNO { get; set; }

        // <-- switch these to DateTime? so EF sends DATEs to Oracle
        public DateTime? MFGDATE { get; set; }
        public DateTime? EXPDATE { get; set; }

        public long BATCHQTY { get; set; }
        public long WAREHOUSEID { get; set; }

        public DateTime? ENTRYDATE { get; set; }
        public string? SSCC { get; set; }
    }


}
