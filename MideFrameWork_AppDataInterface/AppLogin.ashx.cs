using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using MideFrameWork.Authorization;
using System.Web.Script.Serialization;
namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// AppLogin 的摘要说明
    /// </summary>
    public class AppLogin : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            WG_MenberEntityView menberView = new WG_MenberEntityView();
            string result = "";
            try
            {
                string userName = context.Request["username"];
                string psw = context.Request["psw"];

                //登录
                string userWhere = " Name ='" + userName + "' AND Psw='" + psw + "' ";

                IList<WG_MenberEntity> userList = DataProvider.GetInstance().GetWG_MenberList(userWhere);

                if (userList == null || userList.Count <= 0)
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "用户不存在或密码错误！";
                    jbo.success = false;
                }
                else
                {
                    string whereStr = " UserID=" + userList[0].ID;
                    IList<Base_PrivilegeEntity> peList = DataProvider.GetInstance().GetBase_PrivilegeList(whereStr);
                    menberView.Menber = userList[0];
                    menberView.Privilege = peList;

                    if (userList[0].Status == 0)
                    {
                        jbo.code = 0;
                        jbo.data = menberView;
                        jbo.message = "成功！";
                        jbo.success = true;
                    }
                    else if (userList[0].Status == 1)
                    {
                        //待审核
                        jbo.code = 0;
                        jbo.data = menberView;
                        jbo.message = "成功！但目前还在审核状态，可能影响部分功能";
                        jbo.success = true;
                    }
                    else
                    {
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "账号有异常，请联系管理员";
                        jbo.success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现异常。";
                jbo.success = false;
            }

            result = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}