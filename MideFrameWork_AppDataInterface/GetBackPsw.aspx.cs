using MideFrameWork.Common.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    public partial class GetBackPsw1 : System.Web.UI.Page
    {
        private string MenberName
        {
            get
            {
                if (ViewState["MenberName"] != null)
                    return (string)ViewState["MenberName"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["MenberName"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Hint.Text = "";
            string userName = Context.Request["key"];
            string decUserName = DESEncrypt.Decrypt(userName, "WYGY_BQGZS");
            MenberName = decUserName;

        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            string newPsw = txt_NewPsw.Text.Trim();
            string confirmPsw = txt_Confirm.Text.Trim();
            if (!newPsw.Equals(confirmPsw))
            {
                lbl_Hint.Text = "所输入密码不一致，请重新输入！";
                return;
            }
            else
            {
                if (newPsw.Length < 6)
                {
                    lbl_Hint.Text = "密码长度不得小于6！";
                }
                else
                {
                    string whereStr = " name=" + MenberName;
                    IList<WG_MenberEntity> meList = DataProvider.GetInstance().GetWG_MenberList("");
                    if (meList == null || meList.Count <= 0)
                    {
                        //用户不存在
                        lbl_Hint.Text = "用户不存在，本链接无法重置您的密码，请联系管理员。";
                    }
                    else
                    {
                        //
                        string psw = MD5Encrypt.MD5Hash(txt_NewPsw.Text.Trim());
                        WG_MenberEntity newME = new WG_MenberEntity();
                        newME = meList[0];
                        newME.Psw = psw;
                        if (DataProvider.GetInstance().UpdateWG_Menber(newME))
                        {
                            lbl_Hint.Text = "重置密码成功！";
                        }
                        else
                        {
                            lbl_Hint.Text = "重置密码过程中出现错误，请联系管理员！";
                        }
                    }
                }
            }
        }
    }
}