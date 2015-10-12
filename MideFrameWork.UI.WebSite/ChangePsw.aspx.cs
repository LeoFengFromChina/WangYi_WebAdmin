using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DBUtility;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork.UI.WebSite
{
    public partial class ChangePsw : BaseForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbt_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CurPsw.Value.Trim())
                || string.IsNullOrEmpty(txt_NewPsw.Value.Trim())
                || string.IsNullOrEmpty(txt_ConfirmPsw.Value.Trim()))
            {
                Alert("不能为空，请确认！");
                return;
            }
            else if (txt_NewPsw.Value.Trim() != txt_ConfirmPsw.Value.Trim())
            {
                Alert("确认密码不正确，请确认！");
                return;
            }
            if (MD5Encrypt.MD5Hash(txt_CurPsw.Value.Trim()) != CurrentUser.Password)
            {
                Alert("输入当前密码错误，请确认！");
                return;
            }
            try
            {
                CurrentUser.Password = MD5Encrypt.MD5Hash(txt_ConfirmPsw.Value.Trim());
                DataProvider.GetInstance().UpdateUsers(CurrentUser);
                Alert("密码修改成功！");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "goback", "goLogin();", true);
            }
            catch (Exception ex)
            {
                WriteLog("ChangePsw", "lbt_Submit_Click", "修改密码错误：" + ex.ToString(), Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("出现位置错误，请确认！");
            }
        }
    }
}