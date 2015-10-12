using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using MideFrameWork.Authorization;
namespace MideFrameWork.UI.WebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string cAccount = Context.Request["childText"];
                string pAccount = Context.Request["parentText"];
                string psw = Context.Request["pwdText"];
                //登录条件：子账号、企业账号、密码、状态正常(status=0)
                string userWhere = " ChildAccount ='" + cAccount + "' AND ParentAccount='" + pAccount + "' AND Password='" + MD5Encrypt.MD5Hash(psw) + "' AND Status=" + 0;

                IList<UsersEntity> userList = DataProvider.GetInstance().GetUsersList(userWhere);
                if (userList.Count <= 0)
                {
                    //登录失败
                    Alert("账号或密码不正确，请确认！", "/index.html");
                    return;
                }
                #region 权限控制
                Authorization.Authorization currAuthor = new Authorization.Authorization();
                int timeout = currAuthor.Validate(userList[0]);
                Session["cacheKey"] = currAuthor;
                Session.Timeout = timeout;
                #endregion

                #region 记录日志
                string logContent = "[" + userList[0].ChildAccount + "@" + userList[0].ParentAccount + "]成功登录系统!";
                WriteLog("Longin.ashx", "ProcessRequest", logContent, userList[0].ID);

                #endregion

                #region 成功返回
                Context.Response.Redirect("/Main.html", true);

                return;

                #endregion
            }
            catch(Exception ex)
            {
                //系统原因返回失败
                Alert("系统发现有异常，请重新尝试！", "/index.html");
            }

        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <param name="operate">函数名称</param>
        /// <param name="logcontent">日志正文</param>
        /// <param name="logtype">日志类型</param>
        protected void WriteLog(string module, string operate, string logcontent, int userID)
        {
            LogEntity log = new LogEntity();
            log.ModuleName = module;
            log.Operation = operate;
            log.LogContent = logcontent;
            log.FromUserID = userID;
            log.LogType = 2;//操作日志
            log.CreateDate = DateTime.Now;

            try
            {
                DataProvider.GetInstance().AddLog(log);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 弹框跳转
        /// </summary>
        /// <param name="msg">弹出信息</param>
        /// <param name="url">跳转路径</param>
        protected void Alert(string msg, string url)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + msg, "alert(\"" + msg + "\");window.location.href='" + url + "'", true);
        }
    }
}