﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonDataInterface.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EHR_PASTHISTORYRECORD",
                columns: table => new
                {
                    RECORDID = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    EMPIID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALLERGYLIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALLERGY_QT1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXPOSURELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_GXY = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_TNB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_GXB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_MXZSXFJB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_EXZL = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_NZZ = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_ZXJSJB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_JHB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_GZJB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CONFIRMDATE_XTJX = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_ZYB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_ZYB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_QT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_QT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OPERATIONLIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_SS0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SS0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_SS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SS1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TRAUMALIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_WS0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_WS0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_WS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_WS1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BLOODTRANSLIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_SX0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SX0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_SX1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SX1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FATHERDISEASELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QT_FQ1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHERDISEASELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QT_MQ1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIBLINGDISEASELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QT_XDJM1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CHILDRENDISEASELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QT_ZN1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GENETICDISEASELIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXTYCBS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISABILITYLIST_HCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CJQK_QTCJ1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATEUNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATEUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTMODIFYUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTMODIFYDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LASTMODIFYUNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_SS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_SS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_SS4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SS2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STARTDATE_SS3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STARTDATE_SS4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GENERALSIGNS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISEASETEXT_SX2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SX2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_SX3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SX3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_SX4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_SX4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_WS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_WS2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_WS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_WS3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_WS4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTDATE_WS4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_EXZL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISABILITYLIST_HCODE_SJ = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_QT2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_QT2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_QT3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_QT3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_QT4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_QT4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISEASETEXT_QT5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONFIRMDATE_QT5 = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EHR_PASTHISTORYRECORD", x => x.RECORDID);
                });

            migrationBuilder.CreateTable(
                name: "MPI_DEMOGRAPHICINFO",
                columns: table => new
                {
                    EMPIID = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PERSONNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEXCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHOTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CARDNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCARD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGISTEREDPERMANENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BLOODTYPECODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HOMEPLACE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAMEPYCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONENUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOBILENUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTHDAY = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NATIONALITYCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NATIONCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RHBLOODCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MARITALSTATUSCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STARTWORKDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WORKCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDUCATIONCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSURANCECODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATEUNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATEUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATETIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LASTMODIFYUNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTMODIFYTIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LASTMODIFYUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WORKPLACE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACTPHONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSURANCETYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERSIONNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSURANCETEXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YLZH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIVESTOCKCOLUMN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CERTIFICATETYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CERTIFICATENO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POVERTYPOPULATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OWNERNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAMILYID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIGNFLAG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCEBEGINDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SCEENDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COMPLETEPERCENT = table.Column<decimal>(type: "decimal(4,0)", nullable: true),
                    IPI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HOMEADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIRTUALCARDNUM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OLD_KEY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CENTERPID = table.Column<decimal>(type: "decimal(15,0)", nullable: true),
                    CZRK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONGROUP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDDQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDXZQH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDSHE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDSHI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDXIA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDXNG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDJW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDCUN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDNONG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDLH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JZDMPH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDXZQH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDSHE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDSHI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDXIA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDXNG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDJW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDCUN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDNONG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDLH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HJDMPH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LXRGX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XGBZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YLYL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YLYL2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CYZK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HZLY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HZLX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONGROUPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONNAME_PY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MPIID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONGROUPPHIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BZ2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACTRELATION = table.Column<decimal>(type: "decimal(4,0)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPI_DEMOGRAPHICINFO", x => x.EMPIID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EHR_PASTHISTORYRECORD");

            migrationBuilder.DropTable(
                name: "MPI_DEMOGRAPHICINFO");
        }
    }
}
