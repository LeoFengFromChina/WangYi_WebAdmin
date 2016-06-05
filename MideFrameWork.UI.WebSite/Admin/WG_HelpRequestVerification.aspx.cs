using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Collections;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class WG_HelpRequestVerification : BaseForm
    {
        private string ctrID
        {
            get
            {
                if (ViewState["ctrID"] != null)
                    return (string)ViewState["ctrID"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["ctrID"] = value;
            }
        }

        private int ModuleID
        {
            get
            {
                if (ViewState["ModuleID"] != null)
                    return (int)ViewState["ModuleID"];
                else
                {
                    return -1;
                }
            }
            set
            {
                ViewState["ModuleID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ctrID = Request.QueryString["ctrID"];
            WG_HelpRequestEntity helpEN = DataProvider.GetInstance().GetWG_HelpRequestEntity(int.Parse(ctrID));
            if (!Page.IsPostBack)
                init_form(ctrID);
            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);


        }


        void Button_submit_Click(object sender, EventArgs e)
        {
            string vStr = "{ \"v1\":#v1#,\"v2\":#v2#,\"v3\":#v3#}";
            string v1 = chk_agentVer.Checked ? "true" : "false";
            string v2 = chk_CommunityVer.Checked ? "true" : "false";
            string v3 = chk_gorvVer.Checked ? "true" : "false";
            vStr = vStr.Replace("#v1#", v1).Replace("#v2#", v2).Replace("#v3#", v3);

            WG_HelpRequestEntity helpEN = DataProvider.GetInstance().GetWG_HelpRequestEntity(int.Parse(ctrID));
            if (helpEN != null)
            {
                helpEN.Verification = vStr;
                if (DataProvider.GetInstance().UpdateWG_HelpRequest(helpEN))
                {
                    Alert("认证成功！");
                }
                else
                {
                    Alert("认证过程中出现错误。");
                }
            }

        }

        #region 初始化表单

        protected void init_form(string ctrID)
        {
            chk_agentVer.Checked = false;
            chk_CommunityVer.Checked = false;
            chk_gorvVer.Checked = false;


            if (!string.IsNullOrEmpty(ctrID))
            {
                WG_HelpRequestEntity helpEN = DataProvider.GetInstance().GetWG_HelpRequestEntity(int.Parse(ctrID));
                //{"v1":false,"v2":true,"v3":false}
                string verificationStr = helpEN.Verification;
                if (!string.IsNullOrEmpty(verificationStr))
                {
                    verificationStr = verificationStr.Substring(1, verificationStr.Length - 2);
                    string[] verArray = verificationStr.Split(',');
                    if (verArray.Length > 0)
                        chk_agentVer.Checked = bool.Parse(verArray[0].Split(':')[1]);
                    if (verArray.Length > 1)
                        chk_CommunityVer.Checked = bool.Parse(verArray[1].Split(':')[1]);
                    if (verArray.Length > 2)
                        chk_gorvVer.Checked = bool.Parse(verArray[2].Split(':')[1]);
                }
            }
        }
        #endregion
    }
}