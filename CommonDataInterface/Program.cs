// See https://aka.ms/new-console-template for more information

using CommonDataInterface.Data;
using CommonDataInterface.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
namespace CommonDataInterface;


public class Startup
{
    // public void ConfigureServices(IServiceCollection services)
    //     => services.AddDbContext<ApplicationDbContext>();

    // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    // {
    // }
}
public class Program
{
    readonly static string Conn = "User Id=dsjx;Password=DSsq#2023;Data Source=10.200.202.15:1521/orcl;";
    static int Seed = 0;

    /// <summary>
    /// sql语句结尾不能有分号 ;否则会报ORA-00911 无法识别的字符错误
    /// 且不能带有$符号，否则占位符无法替换
    /// </summary>

    // EF Core uses this method at design time to access the DbContext
    // public static IHostBuilder CreateHostBuilder(string[] args)
    //     => Host.CreateDefaultBuilder(args)
    //         .ConfigureWebHostDefaults(
    //             webBuilder => webBuilder.UseStartup<Startup>());
    public static void Main(string[] args)
    {
        // CreateHostBuilder(args).Build().Run();


        #region MPI
        var tableName = "PHIS.MPI_DEMOGRAPHICINFO";
        var queryCountString = @"SELECT COUNT(*) from {0}";
        var querySqlString = @"SELECT * from 
	(SELECT m.*, ROW_NUMBER() OVER(ORDER BY m.CREATETIME) AS rNumber FROM  MPI_DEMOGRAPHICINFO m)
WHERE rNumber BETWEEN {0} and {1}";
        var tableRows = GetTableRows(string.Format(queryCountString, tableName));
        Console.WriteLine($"Query MPI_DEMOGRAPHICINFO Rows : {tableRows}");

        var query = string.Format(querySqlString, Seed, tableRows);
        var itemList = new List<Mpi_DemographicInfo>();
        using (var connection = new OracleConnection(Conn)) // 创建连接对象
        {
            connection.Open();
            using (var command = new OracleCommand(query, connection))
            using (var reader = command.ExecuteReader())
                while (reader.Read())
                {
                    Mpi_DemographicInfo item = CreateMPI(reader);
                    itemList.Add(item);
                    Console.WriteLine($"Add MPI item No : {item.EMPIID} ; List count is : {itemList.Count()}");
                }
        }

        InsertList_MPI(itemList);
        #endregion MPI

        #region  EHR_PASTHISTORYRECORD
        tableName = "PHIS.EHR_PASTHISTORYRECORD";
        queryCountString = @"SELECT COUNT(*) from {0}";
        querySqlString = @"SELECT * from 
	(SELECT m.*, ROW_NUMBER() OVER(ORDER BY m.CREATEDATE) AS rNumber FROM  EHR_PASTHISTORYRECORD m)
WHERE rNumber BETWEEN {0} and {1}";
        tableRows = GetTableRows(string.Format(queryCountString, tableName));
        Console.WriteLine($"Query EHR_PASTHISTORYRECORD Rows : {tableRows}");

        query = string.Format(querySqlString, Seed, tableRows);
        var items = new List<EHR_PastHistoryRecord>();
        using (var connection = new OracleConnection(Conn)) // 创建连接对象
        {
            connection.Open();
            using (var command = new OracleCommand(query, connection))
            using (var reader = command.ExecuteReader())
                while (reader.Read())
                {
                    EHR_PastHistoryRecord item = CreateEHR_PastHistoryRecord(reader);
                    items.Add(item);
                    Console.WriteLine($"Add MPI item No : {item.EMPIID} ; List count is : {items.Count()}");
                }
        }

        InsertList_PastHistoryRecord(items);


        #endregion  EHR_PASTHISTORYRECORD
    }

