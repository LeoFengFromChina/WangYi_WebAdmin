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
        private bool IsTimeout
        {
            get
            {
                if (ViewState["IsTimeout"] != null)
                    return (bool)ViewState["IsTimeout"];
                else
                {
                    return true;
                }
            }
            set
            {
                ViewState["IsTimeout"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Hint.Text = "";
            string userName = Context.Request["key"];
            if (string.IsNullOrEmpty(userName))
            {
                lbl_Hint.Text = "您没有通过身份验证，不能使用本功能。";
                txt_Confirm.Enabled = false;
                txt_NewPsw.Enabled = false;
                return;
            }
            string decUserName = DESEncrypt.Decrypt(userName, "WYGY_BQGZS");
            string[] name_time_Array = decUserName.Split('|');
            MenberName = name_time_Array[0];
            DateTime dt = Convert.ToDateTime(name_time_Array[1]);
            double totalMinute = (DateTime.Now - dt).TotalMinutes;
            //30分钟内处理修改密码
            if (totalMinute > 15)
            {
                ProcessTimeout();
                IsTimeout = true;
                return;
            }


        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            if (IsTimeout)
            {
                ProcessTimeout();
                return;
            }
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
                    string whereStr = " name='" + MenberName + "'";
                    IList<WG_MenberEntity> meList = DataProvider.GetInstance().GetWG_MenberList(whereStr);
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

        private void ProcessTimeout()
        {
            lbl_Hint.Text = "您已经超时，请在App端重新验证！";
            txt_Confirm.Enabled = false;
            txt_NewPsw.Enabled = false;
            btn_OK.Enabled = false;
            IsTimeout = true;
            return;
        }
    }
}