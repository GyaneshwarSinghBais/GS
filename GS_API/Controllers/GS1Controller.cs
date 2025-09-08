using CgmscHO_API.Utility;
using GS_API.Data;
using GS_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.CompilerServices;

namespace GS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GS1Controller : ControllerBase
    {
        private readonly OraDbContext _context;

        public GS1Controller(OraDbContext context)
        {
            _context = context;
        }

        [HttpGet("PODetails")]
        public async Task<ActionResult<IEnumerable<SuplierDTO>>> PODetails(Int32 supplierId)
        {
            string whSupplierId = "";
            if (supplierId != 0)
            {
                whSupplierId = " and op.supplierid = " + supplierId + " ";
            }
            string qry = @" select itemcode,itemname,supplierid,ponoid,pono,podate,pipelineQTY as pipelinepoqty, warehousename,warehouseid from (

select  m.itemcode,m.itemname,OI.itemid,op.supplierid,op.ponoid,op.pono,op.soissuedate podate,w.warehouseid,w.warehousename,op.extendeddate,sum(soi.ABSQTY) as absqty,nvl(rec.receiptabsqty,0)receiptabsqty,
receiptdelayexception ,round(sysdate-op.soissuedate,0) as days,
case when m.nablreq = 'Y' and  round(sysdate-op.soissuedate,0) <= 150 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0)
else case when m.ISSTERILITY = 'Y' and  round(sysdate-op.soissuedate,0) <= 100 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0)
else case when op.extendeddate is null and round(sysdate-op.soissuedate,0) <= 90 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0) 
else case when op.receiptdelayexception = 1 and sysdate <= op.extendeddate+1 then  sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0) 
else case when op.extendeddate is not null and op.receiptdelayexception = 1 and  (op.extendeddate+1) <= op.soissuedate and round(sysdate-op.soissuedate,0) <= 90 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0) else 0 end end end end end as pipelineQTY
from   soOrderPlaced OP  
inner join SoOrderedItems OI on OI.PoNoID=OP.PoNoID
inner join soorderdistribution soi on soi.orderitemid=OI.orderitemid
inner join masitems m on m.itemid = oi.itemid
inner join maswarehouses w on w.warehouseid = soi.warehouseid
left outer join 
(
select tr.ponoid,tri.itemid,sum(tri.receiptabsqty) receiptabsqty from tbreceipts tr 
inner join tbreceiptitems tri on tri.receiptid=tr.receiptid 
where tr.receipttype='NO' and tr.status='C' and tr.notindpdmis is null and tri.notindpdmis is null
group by tr.ponoid,tri.itemid
) rec on rec.ponoid=OP.PoNoID and rec.itemid=OI.itemid 
 where op.status  in ('C','O') " + whSupplierId + @"
 group by m.itemcode,m.itemname,m.nablreq,m.ISSTERILITY,op.ponoid,op.pono,w.warehouseid,w.warehousename,op.soissuedate,op.extendeddate,OI.itemid ,rec.receiptabsqty,
 op.soissuedate,op.extendeddate ,receiptdelayexception,op.supplierid  
 having (case when m.nablreq = 'Y' and  round(sysdate-op.soissuedate,0) <= 150 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0)
 else case when m.ISSTERILITY = 'Y' and  round(sysdate-op.soissuedate,0) <= 100 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0)