    private static void InsertList_PastHistoryRecord(List<EHR_PastHistoryRecord> items)
    {
        int totalLenth = items.Count();
        int num = 0;
        int rowsSize = 2000;
        int insertedCount = 0;
        while (true)
        {
            int insertedRows = 0;
            var temp = items.Skip(num).Take(rowsSize).ToList();
            var idlist = temp.Select(r => r.RECORDID).ToList();
            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            idlist.ForEach(r =>
            {
                if (context.EHR_PASTHISTORYRECORD.Any(x => x.RECORDID == r))
                {
                    var item = temp.SingleOrDefault(i => i.RECORDID == r);
                    if (null != item)
                        temp.Remove(item);
                }
            });

            if (temp.Count() > 0)
            {
                try
                {
                    context.AddRange(temp);
                    insertedRows += context.SaveChanges();
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
            num += rowsSize;
            insertedCount += insertedRows;
            Console.WriteLine($"EHR_PASTHISTORYRECORD : {insertedRows} row inserted. Total {insertedCount} rows has done. The next is -> {num}");
            if ((num + 1) >= totalLenth)
            {
                Console.WriteLine($"EHR_PASTHISTORYRECORD : {totalLenth} is end To{num} ....");
                break;
            }
        }
    }

    private static EHR_PastHistoryRecord CreateEHR_PastHistoryRecord(OracleDataReader reader)
    {
        var item = new EHR_PastHistoryRecord();

        item.RECORDID = reader["RECORDID"].ToString();
        item.EMPIID = reader["EMPIID"].ToString();
        item.ALLERGYLIST_HCODE = reader["ALLERGYLIST_HCODE"].ToString();
        item.ALLERGY_QT1 = reader["ALLERGY_QT1"].ToString();
        item.EXPOSURELIST_HCODE = reader["EXPOSURELIST_HCODE"].ToString();
        item.DISEASELIST_HCODE = reader["DISEASELIST_HCODE"].ToString();
        item.CONFIRMDATE_GXY = DBNull.Value == reader["CONFIRMDATE_GXY"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_GXY"]);
        item.CONFIRMDATE_TNB = DBNull.Value == reader["CONFIRMDATE_TNB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_TNB"]);
        item.CONFIRMDATE_GXB = DBNull.Value == reader["CONFIRMDATE_GXB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_GXB"]);
        item.CONFIRMDATE_MXZSXFJB = DBNull.Value == reader["CONFIRMDATE_MXZSXFJB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_MXZSXFJB"]);
        item.CONFIRMDATE_EXZL = DBNull.Value == reader["CONFIRMDATE_EXZL"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_EXZL"]);
        item.CONFIRMDATE_NZZ = DBNull.Value == reader["CONFIRMDATE_NZZ"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_NZZ"]);
        item.CONFIRMDATE_ZXJSJB = DBNull.Value == reader["CONFIRMDATE_ZXJSJB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_ZXJSJB"]);
        item.CONFIRMDATE_JHB = DBNull.Value == reader["CONFIRMDATE_JHB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_JHB"]);
        item.CONFIRMDATE_GZJB = DBNull.Value == reader["CONFIRMDATE_GZJB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_GZJB"]);
        item.CONFIRMDATE_XTJX = DBNull.Value == reader["CONFIRMDATE_XTJX"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_XTJX"]);
        item.DISEASETEXT_ZYB = reader["DISEASETEXT_ZYB"].ToString();
        item.CONFIRMDATE_ZYB = DBNull.Value == reader["CONFIRMDATE_ZYB"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_ZYB"]);
        item.DISEASETEXT_QT = reader["DISEASETEXT_QT"].ToString();
        item.CONFIRMDATE_QT = DBNull.Value == reader["CONFIRMDATE_QT"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_QT"]);
        item.OPERATIONLIST_HCODE = reader["OPERATIONLIST_HCODE"].ToString();
        item.DISEASETEXT_SS0 = reader["DISEASETEXT_SS0"].ToString();
        item.STARTDATE_SS0 = DBNull.Value == reader["STARTDATE_SS0"] ? null : Convert.ToDateTime(reader["STARTDATE_SS0"]);
        item.DISEASETEXT_SS1 = reader["DISEASETEXT_SS1"].ToString();
        item.STARTDATE_SS1 = DBNull.Value == reader["STARTDATE_SS1"] ? null : Convert.ToDateTime(reader["STARTDATE_SS1"]);
        item.TRAUMALIST_HCODE = reader["TRAUMALIST_HCODE"].ToString();
        item.DISEASETEXT_WS0 = reader["DISEASETEXT_WS0"].ToString();
        item.STARTDATE_WS0 = DBNull.Value == reader["STARTDATE_WS0"] ? null : Convert.ToDateTime(reader["STARTDATE_WS0"]);
        item.DISEASETEXT_WS1 = reader["DISEASETEXT_WS1"].ToString();
        item.STARTDATE_WS1 = DBNull.Value == reader["STARTDATE_WS1"] ? null : Convert.ToDateTime(reader["STARTDATE_WS1"]);
        item.BLOODTRANSLIST_HCODE = reader["BLOODTRANSLIST_HCODE"].ToString();
        item.DISEASETEXT_SX0 = reader["DISEASETEXT_SX0"].ToString();
        item.STARTDATE_SX0 = DBNull.Value == reader["STARTDATE_SX0"] ? null : Convert.ToDateTime(reader["STARTDATE_SX0"]);
        item.DISEASETEXT_SX1 = reader["DISEASETEXT_SX1"].ToString();
        item.STARTDATE_SX1 = DBNull.Value == reader["STARTDATE_SX1"] ? null : Convert.ToDateTime(reader["STARTDATE_SX1"]);
        item.FATHERDISEASELIST_HCODE = reader["FATHERDISEASELIST_HCODE"].ToString();
        item.QT_FQ1 = reader["QT_FQ1"].ToString();
        item.MOTHERDISEASELIST_HCODE = reader["MOTHERDISEASELIST_HCODE"].ToString();
        item.QT_MQ1 = reader["QT_MQ1"].ToString();
        item.SIBLINGDISEASELIST_HCODE = reader["SIBLINGDISEASELIST_HCODE"].ToString();
        item.QT_XDJM1 = reader["QT_XDJM1"].ToString();
        item.CHILDRENDISEASELIST_HCODE = reader["CHILDRENDISEASELIST_HCODE"].ToString();
        item.QT_ZN1 = reader["QT_ZN1"].ToString();
        item.GENETICDISEASELIST_HCODE = reader["GENETICDISEASELIST_HCODE"].ToString();
        item.DISEASETEXTYCBS = reader["DISEASETEXTYCBS"].ToString();
        item.DISABILITYLIST_HCODE = reader["DISABILITYLIST_HCODE"].ToString();
        item.CJQK_QTCJ1 = reader["CJQK_QTCJ1"].ToString();
        item.CREATEDATE = DBNull.Value == reader["CREATEDATE"] ? null : Convert.ToDateTime(reader["CREATEDATE"]);
        item.CREATEUNIT = reader["CREATEUNIT"].ToString();
        item.CREATEUSER = reader["CREATEUSER"].ToString();
        item.LASTMODIFYUSER = reader["LASTMODIFYUSER"].ToString();
        item.LASTMODIFYDATE = DBNull.Value == reader["LASTMODIFYDATE"] ? null : Convert.ToDateTime(reader["LASTMODIFYDATE"]);
        item.LASTMODIFYUNIT = reader["LASTMODIFYUNIT"].ToString();
        item.STATE = reader["STATE"].ToString();
        item.DISEASETEXT_SS2 = reader["DISEASETEXT_SS2"].ToString();
        item.DISEASETEXT_SS3 = reader["DISEASETEXT_SS3"].ToString();
        item.DISEASETEXT_SS4 = reader["DISEASETEXT_SS4"].ToString();
        item.STARTDATE_SS2 = DBNull.Value == reader["STARTDATE_SS2"] ? null : Convert.ToDateTime(reader["STARTDATE_SS2"]);
        item.STARTDATE_SS3 = DBNull.Value == reader["STARTDATE_SS3"] ? null : Convert.ToDateTime(reader["STARTDATE_SS3"]);
        item.STARTDATE_SS4 = DBNull.Value == reader["STARTDATE_SS4"] ? null : Convert.ToDateTime(reader["STARTDATE_SS4"]);
        item.GENERALSIGNS = reader["GENERALSIGNS"].ToString();
        item.DISEASETEXT_SX2 = reader["DISEASETEXT_SX2"].ToString();
        item.STARTDATE_SX2 = DBNull.Value == reader["STARTDATE_SX2"] ? null : Convert.ToDateTime(reader["STARTDATE_SX2"]);
        item.DISEASETEXT_SX3 = reader["DISEASETEXT_SX3"].ToString();
        item.STARTDATE_SX3 = DBNull.Value == reader["STARTDATE_SX3"] ? null : Convert.ToDateTime(reader["STARTDATE_SX3"]);
        item.DISEASETEXT_SX4 = reader["DISEASETEXT_SX4"].ToString();
        item.STARTDATE_SX4 = DBNull.Value == reader["STARTDATE_SX4"] ? null : Convert.ToDateTime(reader["STARTDATE_SX4"]);
        item.DISEASETEXT_WS2 = reader["DISEASETEXT_WS2"].ToString();
        item.STARTDATE_WS2 = DBNull.Value == reader["STARTDATE_WS2"] ? null : Convert.ToDateTime(reader["STARTDATE_WS2"]);
        item.DISEASETEXT_WS3 = reader["DISEASETEXT_WS3"].ToString();
        item.STARTDATE_WS3 = DBNull.Value == reader["STARTDATE_WS3"] ? null : Convert.ToDateTime(reader["STARTDATE_WS3"]);
        item.DISEASETEXT_WS4 = reader["DISEASETEXT_WS4"].ToString();
        item.STARTDATE_WS4 = DBNull.Value == reader["STARTDATE_WS4"] ? null : Convert.ToDateTime(reader["STARTDATE_WS4"]);
        item.DISEASETEXT_EXZL = reader["DISEASETEXT_EXZL"].ToString();
        item.DISABILITYLIST_HCODE_SJ = DBNull.Value == reader["DISABILITYLIST_HCODE_SJ"] ? null : Convert.ToDateTime(reader["DISABILITYLIST_HCODE_SJ"]);
        item.DISEASETEXT_QT2 = reader["DISEASETEXT_QT2"].ToString();
        item.CONFIRMDATE_QT2 = DBNull.Value == reader["CONFIRMDATE_QT2"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_QT2"]);
        item.DISEASETEXT_QT3 = reader["DISEASETEXT_QT3"].ToString();
        item.CONFIRMDATE_QT3 = DBNull.Value == reader["CONFIRMDATE_QT3"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_QT3"]);
        item.DISEASETEXT_QT4 = reader["DISEASETEXT_QT4"].ToString();
        item.CONFIRMDATE_QT4 = DBNull.Value == reader["CONFIRMDATE_QT4"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_QT4"]);
        item.DISEASETEXT_QT5 = reader["DISEASETEXT_QT5"].ToString();
        item.CONFIRMDATE_QT5 = DBNull.Value == reader["CONFIRMDATE_QT5"] ? null : Convert.ToDateTime(reader["CONFIRMDATE_QT5"]);

        return item;
    }

    private static void InsertList_MPI(List<Mpi_DemographicInfo> itemList)
    {
        int totalLenth = itemList.Count();
        int num = 0;
        int rowsSize = 2000;
        int insertedCount = 0;
        while (true)
        {
            int insertedRows = 0;
            var temp = itemList.Skip(num).Take(rowsSize).ToList();
            var idlist = temp.Select(r => r.EMPIID).ToList();
            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            idlist.ForEach(r =>
            {
                if (context.MPI_DEMOGRAPHICINFO.Any(x => x.EMPIID == r))
                {
                    var item = temp.SingleOrDefault(i => i.EMPIID == r);
                    if (null != item)
                        temp.Remove(item);
                }
            });

            if (temp.Count() > 0)
            {
                try
                {
                    context.AddRange(temp);
                    insertedRows += context.SaveChanges();
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
            num += rowsSize;
            insertedCount += insertedRows;
            Console.WriteLine($"MPI_DEMOGRAPHICINFO : {insertedRows} row inserted. Total {insertedCount} rows has done. The next is -> {num}");
            if ((num + 1) >= totalLenth)
            {
                Console.WriteLine($"MPI_DEMOGRAPHICINFO : {totalLenth} is end To{num} ....");
                break;
            }
        }
    }

    private static Mpi_DemographicInfo CreateMPI(OracleDataReader reader)
    {
        var item = new Mpi_DemographicInfo();
        item.EMPIID = reader["EMPIID"].ToString();
        item.PERSONNAME = reader["PERSONNAME"].ToString();
        item.SEXCODE = reader["SEXCODE"].ToString();
        item.PHOTO = reader["PHOTO"].ToString();
        item.CARDNO = reader["CARDNO"].ToString();
        item.IDCARD = reader["IDCARD"].ToString();
        item.REGISTEREDPERMANENT = reader["REGISTEREDPERMANENT"].ToString();
        item.BLOODTYPECODE = reader["BLOODTYPECODE"].ToString();
        item.HOMEPLACE = reader["HOMEPLACE"].ToString();
        item.NAMEPYCODE = reader["NAMEPYCODE"].ToString();
        item.ADDRESS = reader["ADDRESS"].ToString();
        item.ZIPCODE = reader["ZIPCODE"].ToString();
        item.PHONENUMBER = reader["PHONENUMBER"].ToString();
        item.MOBILENUMBER = reader["MOBILENUMBER"].ToString();
        item.EMAIL = reader["EMAIL"].ToString();
        item.BIRTHDAY = DBNull.Value == reader["BIRTHDAY"] ? null : Convert.ToDateTime(reader["BIRTHDAY"]);
        item.NATIONALITYCODE = reader["NATIONALITYCODE"].ToString();
        item.NATIONCODE = reader["NATIONCODE"].ToString();
        item.RHBLOODCODE = reader["RHBLOODCODE"].ToString();
        item.MARITALSTATUSCODE = reader["MARITALSTATUSCODE"].ToString();
        item.STARTWORKDATE = DBNull.Value == reader["STARTWORKDATE"] ? null : Convert.ToDateTime(reader["STARTWORKDATE"]);
        item.WORKCODE = reader["WORKCODE"].ToString();
        item.EDUCATIONCODE = reader["EDUCATIONCODE"].ToString();
        item.INSURANCECODE = reader["INSURANCECODE"].ToString();
        item.CREATEUNIT = reader["CREATEUNIT"].ToString();
        item.CREATEUSER = reader["CREATEUSER"].ToString();
        item.CREATETIME = DBNull.Value == reader["CREATETIME"] ? null : Convert.ToDateTime(reader["CREATETIME"]);
        item.LASTMODIFYUNIT = reader["LASTMODIFYUNIT"].ToString();
        item.LASTMODIFYTIME = DBNull.Value == reader["LASTMODIFYTIME"] ? null : Convert.ToDateTime(reader["LASTMODIFYTIME"]);
        item.LASTMODIFYUSER = reader["LASTMODIFYUSER"].ToString();
        item.STATUS = reader["STATUS"].ToString();
        item.WORKPLACE = reader["WORKPLACE"].ToString();
        item.CONTACT = reader["CONTACT"].ToString();
        item.CONTACTPHONE = reader["CONTACTPHONE"].ToString();
        item.INSURANCETYPE = reader["INSURANCETYPE"].ToString();
        item.VERSIONNUMBER = reader["VERSIONNUMBER"].ToString();
        item.INSURANCETEXT = reader["INSURANCETEXT"].ToString();
        item.ISNH = reader["ISNH"].ToString();
        item.YLZH = reader["YLZH"].ToString();
        item.LIVESTOCKCOLUMN = reader["LIVESTOCKCOLUMN"].ToString();
        item.CERTIFICATETYPE = reader["CERTIFICATETYPE"].ToString();
        item.CERTIFICATENO = reader["CERTIFICATENO"].ToString();
        item.POVERTYPOPULATION = reader["POVERTYPOPULATION"].ToString();
        item.OWNERNAME = reader["OWNERNAME"].ToString();
        item.FAMILYID = reader["FAMILYID"].ToString();
        item.SIGNFLAG = reader["SIGNFLAG"].ToString();
        item.SCEBEGINDATE = DBNull.Value == reader["SCEBEGINDATE"] ? null : Convert.ToDateTime(reader["SCEBEGINDATE"]);
        item.SCEENDDATE = DBNull.Value == reader["SCEENDDATE"] ? null : Convert.ToDateTime(reader["SCEENDDATE"]);
        item.COMPLETEPERCENT = DBNull.Value == reader["COMPLETEPERCENT"] ? null : Convert.ToDecimal(reader["COMPLETEPERCENT"]);
        item.IPI = reader["IPI"].ToString();
        item.HOMEADDRESS = reader["HOMEADDRESS"].ToString();
        item.QRCODE = reader["QRCODE"].ToString();
        item.VIRTUALCARDNUM = reader["VIRTUALCARDNUM"].ToString();
        item.OLD_KEY = reader["OLD_KEY"].ToString();
        item.CENTERPID = DBNull.Value == reader["CENTERPID"] ? null : Convert.ToDecimal(reader["CENTERPID"]);
        item.CZRK = reader["CZRK"].ToString();
        item.PERSONGROUP = reader["PERSONGROUP"].ToString();
        item.SDDQ = reader["SDDQ"].ToString();
        item.JZDXZQH = reader["JZDXZQH"].ToString();
        item.JZDSHE = reader["JZDSHE"].ToString();
        item.JZDSHI = reader["JZDSHI"].ToString();
        item.JZDXIA = reader["JZDXIA"].ToString();
        item.JZDXNG = reader["JZDXNG"].ToString();
        item.JZDJW = reader["JZDJW"].ToString();
        item.JZDCUN = reader["JZDCUN"].ToString();
        item.JZDNONG = reader["JZDNONG"].ToString();
        item.JZDLH = reader["JZDLH"].ToString();
        item.JZDMPH = reader["JZDMPH"].ToString();
        item.HJDXZQH = reader["HJDXZQH"].ToString();
        item.HJDSHE = reader["HJDSHE"].ToString();
        item.HJDSHI = reader["HJDSHI"].ToString();
        item.HJDXIA = reader["HJDXIA"].ToString();
        item.HJDXNG = reader["HJDXNG"].ToString();
        item.HJDJW = reader["HJDJW"].ToString();
        item.HJDCUN = reader["HJDCUN"].ToString();
        item.HJDNONG = reader["HJDNONG"].ToString();
        item.HJDLH = reader["HJDLH"].ToString();
        item.HJDMPH = reader["HJDMPH"].ToString();
        item.LXRGX = reader["LXRGX"].ToString();
        item.MJ = reader["MJ"].ToString();
        item.XGBZ = reader["XGBZ"].ToString();
        item.YLYL1 = reader["YLYL1"].ToString();
        item.YLYL2 = reader["YLYL2"].ToString();
        item.CYZK = reader["CYZK"].ToString();
        item.HZLY = reader["HZLY"].ToString();
        item.HZLX = reader["HZLX"].ToString();
        item.PERSONGROUPCODE = reader["PERSONGROUPCODE"].ToString();
        item.PERSONNAME_PY = reader["PERSONNAME_PY"].ToString();
        item.MPIID = reader["MPIID"].ToString();
        item.PERSONGROUPPHIS = reader["PERSONGROUPPHIS"].ToString();
        item.STATE = reader["STATE"].ToString();
        item.BZ = reader["BZ"].ToString();
        item.BZ2 = reader["BZ2"].ToString();
        item.CONTACTRELATION = DBNull.Value == reader["CONTACTRELATION"] ? null : Convert.ToDecimal(reader["CONTACTRELATION"]);
        return item;
    }

    private static int GetTableRows(string queryString)
    {
        using (var connection = new OracleConnection(Conn)) // 创建连接对象
        {
            connection.Open();
            using (var command = new OracleCommand(queryString, connection))
            {
                try
                {
                    // command.Parameters.AddWithValue(":value", someValue); // 设置参数值
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine($"Read {reader.RowSize} rows.");
                        while (reader.Read())
                        {
                            return Convert.ToInt32(reader[0]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connection.Close(); }
            }
        }
        return 0;
    }
}
