using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CommonDataInterface.Models;

/// <summary>
/// 电子健康档案管理系统（Electronic Health Record, EHR）
/// </summary>
public class EHR_PastHistoryRecord
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string RECORDID { get; set; }    //记录编号
    public string? EMPIID { get; set; }    //个人主索引
    public string? ALLERGYLIST_HCODE { get; set; }    //药物过敏史
    public string? ALLERGY_QT1 { get; set; }    //其他药物过敏史
    public string? EXPOSURELIST_HCODE { get; set; }    //暴露史
    public string? DISEASELIST_HCODE { get; set; }    //疾病史
    public DateTime? CONFIRMDATE_GXY { get; set; }    //高血压确诊时间
    public DateTime? CONFIRMDATE_TNB { get; set; }    //糖尿病确诊时间
    public DateTime? CONFIRMDATE_GXB { get; set; }    //冠心病确诊时间
    public DateTime? CONFIRMDATE_MXZSXFJB { get; set; }    //慢性阻塞性肺疾病确诊时间
    public DateTime? CONFIRMDATE_EXZL { get; set; }    //恶性肿瘤确诊时间
    public DateTime? CONFIRMDATE_NZZ { get; set; }    //脑卒中确诊时间
    public DateTime? CONFIRMDATE_ZXJSJB { get; set; }    //严重精神障碍确诊时间
    public DateTime? CONFIRMDATE_JHB { get; set; }    //结核病确诊时间
    public DateTime? CONFIRMDATE_GZJB { get; set; }    //肝炎确诊时间
    public DateTime? CONFIRMDATE_XTJX { get; set; }    //先天畸形确诊时间
    public string? DISEASETEXT_ZYB { get; set; }    //职业病名称
    public DateTime? CONFIRMDATE_ZYB { get; set; }    //职业病确诊时间
    public string? DISEASETEXT_QT { get; set; }    //其他疾病名称
    public DateTime? CONFIRMDATE_QT { get; set; }    //其他疾病确诊时间
    public string? OPERATIONLIST_HCODE { get; set; }    //手术史
    public string? DISEASETEXT_SS0 { get; set; }    //手术史名称1
    public DateTime? STARTDATE_SS0 { get; set; }    //手术史名称1确诊时间
    public string? DISEASETEXT_SS1 { get; set; }    //手术史名称2
    public DateTime? STARTDATE_SS1 { get; set; }    //手术史名称2时间
    public string? TRAUMALIST_HCODE { get; set; }    //外伤史
    public string? DISEASETEXT_WS0 { get; set; }    //外伤史名称1
    public DateTime? STARTDATE_WS0 { get; set; }    //外伤史名称1时间
    public string? DISEASETEXT_WS1 { get; set; }    //外伤史名称2
    public DateTime? STARTDATE_WS1 { get; set; }    //外伤史名称2时间
    public string? BLOODTRANSLIST_HCODE { get; set; }    //输血史
    public string? DISEASETEXT_SX0 { get; set; }    //输血史1原因
    public DateTime? STARTDATE_SX0 { get; set; }    //输血史1时间
    public string? DISEASETEXT_SX1 { get; set; }    //输血史2原因
    public DateTime? STARTDATE_SX1 { get; set; }    //输血史2时间
    public string? FATHERDISEASELIST_HCODE { get; set; }    //家族史-父亲
    public string? QT_FQ1 { get; set; }    //家族史-父亲其他
    public string? MOTHERDISEASELIST_HCODE { get; set; }    //家族史-母亲
    public string? QT_MQ1 { get; set; }    //家族史-母亲其他
    public string? SIBLINGDISEASELIST_HCODE { get; set; }    //家族史-兄弟姐妹
    public string? QT_XDJM1 { get; set; }    //家族史-兄弟姐妹其他
    public string? CHILDRENDISEASELIST_HCODE { get; set; }    //家族史-母亲子女
    public string? QT_ZN1 { get; set; }    //家族史-母亲子女其他
    public string? GENETICDISEASELIST_HCODE { get; set; }    //有无遗传病史
    public string? DISEASETEXTYCBS { get; set; }    //遗传病史名称
    public string? DISABILITYLIST_HCODE { get; set; }    //残疾情况
    public string? CJQK_QTCJ1 { get; set; }    //残疾情况-其他残疾
    public DateTime? CREATEDATE { get; set; }    //建档日期
    public string? CREATEUNIT { get; set; }    //建档机构
    public string? CREATEUSER { get; set; }    //建档人员
    public string? LASTMODIFYUSER { get; set; }    //最后修改人
    public DateTime? LASTMODIFYDATE { get; set; }    //最后修改日期
    public string? LASTMODIFYUNIT { get; set; }    //最后修改单位
    public string? STATE { get; set; }    //
    public string? DISEASETEXT_SS2 { get; set; }    //手术史名称3
    public string? DISEASETEXT_SS3 { get; set; }    //手术史名称4
    public string? DISEASETEXT_SS4 { get; set; }    //手术史名称5
    public DateTime? STARTDATE_SS2 { get; set; }    //手术史名称3确诊时间
    public DateTime? STARTDATE_SS3 { get; set; }    //手术史名称4确诊时间
    public DateTime? STARTDATE_SS4 { get; set; }    //手术史名称5确诊时间
    public string? GENERALSIGNS { get; set; }    //一般体征
    public string? DISEASETEXT_SX2 { get; set; }    //
    public DateTime? STARTDATE_SX2 { get; set; }    //
    public string? DISEASETEXT_SX3 { get; set; }    //
    public DateTime? STARTDATE_SX3 { get; set; }    //
    public string? DISEASETEXT_SX4 { get; set; }    //
    public DateTime? STARTDATE_SX4 { get; set; }    //
    public string? DISEASETEXT_WS2 { get; set; }    //
    public DateTime? STARTDATE_WS2 { get; set; }    //
    public string? DISEASETEXT_WS3 { get; set; }    //
    public DateTime? STARTDATE_WS3 { get; set; }    //
    public string? DISEASETEXT_WS4 { get; set; }    //
    public DateTime? STARTDATE_WS4 { get; set; }    //
    public string? DISEASETEXT_EXZL { get; set; }    //恶性肿瘤名称
    public DateTime? DISABILITYLIST_HCODE_SJ { get; set; }    //残疾状况确诊时间
    public string? DISEASETEXT_QT2 { get; set; }    //
    public DateTime? CONFIRMDATE_QT2 { get; set; }    //
    public string? DISEASETEXT_QT3 { get; set; }    //
    public DateTime? CONFIRMDATE_QT3 { get; set; }    //
    public string? DISEASETEXT_QT4 { get; set; }    //
    public DateTime? CONFIRMDATE_QT4 { get; set; }    //
    public string? DISEASETEXT_QT5 { get; set; }    //
    public DateTime? CONFIRMDATE_QT5 { get; set; }    //
}