else case when op.extendeddate is null and round(sysdate-op.soissuedate,0) <= 90 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0) 
else case when op.receiptdelayexception = 1 and sysdate <= op.extendeddate+1 then  sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0) 
else case when op.extendeddate is not null and op.receiptdelayexception = 1 and  (op.extendeddate+1) <= op.soissuedate 
and round(sysdate-op.soissuedate,0) <= 90 then sum(soi.ABSQTY)-nvl(rec.receiptabsqty,0) else 0 end end end end end) >0
)
order by itemcode,podate

 ";
            var myList = _context.SuplierDbSet
           .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

            return myList;

        }


        [HttpGet("ItemMaster")]
        public async Task<ActionResult<IEnumerable<ItemMasterDTO>>> ItemMaster(string itemcode)
        {
            string whItemCode = "";
            if (itemcode != "0")
            {
                whItemCode = " and m.itemcode = '" + itemcode + "' ";
            }

            string qry = @" select mc.mcid categoryid,mc.mcategory category,m.itemid,m.itemcode,m.itemname,t.itemtypename itemtype,m.strength1 strength,m.unit,m.unitcount,m.itemtypeid 
from masitems m 
inner join masitemcategories c on c.categoryid = m.categoryid 
inner join masitemmaincategory mc on mc.mcid = c.mcid
inner join masitemtypes t on t.itemtypeid = m.itemtypeid
where mc.mcid in (1,2)
" + whItemCode + @"
and m.isfreez_itpr is null  
order by mc.mcid,m.itemcode

 ";
            var myList = _context.ItemMasterDbSet
           .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

            return myList;

        }


        [HttpGet("SupplierMaster")]
        public async Task<ActionResult<IEnumerable<SupplierMasterDTO>>> SupplierMaster(Int32 supplierId)
        {
            string whSupplierId = "";
            if (supplierId != 0)
            {
                whSupplierId = " and supplierid = " + supplierId + " ";
            }

            string qry = @"  select supplierid,suppliername,address1||''||address2||''||address3||''||city||'' as address from massuppliers 
                     where isactive = 1
                    " + whSupplierId + @"
                    order by suppliername

            ";

            var myList = _context.SupplierMasterDbSet
           .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

            return myList;

        }

        [HttpGet("WarehouseMaster")]
        public async Task<ActionResult<IEnumerable<WarehouseMasterDTO>>> WarehouseMaster(Int32 warehouseid)
        {
            string whWarehouseID = "";
            if (warehouseid != 0)
            {
                whWarehouseID = " and warehouseid = " + warehouseid + @" ";
            }

            string qry = @" select warehouseid, warehousename from maswarehouses 
                        where 1=1 " + whWarehouseID + @" ";
            var myList = _context.WarehouseMasterDbSet
           .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

            return myList;

        }





        [HttpGet("getReceiptDetails")]
        public async Task<ActionResult<IEnumerable<GsDataDTO>>> getReceiptDetails(Int64 facid)
        {


            string qry = @"select GSRID,PONOID	,		
	ITEMID	,		
	SUPPLIERID	,		
	BATCHNO			,
	MFGDATE	,		
	EXPDATE	,		
	BATCHQTY	,		
	WAREHOUSEID	,		
	ENTRYDATE from GS1MASTERRECEIPT where WAREHOUSEID=:facid ";



            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":facid", OracleDbType.Int64, facid, ParameterDirection.Input)
            };

            var myList = _context.GsDataDTODbSet
                .FromSqlRaw(qry, parameters)
                .ToList();

            return myList;
        }



        [HttpPost("GsDataDTOMaster")]
        public async Task<ActionResult<IEnumerable<GsDataDTO>>> GsDataDTOMaster(GS1MASTERRECEIPTModel objeReceipt)
        {

            try
            {
                FacOperations ob = new FacOperations(_context);
                string validMFGDATE = ob.FormatDate(objeReceipt.MFGDATE);
                string validEXPDATE = ob.FormatDate(objeReceipt.EXPDATE);
                objeReceipt.MFGDATE = validMFGDATE;
                objeReceipt.EXPDATE = validEXPDATE;


                Int64 recpID = ob.facGetGSRID(); // getReceiptIssueNo(facid);

                objeReceipt.GSRID = recpID;

                _context.GS1MASTERRECEIPTModelDbSet.Add(objeReceipt);
                _context.SaveChanges();
                // Int64 ffcid = Convert.ToInt64(facid);
                var myObj = "Sucessufully"; // getReceiptDetails(Convert.ToInt64(objeReceipt.WAREHOUSEID));
                return Ok(myObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }



        [HttpGet("WHStock")]
        public async Task<ActionResult<IEnumerable<WHStockDTO>>> WHStock(Int64 whid, String itemCode)
        {
            string whItemCode = "";
            string whwhid = "";

            if (itemCode != "0")
            {
                whItemCode = " and ITEMCODE = '" + itemCode + "' ";
            }
            if (whid != 0)
            {
                whwhid = " and warehouseid = " + whid + " ";
            }


            string qry = @" select WAREHOUSEID,ITEMID, ITEMCODE, ITEMNAME, STRENGTH,SKU,CATEGORY, ITEMTYPE,  sum(READYFORISSUE) as CURRENTSTOCK,sum(PENDING) as  UNDERQC from (
select mi.itemid,mi.itemcode,mi.itemname,mi.strength1 as strength,mi.unit as sku,c.categoryname as CATEGORY,t.ITEMTYPENAME as itemtype, t.warehouseid,nvl((case when tbr.qastatus ='1' then (nvl(tbr.absrqty,0) - nvl(tbr.issueqty,0)) else (case when mi.Qctest ='N' 
and tbr.qastatus=2 then 0 else case when mi.Qctest ='N' then (nvl(tbr.absrqty,0) - nvl(tbr.issueqty,0) ) end  end ) end ),0) ReadyForIssue,    
nvl(case when  mi.qctest='N' then 0 else (case when tbr.qastatus = 0 or tbr.qastatus = 3 then (nvl(tbr.absrqty,0)- nvl(tbr.issueqty,0)) end) end,0)  Pending    
from tbreceiptbatches tbr
inner join tbreceiptitems tbi on tbi.receiptitemid=tbr.receiptitemid
inner join tbreceipts t on t.receiptid=tbi.receiptid
inner join masitems mi on mi.itemid=tbi.itemid
inner join masitemcategories c on c.categoryid = mi.categoryid
inner join masitemmaincategory mc on mc.mcid = c.mcid
left outer join masitemtypes t on t.itemtypeid = mi.itemtypeid
where  T.Status = 'C'   
and mi.isfreez_itpr is null
And (tbr.ExpDate >= SysDate or nvl(tbr.ExpDate,SysDate) >= SysDate) and (tbr.Whissueblock = 0 or tbr.Whissueblock is null)
and (nvl(ABSRQTY,0)-nvl(ISSUEQTY,0))>0 
)
where 1=1 " + whItemCode + " " + whwhid + @"
group by WAREHOUSEID,ITEMID, ITEMCODE, ITEMNAME, STRENGTH,SKU,CATEGORY, ITEMTYPE ";



            //OracleParameter[] parameters = new OracleParameter[]
            //{
            //    new OracleParameter(":facid", OracleDbType.Int64, facid, ParameterDirection.Input)
            //};

            //var myList = _context.GsDataDTODbSet
            //    .FromSqlRaw(qry, parameters)
            //    .ToList();

            var myList = _context.WHStockDbSet
         .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

            return myList;


        }



        [HttpPost("InsertGS1LabelData1")]
        public async Task<IActionResult> InsertGS1LabelData1([FromBody] Gs1LabelDTO dto)
        {
            if (dto == null) return BadRequest("Payload required.");

            const string sql = @"
INSERT INTO TBLGS1LABELDATA
    (labelID, PONOID, SupplierID, WareHouseID, GTIN, Itemcode, SSCCNumber, Batchno, MFGDate, EXPDate, BATCHNBOXQTY, LabelCreatedate, entrydate, CANCELLATIONDATE, ISCANCEL)
VALUES
    (:labelID, :PONOID, :SupplierID, :WareHouseID, :GTIN, :Itemcode, :SSCCNumber, :Batchno, :MFGDate, :EXPDate, :BATCHNBOXQTY, :LabelCreatedate, :entrydate, :CANCELLATIONDATE, :ISCANCEL)";


            // further code to prepare parameters and execute the insert
            var parameters = new List<OracleParameter>
            {
                new OracleParameter(":labelID", OracleDbType.Int64) { Value = (object?)dto.labelID ?? DBNull.Value },
                new OracleParameter(":PONOID", OracleDbType.Int64) { Value = (object?)dto.PONOID ?? DBNull.Value },
                new OracleParameter(":SupplierID", OracleDbType.Int64) { Value = (object?)dto.SupplierID ?? DBNull.Value },
                new OracleParameter(":WareHouseID", OracleDbType.Int64) { Value = (object?)dto.WareHouseID ?? DBNull.Value },
                new OracleParameter(":GTIN", OracleDbType.Varchar2) { Value = (object?)dto.GTIN ?? DBNull.Value },
                new OracleParameter(":Itemcode", OracleDbType.Varchar2) { Value = (object?)dto.Itemcode ?? DBNull.Value },
                new OracleParameter(":SSCCNumber", OracleDbType.Varchar2) { Value = (object?)dto.SSCCNumber ?? DBNull.Value },
                new OracleParameter(":Batchno", OracleDbType.Varchar2) { Value = (object?)dto.Batchno ?? DBNull.Value },
                new OracleParameter(":MFGDate", OracleDbType.Date) { Value = (object?)dto.MFGDate ?? DBNull.Value },
                new OracleParameter(":EXPDate", OracleDbType.Date) { Value = (object?)dto.EXPDate ?? DBNull.Value },
                new OracleParameter(":BATCHNBOXQTY", OracleDbType.Decimal) { Value = (object?)dto.BATCHNBOXQTY ?? DBNull.Value },
                new OracleParameter(":LabelCreatedate", OracleDbType.Date) { Value = (object?)dto.LabelCreatedate ?? DBNull.Value },
               // new OracleParameter(":entrydate", OracleDbType.Date) { Value = (object?)dto.entrydate ?? DBNull.Value },
                new OracleParameter(":entrydate", OracleDbType.Date) { Value = DateTime.Now  },
                new OracleParameter(":CANCELLATIONDATE", OracleDbType.Date) { Value = (object?)dto.CANCELLATIONDATE ?? DBNull.Value },
                new OracleParameter(":ISCANCEL", OracleDbType.Varchar2) { Value = (object?)dto.ISCANCEL ?? DBNull.Value }

                //entrydate  set to current date 
                

            };
            // Execute the insert command
            await _context.Database.ExecuteSqlRawAsync(sql, parameters.ToArray());
            return Ok("Data inserted successfully.");


        }




        [HttpPost("InsertGS1LabelData")]
        public async Task<IActionResult> InsertGS1LabelData([FromBody] List<Gs1LabelDTO> rows)
        {
            if (rows == null || rows.Count == 0) return BadRequest("Payload required.");

            var conn = (OracleConnection)_context.Database.GetDbConnection();
            if (conn.State != System.Data.ConnectionState.Open) await conn.OpenAsync();

            await using var tx = await conn.BeginTransactionAsync();
            await using var cmd = conn.CreateCommand();
            cmd.Transaction = (OracleTransaction)tx;

            cmd.CommandText = @"
INSERT INTO TBLGS1LABELDATA
    (labelID, PONOID, SupplierID, WareHouseID, GTIN, Itemcode, SSCCNumber, Batchno,
     MFGDate, EXPDate, BATCHNBOXQTY, LabelCreatedate, entrydate, CANCELLATIONDATE, ISCANCEL)
VALUES
    (:labelID, :PONOID, :SupplierID, :WareHouseID, :GTIN, :Itemcode, :SSCCNumber, :Batchno,
     :MFGDate, :EXPDate, :BATCHNBOXQTY, :LabelCreatedate, SYSDATE, :CANCELLATIONDATE, :ISCANCEL)";
            cmd.ArrayBindCount = rows.Count;

            object[] ToObj<T>(Func<Gs1LabelDTO, T?> sel) where T : struct
                => rows.Select(r => (object?)sel(r) ?? DBNull.Value).ToArray();
            object[] ToStr(Func<Gs1LabelDTO, string?> sel, int size, OracleDbType t = OracleDbType.Varchar2)
                => rows.Select(r => (object?)sel(r) ?? DBNull.Value).ToArray();

            cmd.Parameters.Add(new OracleParameter("labelID", OracleDbType.Int64) { Value = ToObj(r => r.labelID) });
            cmd.Parameters.Add(new OracleParameter("PONOID", OracleDbType.Int64) { Value = ToObj(r => r.PONOID) });
            cmd.Parameters.Add(new OracleParameter("SupplierID", OracleDbType.Int64) { Value = ToObj(r => r.SupplierID) });
            cmd.Parameters.Add(new OracleParameter("WareHouseID", OracleDbType.Int64) { Value = ToObj(r => r.WareHouseID) });

            cmd.Parameters.Add(new OracleParameter("GTIN", OracleDbType.Varchar2, 50) { Value = rows.Select(r => (object?)r.GTIN ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("Itemcode", OracleDbType.Varchar2, 50) { Value = rows.Select(r => (object?)r.Itemcode ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("SSCCNumber", OracleDbType.Varchar2, 50) { Value = rows.Select(r => (object?)r.SSCCNumber ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("Batchno", OracleDbType.Varchar2, 50) { Value = rows.Select(r => (object?)r.Batchno ?? DBNull.Value).ToArray() });

            cmd.Parameters.Add(new OracleParameter("MFGDate", OracleDbType.Date) { Value = rows.Select(r => (object?)r.MFGDate ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("EXPDate", OracleDbType.Date) { Value = rows.Select(r => (object?)r.EXPDate ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("BATCHNBOXQTY", OracleDbType.Decimal) { Value = rows.Select(r => (object?)r.BATCHNBOXQTY ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("LabelCreatedate", OracleDbType.Date) { Value = rows.Select(r => (object?)r.LabelCreatedate ?? DBNull.Value).ToArray() });

            // entrydate -> SYSDATE in SQL
            cmd.Parameters.Add(new OracleParameter("CANCELLATIONDATE", OracleDbType.Date) { Value = rows.Select(r => (object?)r.CANCELLATIONDATE ?? DBNull.Value).ToArray() });
            cmd.Parameters.Add(new OracleParameter("ISCANCEL", OracleDbType.Varchar2, 5) { Value = rows.Select(r => (object?)r.ISCANCEL ?? DBNull.Value).ToArray() });

            var affected = await cmd.ExecuteNonQueryAsync();
            await tx.CommitAsync();

            return Ok(new { inserted = affected });
        }



        [HttpPost("UpdateGS1LabelCancellationDate")]
        public async Task<IActionResult> UpdateGS1LabelCancellationDate([FromBody] UpdateCancellationRequest req)
        {
            //if (string.IsNullOrWhiteSpace(req?.batchno))
            //    return BadRequest("Valid batchno is required.");
            //if (req!.cancellationDate is null || req.cancellationDate == default)
            //    return BadRequest("Valid cancellationDate is required.");

            const string sql = @"
        UPDATE TBLGS1LABELDATA
           SET CANCELLATIONDATE = :pCancellationDate,
         ISCANCEL = 'Y'
            WHERE BATCHNO  = :batchno";

            var parameters = new[]
            {
        new OracleParameter(":pCancellationDate", OracleDbType.Date)    { Value = req.cancellationDate },
        new OracleParameter(":batchno",           OracleDbType.Varchar2){ Value = req.batchno }
    };

            var rows = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            return rows > 0 ? Ok("Cancellation date updated successfully.")
                            : NotFound("No matching record found (either BATCHNO not found or ISCANCEL <> 'Y').");
        }





    }
}