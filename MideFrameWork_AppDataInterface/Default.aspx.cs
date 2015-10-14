using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DailyUtility;
namespace MideFrameWork_AppDataInterface
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("GetRankList.ashx");
            //Response.Redirect("GetHelpRequestList.ashx");
            //Response.Redirect("GetGiftList.ashx");
            Response.Redirect("GetBackPsw.ashx");
            //List<string> emailTo = new List<string>() { "502342395@qq.com", "mide_2008@126.com" };
            //string errorStr = "";
            //string body = "http://localhost:5918/GetBackPsw.aspx";
            //SendEmail.SendEmailnonAnonymous("mide_2008@126.com", "网益公益", "找回密码", "", emailTo, emailTo, out errorStr, "mide_2008@126.com", "mide022196183");
        }
    }
}
