using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataInterface.Models;

/// <summary>
/// 患者主索引（Enterprise Master Patient Index，EMPI）
/// </summary>
public class Mpi_DemographicInfo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string EMPIID { get; set; }    //EMPI
    public string? PERSONNAME { get; set; }    //姓名
    public string? SEXCODE { get; set; }    //性别 | GB/T 2261.1-2003 与gender.xml字典关联
    public string? PHOTO { get; set; }    //照片
    public string? CARDNO { get; set; }    //卡号
    public string? IDCARD { get; set; }    //身份证
    public string? REGISTEREDPERMANENT { get; set; }    //户籍标志 | 11=户籍（本区）
    public string? BLOODTYPECODE { get; set; }    //血型 | GA 324.6-2001 与blood.xml字典关联
    public string? HOMEPLACE { get; set; }    //出生地
    public string? NAMEPYCODE { get; set; }    //姓名拼音
    public string? ADDRESS { get; set; }    //联系地址
    public string? ZIPCODE { get; set; }    //邮政编码
    public string? PHONENUMBER { get; set; }    //家庭电话
    public string? MOBILENUMBER { get; set; }    //本人电话
    public string? EMAIL { get; set; }    //电子邮件
    public DateTime? BIRTHDAY { get; set; }    //出生日期
    public string? NATIONALITYCODE { get; set; }    //国籍 | GB/T 2659-2000  与nationality.xml字典关联
    public string? NATIONCODE { get; set; }    //民族 | GB3304-91 与ethnic.xml字典关联
    public string? RHBLOODCODE { get; set; }    //
    public string? MARITALSTATUSCODE { get; set; }    //
    public DateTime? STARTWORKDATE { get; set; }    //
    public string? WORKCODE { get; set; }    //
    public string? EDUCATIONCODE { get; set; }    //
    public string? INSURANCECODE { get; set; }    //
    public string? CREATEUNIT { get; set; }    //
    public string? CREATEUSER { get; set; }    //
    public DateTime? CREATETIME { get; set; }    //
    public string? LASTMODIFYUNIT { get; set; }    //
    public DateTime? LASTMODIFYTIME { get; set; }    //
    public string? LASTMODIFYUSER { get; set; }    //
    public string? STATUS { get; set; }    //
    public string? WORKPLACE { get; set; }    //
    public string? CONTACT { get; set; }    //
    public string? CONTACTPHONE { get; set; }    //
    public string? INSURANCETYPE { get; set; }    //
    public string? VERSIONNUMBER { get; set; }    //
    public string? INSURANCETEXT { get; set; }    //
    public string? ISNH { get; set; }    //
    public string? YLZH { get; set; }    //
    public string? LIVESTOCKCOLUMN { get; set; }    //
    public string? CERTIFICATETYPE { get; set; }    //
    public string? CERTIFICATENO { get; set; }    //
    public string? POVERTYPOPULATION { get; set; }    //
    public string? OWNERNAME { get; set; }    //
    public string? FAMILYID { get; set; }    //
    public string? SIGNFLAG { get; set; }    //
    public DateTime? SCEBEGINDATE { get; set; }    //
    public DateTime? SCEENDDATE { get; set; }    //
    public decimal? COMPLETEPERCENT { get; set; }    //
    public string? IPI { get; set; }    //
    public string? HOMEADDRESS { get; set; }    //
    public string? QRCODE { get; set; }    //原始二维码数据
    public string? VIRTUALCARDNUM { get; set; }    //虚拟电子健康卡号
    public string? OLD_KEY { get; set; }    //
    public decimal? CENTERPID { get; set; }    //
    public string? CZRK { get; set; }    //是否常驻人口,y是n否
    public string? PERSONGROUP { get; set; }    //人群分类
    public string? SDDQ { get; set; }    //属地地区
    public string? JZDXZQH { get; set; }    //居住地行政区划代码
    public string? JZDSHE { get; set; }    //居住地-省
    public string? JZDSHI { get; set; }    //居住地-市
    public string? JZDXIA { get; set; }    //居住地-县
    public string? JZDXNG { get; set; }    //居住地-乡
    public string? JZDJW { get; set; }    //居住地-居委
    public string? JZDCUN { get; set; }    //居住地-村
    public string? JZDNONG { get; set; }    //居住地-弄
    public string? JZDLH { get; set; }    //居住地-楼号
    public string? JZDMPH { get; set; }    //居住地-门牌号
    public string? HJDXZQH { get; set; }    //户籍地行政区划代码
    public string? HJDSHE { get; set; }    //户籍地-省
    public string? HJDSHI { get; set; }    //户籍地-市
    public string? HJDXIA { get; set; }    //户籍地-县
    public string? HJDXNG { get; set; }    //户籍地-乡
    public string? HJDJW { get; set; }    //户籍地-居委
    public string? HJDCUN { get; set; }    //户籍地-村
    public string? HJDNONG { get; set; }    //户籍地-弄
    public string? HJDLH { get; set; }    //户籍地-楼号
    public string? HJDMPH { get; set; }    //户籍地-门牌号
    public string? LXRGX { get; set; }    //联系人关系
    public string? MJ { get; set; }    //密级
    public string? XGBZ { get; set; }    //修改标志
    public string? YLYL1 { get; set; }    //预留一
    public string? YLYL2 { get; set; }    //预留二
    public string? CYZK { get; set; }    //从业状况
    public string? HZLY { get; set; }    //患者来源
    public string? HZLX { get; set; }    //患者类型
    public string? PERSONGROUPCODE { get; set; }    //
    public string? PERSONNAME_PY { get; set; }    //
    public string? MPIID { get; set; }    //
    public string? PERSONGROUPPHIS { get; set; }    //人群分类医疗
    public string? STATE { get; set; }    //
    public string? BZ { get; set; }    //
    public string? BZ2 { get; set; }    //
    public decimal? CONTACTRELATION { get; set; }    //联系人关系
}