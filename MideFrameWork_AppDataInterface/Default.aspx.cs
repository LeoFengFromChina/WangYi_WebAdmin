﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DailyUtility;
using MideFrameWork.Common.DBUtility;

namespace MideFrameWork_AppDataInterface
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("GetRankList.ashx");
            //Response.Redirect("GetBackPsw.ashx");
            //Response.Redirect("GetGiftList.ashx");
            //Response.Redirect("GetDistrict.ashx");
            //List<string> emailTo = new List<string>() { "502342395@qq.com", "mide_2008@126.com" };
            //string errorStr = "";
            //string body = "http://localhost:5918/GetBackPsw.aspx";
            //SendEmail.SendEmailnonAnonymous("mide_2008@126.com", "网益公益", "找回密码", "", emailTo, emailTo, out errorStr, "mide_2008@126.com", "mide022196183");

            string valuet = DESEncrypt.Encrypt("mide_2010@126.com", "WYGY_BQGZS");
            string valuet2 = DESEncrypt.Encrypt("022196182", "WYGY_BQGZS");
            Response.Write(valuet + "\r\n" + valuet2);
        }
    }
}
