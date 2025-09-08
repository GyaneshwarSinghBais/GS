﻿
//using DPDMIS_Angular_API.Data;
//using DPDMIS_Angular_API.DTO.IssueDTO;
using GS_API.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Plugins;
using Oracle.ManagedDataAccess.Client;
//using SMSRef;
using System;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace CgmscHO_API.Utility
{
    public class FacOperations
    {
        private readonly OraDbContext _context;
        public FacOperations(OraDbContext context)
        {
            _context = context;
        }





        //public bool ChangePasswordCourier(string NewPassword, string userid)
        //{
        //    string dt1 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");

        //    #region Save data
        //    Broadline.Common.SecUtils.SaltedHash sh = Broadline.Common.SecUtils.SaltedHash.Create(NewPassword);
        //    string salthash1 = "salt{" + sh.Salt + "}hash{" + sh.Hash + "}";
        //    string Query = "UPDATE usrUsers Set cPwd = '" + salthash1 + "', LASTPWDCHANGEDATE = '"+ dt1 +"' Where UserID = " + userid;
        //    // string Query = "UPDATE usrUsers Set cPwd = '1236' Where UserID = " + userid;
        //    //string Query = "UPDATE usrUsers Set cPwd = 'salt{RIkyP/sv}hash{4+o7yNCfHmw0eSHo1OIv/hNaTgY=}', LASTPWDCHANGEDATE = '09-May-2024 12:02:59 PM' Where UserID = 4391" ;
        //    //string Query = "UPDATE usrUsers Set cPwd = '123', LASTPWDCHANGEDATE = '09-May-2024 12:02:59 PM' Where UserID = 4391";

        //    _context.Database.ExecuteSqlRaw(Query);

        //    return true;
        //    #endregion

        //}


        //public bool ChangePasswordCourier(string NewPassword, string userid)
        //{
        //    string dt1 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");

        //    // Create salted hash
        //    Broadline.Common.SecUtils.SaltedHash sh = Broadline.Common.SecUtils.SaltedHash.Create(NewPassword);
        //    string salthash1 = "salt{" + sh.Salt + "}hash{" + sh.Hash + "}";

        //    // Construct parameterized query
        //    string query = "UPDATE usrUsers SET cPwd = :Password, LASTPWDCHANGEDATE = :LastPwdChangeDate WHERE UserID = :UserID";

        //    // Execute parameterized query
        //    _context.Database.ExecuteSqlRaw(query,
        //        new OracleParameter("Password", salthash1),
        //        new OracleParameter("LastPwdChangeDate", dt1),
        //        new OracleParameter("UserID", userid)
        //    );

        //    return true;
        //}




        //public bool ChangePassword(string NewPassword, string userid)
        //{
        //    string dt1 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");


        //    Broadline.Common.SecUtils.SaltedHash sh = Broadline.Common.SecUtils.SaltedHash.Create(NewPassword);
        //    string salthash1 = "salt{" + sh.Salt + "}hash{" + sh.Hash + "}";
        //    string Query = "UPDATE usrUsers Set Pwd = '" + salthash1 + "', LASTPWDCHANGEDATE = '" + dt1 + "' Where UserID = " + userid;

        //    _context.Database.ExecuteSqlRaw(Query);

        //    return true;


        //}


        //public bool changpassword(string userid, string NewPassword, out string message)
        //{


        //    //,LASTPWDCHANGEDATE=TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss') 
        //    string dt1 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        //    string now = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        //        Broadline.Common.SecUtils.SaltedHash sh = Broadline.Common.SecUtils.SaltedHash.Create(NewPassword);
        //        string salthash1 = "salt{" + sh.Salt + "}hash{" + sh.Hash + "}";
        //  //  string Query = "UPDATE usrUsers Set Pwd = '" + salthash1 + "' Where UserID = " + userid;
        //    //    _context.Database.ExecuteSqlRaw(Query);

        //    // Construct parameterized query
        //    string query = "UPDATE usrUsers SET Pwd = :Password, LASTPWDCHANGEDATE = :LastPwdChangeDate,RESETPASSWORD=1 WHERE UserID = :UserID";

        //    // Execute parameterized query
        //    _context.Database.ExecuteSqlRaw(query,
        //        new OracleParameter("Password", salthash1),
        //        new OracleParameter("LastPwdChangeDate", dt1),
        //        new OracleParameter("UserID", userid)
        //    );



        //    message = "Password Successfully Updated";
        //        return true;


        //}




        //public string getFacCodeForIndent(Int64 facId)
        //{
        //    string yearid = getACCYRSETID();
        //    string qry = " Select a.FACILITYID, Lpad(NVL(Max(To_Number(a.AUTO_NCCODE)), 0) + 1, 5, '0') as FACILITYCODE" +
        //       " From MASCGMSCNOC a" +
        //       " where a.FACILITYID=" + facId + " and a.accyrsetid=" + yearid + " group by a.FACILITYID";

        //    var myList = _context.GenWhIndentNoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string facCode = myList[0].FACILITYCODE; // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return "00001"; // Or any other appropriate indication
        //    }
        //}


        //public string getFacCodeForSHCIndent(Int64 facId)
        //{
        //    string yearid = getACCYRSETID();
        //    string qry = " Select Lpad(NVL(Max(To_Number(a.AUTO_CODE)), 0) + 1, 5, '0') as SOCode" +
        // " From MASFACTRANSFERS a" +
        // " where a.FACILITYID=" + facId + " and a.accyrsetid=" + yearid;

        //    var myList = _context.getFacCodeForSHCIndentDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        String facCode = myList[0].SOCODE.ToString(); // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return "00001"; // Or any other appropriate indication
        //    }
        //}




        public Int64 facGetGSRID()
        {  
            Int64 genNo = getGSID();
            
            return genNo;
        }

        public Int64 getGSID()
        {
            string strSQL = "";

            strSQL = "select nvl(max(GSRID),0)+1 as GSRID from GS1MASTERRECEIPT order by GSRID desc ";



            var myList = _context.getGsidDTODbSet.FromSqlInterpolated(FormattableStringFactory.Create(strSQL)).ToList();

            if (myList.Count > 0)
            {
                Int64 WHSlNo = Convert.ToInt64( myList[0].GSRID); // Assuming IssueItemID is an integer
                return WHSlNo;
            }
            else
            {
                return 0; // Or any other appropriate indication
            }
        }

        //public void getIndentData(Int64 indentId, out string? nocDate, out Int64? wardid)
        //{
        //    string strSQL = "";
        //    strSQL = " select NOCID, NOCDATE as REQUESTEDDATE,WARDID from maswardindents where nocid= " + indentId;



        //    var myList = _context.IndentDataDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(strSQL)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        nocDate = myList[0].REQUESTEDDATE; // Assuming IssueItemID is an integer
        //        wardid = Convert.ToInt64(myList[0].WARDID);

        //    }
        //    else
        //    {
        //        nocDate = null;
        //        wardid = null;
        //    }

        //}

        //public string getSHAccYear()
        //{
        //    string qry = @"select ACCYRSETID,ACCYEAR,STARTDATE,ENDDATE,SHACCYEAR,YEARORDER from masAccYearSettings Where sysdate between StartDate and EndDate";

        //    //var context = new masAccYearSettingsModel();

        //    var myList = _context.masAccYearSettingsDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string shyr = myList[0].SHACCYEAR; // Assuming IssueItemID is an integer
        //        return shyr.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}
        //public string getForgotData(string emailMob)
        //{
        //    string qry = @"  select f.facilityid from usrusers u 
        //                    left outer join masfacilities f on f.facilityid=u.facilityid
        //                    where    (u.emailid ='" + emailMob + "' or f.phone1='" + emailMob + "')   ";



        //    var myList = _context.PasswordForgetDbset
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string shyr = myList[0].FACILITYID; // Assuming IssueItemID is an integer
        //        return shyr.ToString();
        //    }
        //    else
        //    {
        //        return "0"; // Or any other appropriate indication
        //    }
        //}
        //public string getCollectorDisid(string userid)
        //{
        //    string qry = @" select DISTRICTID as CMHOFACILITY  from usrusers where  userid = " + userid;

        //    //var context = new masAccYearSettingsModel();

        //    //var context = new getCMHOfacfromDistDTO();

        //    var myList = _context.getCMHOfacfromDistDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string facCode = Convert.ToString(myList[0].CMHOFACILITY); // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}
        //public string getCMHOFacFromDistrict(string distid)
        //{
        //    string qry = @" select FACILITYID as CMHOFACILITY from masfacilities where facilitytypeid=353 and isactive=1 and DISTRICTID=" + distid;

        //    //var context = new masAccYearSettingsModel();

        //    //var context = new getCMHOfacfromDistDTO();

        //    var myList = _context.getCMHOfacfromDistDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string facCode = Convert.ToString(myList[0].CMHOFACILITY); // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}


        //public string getWarehousefromDistrict(string distid)
        //{
        //    string qry = @" select WAREHOUSEID as CMHOFACILITY from masdistricts where  DISTRICTID=" + distid;

        //    //var context = new masAccYearSettingsModel();

        //    //var context = new getCMHOfacfromDistDTO();

        //    var myList = _context.getCMHOfacfromDistDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string facCode = Convert.ToString(myList[0].CMHOFACILITY); // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}





        //public string getCurrYearmonth()
        //{
        //    string qry = @" select ACCYRSETID,ACCYEAR,STARTDATE,SHACCYEAR,to_char(sysdate,'YYYY-MM') as ENDDATE,YEARORDER from masAccYearSettings Where sysdate between StartDate and EndDate";

        //    //var context = new masAccYearSettingsModel();

        //    var myList = _context.masAccYearSettingsDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string shyr = myList[0].ENDDATE; // Assuming IssueItemID is an integer
        //        return shyr.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}

        //public string getNextYearMonth(Int64 facId)
        //{
        //    string yearid = getACCYRSETID();
        //    //string qry = " Select a.FACILITYID, Lpad(NVL(Max(To_Number(a.AUTO_NCCODE)), 0) + 1, 5, '0') as FACILITYCODE" +
        //    //  " From MASCGMSCNOC a" +
        //    //   " where a.FACILITYID=" + facId + " and a.accyrsetid=" + yearid + " group by a.FACILITYID";

        //    string qry = "SELECT 1 as FACILITYID,to_char(ADD_MONTHS(sysdate," + facId + @" ) ,'YYYY-MM') as FACILITYCODE FROM DUAL";

        //    var myList = _context.GenWhIndentNoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string facCode = myList[0].FACILITYCODE; // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return "00001"; // Or any other appropriate indication
        //    }
        //}

        //public string getACCYRSETID()
        //{
        //    string qry = @"select ACCYRSETID,ACCYEAR,STARTDATE,ENDDATE,SHACCYEAR,YEARORDER from masAccYearSettings Where sysdate between StartDate and EndDate";

        //    //var context = new masAccYearSettingsModel();

        //    var myList = _context.masAccYearSettingsDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string shyr = Convert.ToString(myList[0].ACCYRSETID); // Assuming IssueItemID is an integer
        //        return shyr.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}



        //private string getFacCode(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility   from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                     inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //    //var context = new FacilityInfoDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        string facCode = myList[0].FACILITYCODE; // Assuming IssueItemID is an integer
        //        return facCode.ToString();
        //    }
        //    else
        //    {
        //        return null; // Or any other appropriate indication
        //    }
        //}

        //public Int64 getWHID(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility   from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                      inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //   // var context = new FacilityMCDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int64 whid = 0;
        //    if (myList.Count > 0)
        //    {
        //        whid = Convert.ToInt64(myList[0].WAREHOUSEID); // Assuming IssueItemID is an integer

        //    }
        //    return whid;
        //}

        //public Int64 getPHCid(string facId)
        //{
        //    string qry = @"     select PHC_ID from masfacilities where facilityid = " + facId;

        //    // var context = new FacilityMCDTO();

        //    var myList = _context.ParentPHCidDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int64 phcid = 0;
        //    if (myList.Count > 0)
        //    {
        //        phcid = Convert.ToInt64(myList[0].PHC_ID); 

        //    }
        //    return phcid;
        //}

        //public Int64 geFACEDLCat(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility   from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                    inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //    //var context = new FacilityInfoDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int64 redlcat = 0;
        //    if (myList.Count > 0)
        //    {
        //        redlcat = Convert.ToInt64(myList[0].ELDCAT); // Assuming IssueItemID is an integer

        //    }
        //    return redlcat;
        //}

        //public Int64 geFACTypeid(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility  from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                     inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //    //var context = new FacilityInfoDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int64 retFACTYpeid = 0;
        //    if (myList.Count > 0)
        //    {
        //        retFACTYpeid = Convert.ToInt64(myList[0].FACILITYTYPEID); // Assuming IssueItemID is an integer

        //    }
        //    return retFACTYpeid;
        //}


        //public Int64 geFACTDistrictid(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility  from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                    inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //   // var context = new FacilityInfoDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int64 retFACTYpeid = 0;
        //    if (myList.Count > 0)
        //    {
        //        retFACTYpeid = Convert.ToInt64(myList[0].DISTRICTID); // Assuming IssueItemID is an integer

        //    }
        //    return retFACTYpeid;
        //}

        //public Int64 gecmhoid(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility  from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                    inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //   // var context = new FacilityInfoDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int64 retFACTYpeid = 0;
        //    if (myList.Count > 0)
        //    {
        //        retFACTYpeid = Convert.ToInt64(myList[0].CMHOFACILITY); // Assuming IssueItemID is an integer

        //    }
        //    return retFACTYpeid;
        //}

        //public Int32 geFACHOID(string facId)
        //{
        //    string qry = @" select f.FACILITYNAME,f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,  d.districtid,d.districtname,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact,f.FACILITYTYPEID,ft.hodid,cm.cmhofacility  from masfacilities f
        //                    inner join usrusers u on u.FACILITYID=f.facilityid
        //                    left outer join MASFACHEADERFOOTER h on h.userid=u.userid
        //                    inner join masfacilitywh fw on fw.facilityid=f.facilityid
        //                    inner join maswarehouses w on w.WAREHOUSEID=fw.WAREHOUSEID
        //                    inner join masfacilitytypes ft on ft.FACILITYTYPEID=f.FACILITYTYPEID
        //                    inner join masdistricts d on d.districtid=f.districtid
        //                   inner join 
        //                    (
        //                    select FACILITYID as cmhofacility,districtid from masfacilities where facilitytypeid=353 and isactive=1
        //                    ) cm on cm.districtid=d.districtid
        //                    where f.facilityid = " + facId;

        //    //var context = new FacilityInfoDTO();

        //    var myList = _context.FacilityInfoDbSet
        //    .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
        //    Int32 retFACHODID = 0;
        //    if (myList.Count > 0)
        //    {
        //        retFACHODID = Convert.ToInt32(myList[0].HODID); // Assuming IssueItemID is an integer

        //    }
        //    return retFACHODID;
        //}

        //public string GetMonthName(string? date_ddmmyyyy)
        //{
        //    // Define the input formats
        //    string[] inputFormats = { "dd-MM-yyyy", "dd/MM/yyyy" };

        //    // Attempt to parse the date using the input formats
        //    if (DateTime.TryParseExact(date_ddmmyyyy, inputFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        //    {
        //        // Format the parsed date as "dd-MMM-yyyy"
        //        string formattedDate = parsedDate.ToString("dd-MMM-yyyy");
        //        return formattedDate;
        //    }
        //    else
        //    {
        //        // Handle invalid date input if needed
        //        return "Invalid Date";
        //    }
        //}


        public string FormatDate(string dateStr)
        {
            // Try to parse the input date string into a DateTime object
            if (DateTime.TryParse(dateStr, out DateTime date))
            {
                string[] monthNames = {
            "Jan", "Feb", "Mar", "Apr", "May", "Jun",
            "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
        };

                // Format the parsed date into the desired format
                string formattedDate = $"{date.Day}-{monthNames[date.Month - 1]}-{date.Year}";

                return formattedDate;
            }
            else
            {
                // Handle invalid date format if needed
                return "Invalid Date";
            }
        }


//        public void getWhIssuedItemData(Int64 facilityId, Int64 inwardNo, Int64 facReceiptId, out Int64? indentItemId, out Int64? itemId, out Int64? batchQty, out Int64? facReceiptItemid, out string? MfgDate, out Int64? ponoid, out Int32? qastatus, out string? whissueblock, out string? expiryDate, out string? batchno)
//        {
//            string strSQL = "";
//            strSQL = @"Select distinct m.itemid,rb.batchno,rb.expdate,tbo.IssueQty*nvl(m.unitcount,1) as IssueBatchQty,rb.InwNo
//,tbi.indentitemid,tfr.FacReceiptID,tfi.FacReceiptItemID,rb.MfgDate,rb.ponoid,case when nvl(m.qctest,'Y')='Y' then rb.qastatus else 1 end as qastatus,rb.whissueblock
//             from tbIndentItems tbi
//             left outer Join tbOutwards tbo on (tbo.IndentItemID = tbi.IndentItemID) 
//             left outer Join tbReceiptBatches rb on (rb.InwNo = tbo.InwNo) 
//             Inner Join masItems m on (m.ItemID=tbi.ItemID)
//             Inner Join tbIndents tb on (tb.Indentid=tbi.IndentId)      
//             left outer join  tbFacilityReceipts tfr on (tfr.IndentID=tb.IndentID) and tfr.facilityid=" + facilityId + @" and tfr.FacReceiptID= " + facReceiptId + @"
//            Left Outer Join tbFacilityReceiptItems tfi on  tfi.FacReceiptID=tfr.FacReceiptID and tfi.itemid=tbi.itemid         and tfi.INDENTITEMID=tbi.INDENTITEMID
//             Where 1=1  and tb.FacilityID =" + facilityId + @"
//             and rb.InwNo =  " + inwardNo;



//            var myList = _context.ExtractReceiptItemsDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(strSQL)).ToList();

//            if (myList.Count > 0)
//            {
//                indentItemId = myList[0].INDENTITEMID; // Assuming IssueItemID is an integer
//                itemId = Convert.ToInt64(myList[0].ITEMID);
//                batchQty = Convert.ToInt64(myList[0].ISSUEBATCHQTY);
//                facReceiptItemid = Convert.ToInt64(myList[0].FACRECEIPTITEMID);
//                MfgDate = myList[0].MFGDATE;
//                ponoid = Convert.ToInt64(myList[0].PONOID);
//                qastatus = Convert.ToInt32(myList[0].QASTATUS);
//                whissueblock = myList[0].WHISSUEBLOCK;
//                expiryDate = myList[0].EXPDATE;
//                batchno = myList[0].BATCHNO;

//            }
//            else
//            {
//                indentItemId = null;
//                itemId = null;
//                batchQty = null;
//                facReceiptItemid = null;
//                MfgDate = null;
//                ponoid = null;
//                qastatus = null;
//                whissueblock = null;
//                expiryDate = null;
//                batchno = null;
//            }

//        }

//        public void getWhIssuedItemDataSP(Int64 facilityId, Int64 inwardNo, Int64 facReceiptId, out Int64? indentItemId, out Int64? itemId, out Int64? batchQty, out Int64? facReceiptItemid, out string? MfgDate, out Int64? ponoid, out Int32? qastatus, out string? whissueblock, out string? expiryDate, out string? batchno)
//        {
//            string strSQL = "";
////            strSQL1 = @"Select distinct m.itemid,rb.batchno,rb.expdate,tbo.IssueQty*nvl(m.unitcount,1) as IssueBatchQty,rb.InwNo
////,tbi.indentitemid,tfr.FacReceiptID,tfi.FacReceiptItemID,rb.MfgDate,rb.ponoid,case when nvl(m.qctest,'Y')='Y' then rb.qastatus else 1 end as qastatus,rb.whissueblock
////             from tbIndentItems tbi
////             left outer Join tbOutwards tbo on (tbo.IndentItemID = tbi.IndentItemID) 
////             left outer Join tbReceiptBatches rb on (rb.InwNo = tbo.InwNo) 
////             Inner Join masItems m on (m.ItemID=tbi.ItemID)
////             Inner Join tbIndents tb on (tb.Indentid=tbi.IndentId)      
////             left outer join  tbFacilityReceipts tfr on (tfr.IndentID=tb.IndentID) and tfr.facilityid=" + facilityId + @" and tfr.FacReceiptID= " + facReceiptId + @"
////            Left Outer Join tbFacilityReceiptItems tfi on  tfi.FacReceiptID=tfr.FacReceiptID and tfi.itemid=tbi.itemid         and tfi.INDENTITEMID=tbi.INDENTITEMID
////             Where 1=1  and tb.FacilityID =" + facilityId + @"
////             and rb.InwNo =  " + inwardNo;


//            strSQL = @" Select distinct m.itemid,rb.batchno,rb.expdate,tbo.IssueQty as IssueBatchQty,rb.InwNo
//,tbi.issueitemid as indentitemid,tfr.FacReceiptID,tfi.FacReceiptItemID,rb.MfgDate,rb.ponoid,case when nvl(m.qctest, 'Y') = 'Y' then rb.qastatus else 1 end as qastatus,rb.whissueblock
//             from tbfacilityissueitems tbi
//               Inner Join tbfacilityoutwards tbo on(tbo.issueitemid = tbi.issueitemid)
//              Inner Join tbfacilityreceiptbatches rb on(rb.InwNo = tbo.InwNo)
//             Inner Join vmasitems m on(m.ItemID = tbi.ItemID)
//             Inner Join tbfacilityissues tb on(tb.issueid = tbi.issueid)
//             left outer join tbFacilityReceipts tfr on(tfr.issueid= tb.issueid) and tfr.facilityid = " + facilityId + @" and tfr.FacReceiptID = " + facReceiptId + @"
//            Left Outer Join tbFacilityReceiptItems tfi on  tfi.FacReceiptID = tfr.FacReceiptID and tfi.itemid = tbi.itemid
//             Where 1 = 1  and tb.TOFACILITYID =" + facilityId + @"
         
//             and rb.InwNo = " + inwardNo;



//            var myList = _context.ExtractReceiptItemsDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(strSQL)).ToList();

//            if (myList.Count > 0)
//            {
//                indentItemId = myList[0].INDENTITEMID; // Assuming IssueItemID is an integer
//                itemId = Convert.ToInt64(myList[0].ITEMID);
//                batchQty = Convert.ToInt64(myList[0].ISSUEBATCHQTY);
//                facReceiptItemid = Convert.ToInt64(myList[0].FACRECEIPTITEMID);
//                MfgDate = myList[0].MFGDATE;
//                ponoid = Convert.ToInt64(myList[0].PONOID);
//                qastatus = Convert.ToInt32(myList[0].QASTATUS);
//                whissueblock = myList[0].WHISSUEBLOCK;
//                expiryDate = myList[0].EXPDATE;
//                batchno = myList[0].BATCHNO;

//            }
//            else
//            {
//                indentItemId = null;
//                itemId = null;
//                batchQty = null;
//                facReceiptItemid = null;
//                MfgDate = null;
//                ponoid = null;
//                qastatus = null;
//                whissueblock = null;
//                expiryDate = null;
//                batchno = null;
//            }

//        }

//        public string getitemcode(string itemid)
//        {
//            string qry = @" select mi.itemid, mi.itemname||'-'|| mi.itemcode as name, mi.itemcode, mi.itemname, mi.strength1, mi.unit, mi.unitcount, g.groupid, g.groupname, ty.ITEMTYPEID, ty.ITEMTYPENAME
//, e.edlcat, e.edl,case when mi.isedl2021= 'Y' then 'EDL' else 'Non EDL' end as EDLtype
//from masitems mi
//left outer join masedl e on e.edlcat= mi.edlcat
// inner join masitemcategories c on c.categoryid= mi.categoryid
//inner join masitemmaincategory mc on mc.MCID= c.MCID
//left outer join masitemtypes ty on ty.ITEMTYPEID= mi.ITEMTYPEID
//left outer join masitemgroups g on g.groupid= mi.groupid
//where 1=1 and mi.itemid=" + itemid;





//            var myList = _context.MasItemsDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

//            if (myList.Count > 0)
//            {
//                string shyr = Convert.ToString(myList[0].ITEMCODE); // Assuming IssueItemID is an integer
//                return shyr.ToString();
//            }
//            else
//            {
//                return null; // Or any other appropriate indication
//            }
//        }

//        public void isFacilityReceiptItemsExist(Int64 itemId, Int64 facReceiptId, out Int64? batchQty1, out Int64? facilityReceiptItemId)
//        {
//            string strSQL = "";
//            strSQL = @"  select ABSRQTY,FACRECEIPTITEMID from tbFacilityReceiptItems where itemid=" + itemId + " and FACRECEIPTID=" + facReceiptId + " ";



//            var myList = _context.tbFacilityReceiptItemsDbSet1
//            .FromSqlInterpolated(FormattableStringFactory.Create(strSQL)).ToList();

//            if (myList.Count > 0)
//            {
//                batchQty1 = myList[0].ABSRQTY;
//                facilityReceiptItemId = Convert.ToInt64(myList[0].FACRECEIPTITEMID);

//            }
//            else
//            {
//                batchQty1 = null;
//                facilityReceiptItemId = null;
//            }

//        }

//        public void UpdateFlagforAlradyProgressed(Int64 ponoid, Int64 whid)
//        {

//            string qry = "select  PROGRESSID from TBLRECVPROGRESS where ponoid = " + ponoid + " and warehouseid = " + whid;
//            var myList = _context.ProgressRecDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();

//            if (myList.Count > 0)
//            {

//                string qryUpdate = @"update TBLRECVPROGRESS set LATFLAG='N' where ponoid=" + ponoid + " and warehouseid=" + whid + "";
//                _context.Database.ExecuteSqlRaw(qryUpdate);

//            }
//            else
//            {

//            }

//        }


       

        //public bool GetBatchQTY(string inwno, Int64 facreceiptitemid, Int64 mReceiptID)
        //{
        //    string batchQTY = "";
        //    bool value = false;
        //    string strSQL = "Select ABSRQTY  from tbFacilityReceiptBatches Where inwno = " + inwno + " and FACRECEIPTITEMID= " + facreceiptitemid;

        //    var myList = _context.GetAbsrQtyDbSet
        //   .FromSqlInterpolated(FormattableStringFactory.Create(strSQL)).ToList();

        //    if (myList.Count > 0)
        //    {
        //        batchQTY = myList[0].ABSRQTY.ToString();
        //    }
        //    string itemQTY = "";
        //    string strSQL1 = "Select ABSRQTY  from tbfacilityreceiptitems Where  FACRECEIPTITEMID= " + facreceiptitemid;

        //    var myList1 = _context.GetAbsrQtyDbSet
        //.FromSqlInterpolated(FormattableStringFactory.Create(strSQL1)).ToList();

        //    if (myList1.Count > 0)
        //    {
        //        itemQTY = myList[0].ABSRQTY.ToString();
        //    }

        //    if (batchQTY == itemQTY)
        //    {
        //        string mQuery1 = "Delete from tbFacilityReceiptBatches Where inwno = " + inwno + " and FACRECEIPTITEMID= " + facreceiptitemid;
        //        _context.Database.ExecuteSqlRaw(mQuery1);

        //        string mQuery = "Delete from tbfacilityreceiptitems Where FACReceiptID = " + mReceiptID + " and FACReceiptItemID= " + facreceiptitemid;
        //        _context.Database.ExecuteSqlRaw(mQuery);
        //        value = true;
        //    }
        //    else
        //    {
        //        string mQuery = "update  tbfacilityreceiptitems set absrqty=absrqty-" + batchQTY + " Where FACReceiptID = " + mReceiptID + " and FACReceiptItemID= " + facreceiptitemid;
        //        _context.Database.ExecuteSqlRaw(mQuery);

        //        string mQuery1 = "Delete from tbFacilityReceiptBatches Where inwno = " + inwno + " and FACRECEIPTITEMID= " + facreceiptitemid;
        //        _context.Database.ExecuteSqlRaw(mQuery1);

        //        value = true;
        //    }
        //    return value;
        //}
//        public string insertUpdateOTP1(string userid)
//        {
//            string mobNo = getMobileNumber(userid);

//            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
//            string sRandomOTP = GenerateRandomOTP(5, saAllowedCharacters);
//            string now = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
//            string senddata = "OTP for Login on DPDMIS is " + sRandomOTP;
//            getLoginSMS(mobNo.ToString(), senddata);


//            string strUpdateQuery = "Update usrUsers Set OTP = '" + sRandomOTP + "' , OTPUPDATEDT = TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss') where userid = " + userid;
//            var myList = _context.ProgressRecDbSet
//          .FromSqlInterpolated(FormattableStringFactory.Create(strUpdateQuery)).ToList();

//            // insert OTPrecord
//            string strInsertQuery = "insert into otprecord(updatedt, otp, mob,  userid,EntryDate,IsLogin)values(TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss'), '" + sRandomOTP + "', '" + mobNo + "',  " + userid + ", TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss'),'Y' )";
//            var myListInsert = _context.ProgressRecDbSet
//              .FromSqlInterpolated(FormattableStringFactory.Create(strInsertQuery)).ToList();

//            return sRandomOTP;


//        }



//        public void getLoginSMS(String mobNumber, String OTP)
//        {

//            //SMSRef.Reference objSmsRef = new Reference();
//            // SMSRef.ServiceSoapChannel ws = new SMSRef.ServiceSoapChannel();
//            //SMSRef.Service ws = new SMSRef.Service();

            
//            var client = new ServiceSoapClient(ServiceSoapClient.EndpointConfiguration.ServiceSoap);

//            var response =  client.sendsmsHIMISAsync(mobNumber, OTP, "1407161537152057950");
//        }

//        public void insertUpdateOTP(string userid)
//        {
//            string mobNo = getMobileNumber(userid);
          
//            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
//            string sRandomOTP = GenerateRandomOTP(5, saAllowedCharacters);
//            string now = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
//            string senddata = "OTP for Login on DPDMIS is " + sRandomOTP;
//             getLoginSMS(mobNo.ToString(), senddata);


//            string strUpdateQuery = "Update usrUsers Set OTP = '" + sRandomOTP + "' , OTPUPDATEDT = TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss') where userid = " + userid;
//            var myList = _context.ProgressRecDbSet
//          .FromSqlInterpolated(FormattableStringFactory.Create(strUpdateQuery)).ToList();

//            // insert OTPrecord
//            string strInsertQuery = "insert into otprecord(updatedt, otp, mob,  userid,EntryDate,IsLogin)values(TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss'), '" + sRandomOTP + "', '" + mobNo + "',  " + userid + ", TO_DATE('" + now + "','MM/DD/YYYY hh24:mi:ss'),'Y' )";
//            var myListInsert = _context.ProgressRecDbSet
//              .FromSqlInterpolated(FormattableStringFactory.Create(strInsertQuery)).ToList();


           

//        }

//        private string getMobileNumber(string userid)
//        {
//            string value = "0";
//            string qry = @" select  d.districtname,l.locationname, f.FACILITYNAME,p.FACILITYNAME as parentfac,f.LONGITUDE,f.LATITUDE,f.PHC_ID,f.PHONE1, case when f.is_aam = 'Y' then 'AAM' else '-' end as mfacility ,f.CONTACTPERSONNAME,


//f.FACILITYCODE,f.FACILITYID,h.FOOTER1,h.FOOTER2,h.FOOTER3,h.EMAIL,
//d.districtid,ft.FACILITYTYPECODE,ft.FACILITYTYPEDESC,ft.ELDCAT,fw.warehouseid,w.WAREHOUSENAME,w.email as whemail,w.phone1 as whcontact  
//,u.userid,u.emailid, p.INDENTDURATION
//from masfacilities f
//                            inner join usrusers u on u.FACILITYID = f.facilityid
//                            left outer join MASFACHEADERFOOTER h on h.userid = u.userid
//                            inner join masfacilitywh fw on fw.facilityid = f.facilityid
//                            inner join maswarehouses w on w.WAREHOUSEID = fw.WAREHOUSEID
//                            inner join masfacilitytypes ft on ft.FACILITYTYPEID = f.FACILITYTYPEID
//                            inner join masdistricts d on d.districtid = f.districtid
//                            left outer join maslocations l on l.LOCATIONID=f.LOCATIONID
//                            left outer join masfacilities p on p.facilityid=f.PHC_ID
//                            where 1=1  and u.userid = " + userid + "";
//            var myList = _context.FacilityInfoAamDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
       

//            if (myList.Count > 0)
//            {              
//                value = myList[0].PHONE1.ToString();
//            }

//            return value;
//        }


//        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
//        {

//            string sOTP = String.Empty;

//            string sTempChars = String.Empty;

//            Random rand = new Random();

//            for (int i = 0; i < iOTPLength; i++)
//            {

//                int p = rand.Next(0, saAllowedCharacters.Length);

//                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

//                sOTP += sTempChars;

//            }

//            return sOTP;

//        }


//        public bool IsOTPVerified(string otp,string userid)
//        {
//            bool value = false;
//            string qry = @"select otp from usrUsers where userid = "+ userid +" ";
//            var myList = _context.VeriftyOtpDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();


//            if (myList.Count > 0)
//            {
              
//                if (otp == myList[0].OTP.ToString())
//                {
//                    value = true;
//                }
               
//            }

//            return value;
//        }

//        public Int64 getLocationID(string facId)
//        {
//            string qry = @" select LOCATIONID from masfacilities where facilityid = " + facId;

//            // var context = new FacilityMCDTO();

//            var myList = _context.getLocationIDbSet
//            .FromSqlInterpolated(FormattableStringFactory.Create(qry)).ToList();
//            Int64 lid = 0;
//            if (myList.Count > 0)
//            {
//                lid = Convert.ToInt64(myList[0].LOCATIONID);

//            }
//            return lid;
//        }
    }
}
